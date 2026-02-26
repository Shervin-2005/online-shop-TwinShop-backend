using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Product
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int BrandId { get; set; }
    }

    public class UpdateProductDto
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int BrandId { get; set; }
        [StringLength(2000)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
