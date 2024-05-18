using Microsoft.AspNetCore.Identity;

namespace JobSwipe_API.Models
{
    public class CompanyUser : JobswipeUser
    {
        public string? CompanyName { get; set; }
        public string? AboutCompany { get; set; }
        public string? Website { get; set; }
        public List<Job>? Jobs { get; set; }
    }
}
