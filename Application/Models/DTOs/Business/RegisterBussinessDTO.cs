using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs.Business
{
    public class RegisterBusinessDTO
    {
        [Required]
        public string Name { get; set; } 

        [Required, EmailAddress]
        public string Email { get; set; } 

        [Required, MinLength(6)]
        public string PasswordHash { get; set; } 
    }
}
