using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSwipe_API.Models.DTO.Auth
{
    public class RegisterCompanyUserDTO
    {
        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string CompanyName { get; set; }

        public required List<string> Location { get; set; }

        public required string AboutCompany { get; set; }

        public required string Website { get; set; }
    }
}
