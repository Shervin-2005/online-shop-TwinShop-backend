using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(100,ErrorMessage ="Product name must be between 1 and 100 characters")]
        [Required(ErrorMessage ="Product name is required")]
        public string ProductName { get; set; }

        [Range(0.01,double.MaxValue,ErrorMessage="Price must be a positive number")]
        public decimal? Price { get; set; }

        [StringLength(2000,ErrorMessage ="Description must be between 1 and 2000 characters")]
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Invalid image URL.")]
        [Required(ErrorMessage = "Image URL is required.")]
        public string ImageUrl { get; set; }

        [StringLength(50, ErrorMessage = "Brand name must be between 1 and 50 characters.")]
        public string BrandName { get; set; }

        [StringLength(50, ErrorMessage = "Category name must be between 1 and 50 characters.")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Brand ID is required.")]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public bool IsDeleted { get; set;} = false;

    }
}
