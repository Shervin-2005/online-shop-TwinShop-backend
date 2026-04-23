using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twin_Shop__Web_API.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string? CategoryName { get; set; }

        [Required]
        public string? MainImage {  get; set; }

        public ICollection<Brand> Brands { get; set; } = new List<Brand>();

        public bool IsDeleted { get; set; } = false;

    }
}
