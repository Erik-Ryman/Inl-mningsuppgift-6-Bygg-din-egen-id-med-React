using JobSwipe_API.Models;
using JobSwipe_API.Models.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JobSwipe_API.Services
{
    public interface IAuthService
    {
        JwtSecurityToken GenerateJwt(string email, string role);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        Task<RegisterCompanyUserDTO?> RegisterCompanyUser(
            RegisterCompanyUserDTO registerCompanyUser
        );
        Task<RegisterPrivateUserDTO?> RegisterPrivateUser(
            RegisterPrivateUserDTO registerPrivateUserDto
        );
    }

    public class AuthService(IUserService userService, IConfiguration configuration) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserService _userService = userService;

        public async Task<RegisterPrivateUserDTO?> RegisterPrivateUser(
            RegisterPrivateUserDTO registerPrivateUserDto
        )
        {
            await _userService.CreateAsyncPrivate(registerPrivateUserDto);

            return registerPrivateUserDto;
        }

        public async Task<RegisterCompanyUserDTO?> RegisterCompanyUser(
            RegisterCompanyUserDTO registerCompanyUser
        )
        {
            await _userService.CreateAsyncCompany(registerCompanyUser);

            return registerCompanyUser;
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var secret =
                _configuration["JWT:Secret"]
                ?? throw new InvalidOperationException("Secret not configured");

            var validation = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateLifetime = false
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }

        public JwtSecurityToken GenerateJwt(string email, string role)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.NameIdentifier, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["JWT:Secret"]
                        ?? throw new InvalidOperationException("Secret not configured")
                )
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(60),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using var generator = RandomNumberGenerator.Create();

            generator.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
