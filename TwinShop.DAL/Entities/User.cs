using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }


        [StringLength(50)]
        public string? LastName { get; set; }


        [Phone]
        [StringLength(15)]
        [Required]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }
    }
}
