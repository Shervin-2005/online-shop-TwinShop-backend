using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twin_Shop__Web_API.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string? FirstName { get; set; } = "no Fist name";

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string? LastName { get; set; } = "no Last name";

        public string? ProfileImage { get; set; }

        [Column(TypeName = "char")]
        [StringLength(11)]
        [Required]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string? Email { get; set; } = "no Email";

        [StringLength(100)]
        [Required]
        public string? PasswordHash { get; set; }
    }
}
