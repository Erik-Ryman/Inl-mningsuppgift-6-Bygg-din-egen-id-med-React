using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSwipe_API.Models
{
    public class Match
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; } // Foreign key
        public Guid JobId { get; set; } // Foreign key
        public Guid CompanyId { get; set; } // Foreign key
        public bool IsMatch { get; set; } = false;
    }
}
