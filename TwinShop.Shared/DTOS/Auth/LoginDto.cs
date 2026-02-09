using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }
    }
}
