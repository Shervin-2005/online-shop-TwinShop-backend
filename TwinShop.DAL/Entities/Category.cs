using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50, ErrorMessage = "Category name must be between 1 and 50 characters.")]
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; }

        public ICollection<Brand> Brands { get; set; } = new List<Brand>();
        public bool IsDeleted { get; set; } = false;

    }
}
