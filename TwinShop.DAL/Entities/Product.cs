using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TwinShop.DAL.Entities;

namespace Twin_Shop__Web_API.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(1000)]
        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public decimal InitialPrice { get; set; }

        [Required]
        public decimal SecondaryPrice { get; set; }

        [StringLength(2000)]
        [Required]
        public string Description { get; set; } = null!;

        public ICollection<ProductImage>? Images { get; set; }

        public int SoldNumber { get; set; }

        [Required]
        public int NumberInStorage { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public Brand? Brand { get; set; }

        public Category? Category { get; set; }

        public double AverageUserScore { get; set; }

        public bool IsDeleted { get; set; }
    }
}