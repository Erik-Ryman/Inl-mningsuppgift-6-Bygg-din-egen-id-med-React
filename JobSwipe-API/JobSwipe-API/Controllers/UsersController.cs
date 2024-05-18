using JobSwipe_API.Models;
using JobSwipe_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSwipe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Company, Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{email}")]
        [Authorize(Roles = "Admin, Company, Private")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("private")]
        [Authorize(Roles = "Company, Admin")]
        public async Task<ActionResult<ICollection<PrivateUser>>> GetPrivateUsers()
        {
            var users = await _userService.GetPrivateUsers();
            return Ok(users);
        }

        [HttpGet("comapny")]
        [Authorize(Roles = "Company, Admin")]
        public async Task<ActionResult<ICollection<CompanyUser>>> GetCompanyUsers()
        {
            var users = await _userService.GetCompanyUsers();
            return Ok(users);
        }

        [HttpDelete("{email}")]
        [Authorize(Roles = "Company, Admin")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            if (user is PrivateUser privateUser)
            {
                await _userService.DeleteUser(privateUser);
            }
            else if (user is CompanyUser companyUser)
            {
                await _userService.DeleteUser(companyUser);
            }
            return Ok();
        }

        [HttpPut("{email}")]
        [Authorize(Roles = "Company, Admin")]
        public async Task<IActionResult> UpdateUser(string email, JobswipeUser user)
        {
            if (email != user.Email)
            {
                return BadRequest();
            }

            var existingUser = await _userService.GetUserByEmail(email);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.UpdateAsync(user);
            return NoContent();
        }
    }
}
