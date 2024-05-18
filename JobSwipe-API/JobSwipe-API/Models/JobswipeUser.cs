using JobSwipe_API.Models.DTO.Auth;

namespace JobSwipe_API.Models
{
    public class JobswipeUser
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public List<string>? Location { get; set; }
        public List<Match>? Matches { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public DateTime Created { get; internal set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
