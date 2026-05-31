using System.ComponentModel.DataAnnotations;
using TwinShop.DAL.Entities;

namespace Twin_Shop__Web_API.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [StringLength(100)]
        [Required]
        public string BrandName { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string MainImageUrl { get; set; } = null!;

        public ICollection<BrandCategory> BrandCategories { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }

        public bool IsDeleted { get; set; }
    }
}