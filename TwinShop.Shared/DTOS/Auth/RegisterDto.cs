using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
