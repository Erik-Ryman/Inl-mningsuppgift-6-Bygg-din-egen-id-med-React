using System.ComponentModel.DataAnnotations;

namespace JobSwipe_API.Models.DTO
{
    public class JobDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string CompanyId { get; set; }
        public required string CompanyUrl { get; set; }
        public required DateTime FinalApplicationDate { get; set; }
        public required List<string> Location { get; set; }
        public required List<Skill> RequiredSkills { get; set; }
        public List<Skill>? OptionalSkills { get; set; } = null;
        public string? Salary { get; set; } = null;
    }
}
