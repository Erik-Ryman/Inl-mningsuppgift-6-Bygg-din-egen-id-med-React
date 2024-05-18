using System.ComponentModel.DataAnnotations;

namespace JobSwipe_API.Models.DTO.Auth
{
    public class RegisterPrivateUserDTO
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string AboutMe { get; set; }

        public required List<string> Location { get; set; }
    }
}
