using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [StringLength(50, ErrorMessage = "Brand name must be between 1 and 50 characters.")]
        [Required(ErrorMessage = "Brand name is required.")]
        public string BrandName { get; set; }

        [StringLength(50, ErrorMessage = "Category name must be between 1 and 50 characters.")]
        public string CategoryName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive integer.")]
        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category object is required.")]
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public bool IsDeleted { get; set; } = false;

    }
}
