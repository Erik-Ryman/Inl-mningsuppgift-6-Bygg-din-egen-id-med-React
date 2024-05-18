using JobSwipe_API.Data;
using JobSwipe_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JobSwipe_API.Config
{
    public class JobSwipeApi
    {
        private readonly WebApplicationBuilder _builder;
        private readonly WebApplication _app;
        private readonly ILoggerFactory loggerFactory;

        public JobSwipeApi(string[] args)
        {
            _builder = WebApplication.CreateBuilder(args);

            loggerFactory = LoggerFactory.Create(
                b => b.SetMinimumLevel(LogLevel.Information).AddConsole()
            );

            ConfigureServices();

            _app = _builder.Build();

            ConfigureMiddleWare();
        }

        private void ConfigureServices()
        {
            // Add services to the container.
            _builder.Services.AddControllers();

            _builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                    options.UseNpgsql(
                        _builder.Configuration.GetConnectionString("DefaultConnection")
                    )
            );

            _builder.Services.AddScoped<IAuthService, AuthService>();
            _builder.Services.AddScoped<IUserService, UserService>();
            _builder.Services.AddScoped<IJobService, JobService>();
            _builder.Services.AddScoped<IUserService, UserService>();

            _builder.Services.AddDataProtection();

            _builder.Services.AddEndpointsApiExplorer();
            _builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter 'Bearer [jwt]'",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    }
                );

                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } }
                );
            });

            using var loggerFactory = LoggerFactory.Create(
                b => b.SetMinimumLevel(LogLevel.Trace).AddConsole()
            );

            var secret =
                _builder.Configuration["JWT:Secret"]
                ?? throw new InvalidOperationException("Secret not configured");

            _builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = _builder.Configuration["JWT:ValidIssuer"],
                        ValidAudience = _builder.Configuration["JWT:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ClockSkew = new TimeSpan(0, 0, 5)
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = ctx => LogAttempt(ctx.Request.Headers, "OnChallenge"),
                        OnTokenValidated = ctx =>
                            LogAttempt(ctx.Request.Headers, "OnTokenValidated")
                    };
                });

            const string policy = "defaultPolicy";

            _builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    policy,
                    p =>
                    {
                        p.AllowAnyHeader();
                        p.AllowAnyMethod();
                        p.AllowAnyHeader();
                        p.AllowAnyOrigin();
                    }
                );
            });
        }

        private void ConfigureMiddleWare()
        {
            // Configure the HTTP request pipeline.
            if (_app.Environment.IsDevelopment())
            {
                _app.UseSwagger();
                _app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                });
            }
            _app.UseCors((builder) => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            _app.UseHttpsRedirection();
            _app.UseAuthentication();
            _app.UseAuthorization();

            _app.MapControllers();
        }

        Task LogAttempt(IHeaderDictionary headers, string eventType)
        {
            var logger = loggerFactory.CreateLogger<Program>();

            var authorizationHeader = headers["Authorization"].FirstOrDefault();

            if (authorizationHeader is null)
                logger.LogInformation($"{eventType}. JWT not present");
            else
            {
                string jwtString = authorizationHeader.Substring("Bearer ".Length);

                var jwt = new JwtSecurityToken(jwtString);

                logger.LogInformation(
                    $"{eventType}. Expiration: {jwt.ValidTo.ToLongTimeString()}. System time: {DateTime.UtcNow.ToLongTimeString()}"
                );
            }

            return Task.CompletedTask;
        }

        public void Run()
        {
            _app.Run();
        }
    }
}
