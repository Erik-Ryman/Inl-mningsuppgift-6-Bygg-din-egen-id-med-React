using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSwipe_API.Models
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public CompanyUser Company { get; set; } = null!;
        public string? Salary { get; set; }
        public string? CompanyUrl { get; set; }
        public required List<string> Location { get; set; }
        public required List<Skill> RequiredSkills { get; set; }
        public List<Skill>? OptionalSkills { get; set; }
        public DateTime FinalApplicationDate { get; set; }
    }
}
