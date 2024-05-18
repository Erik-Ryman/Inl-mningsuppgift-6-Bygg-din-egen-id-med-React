using Microsoft.AspNetCore.Identity;

namespace JobSwipe_API.Models
{
    public class PrivateUser : JobswipeUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AboutMe { get; set; }
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}
