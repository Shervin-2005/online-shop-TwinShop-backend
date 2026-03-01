using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }


        [StringLength(50)]
        public string? LastName { get; set; }


        [Phone]
        [StringLength(15)]
        [Required(ErrorMessage ="Phone number is required")]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [StringLength(100,MinimumLength=6,ErrorMessage ="Password must be at least 6 characters long")]
        public string PasswordHash { get; set; }
    }
}
