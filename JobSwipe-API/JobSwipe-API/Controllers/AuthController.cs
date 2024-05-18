using JobSwipe_API.Models;
using JobSwipe_API.Models.DTO.Auth;
using JobSwipe_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JobSwipe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        IAuthService authService,
        ILogger<AuthController> logger,
        IUserService userService
    ) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly IUserService _userService = userService;
        private readonly ILogger<AuthController> _logger = logger;

        [HttpPost("RegisterPrivateUser")]
        public async Task<IActionResult> RegisterPrivateUser(
            [FromBody] RegisterPrivateUserDTO registerDto
        )
        {
            var privateUser = await _authService.RegisterPrivateUser(registerDto);
            if (privateUser == null)
            {
                return BadRequest("Something went wrong.");
            }
            return Ok(privateUser);
        }

        [HttpPost("RegisterCompanyUser")]
        public async Task<IActionResult> RegisterCompanyUser(
            [FromBody] RegisterCompanyUserDTO registerCompanyUser
        )
        {
            var companyUser = await _authService.RegisterCompanyUser(registerCompanyUser);
            if (companyUser == null)
            {
                return BadRequest("Something went wrong.");
            }
            return Ok(companyUser);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            _logger.LogInformation("Login called");

            var userObject = await _userService.GetUserByEmail(model.Email);
            if (
                userObject is not JobswipeUser user
                || !await _userService.CheckPassword(user, model.Password)
            )
                return Unauthorized();

            JwtSecurityToken token = _authService.GenerateJwt(model.Email, user.Role.Name);

            var refreshToken = _authService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            await _userService.UpdateAsync(user);

            _logger.LogInformation("Login succeeded");

            return Ok(
                new LoginResponse
                {
                    JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    RefreshToken = refreshToken
                }
            );
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshModel model)
        {
            _logger.LogInformation("Refresh called");

            var principal = _authService.GetPrincipalFromExpiredToken(model.JwtToken);

            if (principal?.Identity?.Name is null)
                return Unauthorized();

            var userObject = await _userService.GetUserByEmail(principal.Identity.Name);
            if (
                userObject is not JobswipeUser user
                || user.RefreshToken != model.RefreshToken
                || user.RefreshTokenExpiry < DateTime.UtcNow
            )
                return Unauthorized();

            var token = _authService.GenerateJwt(principal.Identity.Name, user.Role.Name);

            _logger.LogInformation("Refresh succeeded");

            return Ok(
                new LoginResponse
                {
                    JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    RefreshToken = model.RefreshToken
                }
            );
        }

        [Authorize]
        [HttpDelete("Revoke")]
        public async Task<IActionResult> Revoke()
        {
            _logger.LogInformation("Revoke called");

            var username = HttpContext.User.Identity?.Name;

            if (username is null)
                return Unauthorized();

            var userObject = await _userService.GetUserByEmail(username);

            if (userObject is null || userObject is not JobswipeUser user)
                return Unauthorized();

            user.RefreshToken = null;

            await _userService.UpdateAsync(user);

            _logger.LogInformation("Revoke succeeded");

            return Ok();
        }
    }
}
