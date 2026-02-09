using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }


        [StringLength(2000)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

    }
}
