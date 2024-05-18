using System.ComponentModel.DataAnnotations;

namespace JobSwipe_API.Models.DTO.Auth
{
    public class LoginModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
