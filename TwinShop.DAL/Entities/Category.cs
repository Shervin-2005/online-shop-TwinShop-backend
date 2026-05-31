using System.ComponentModel.DataAnnotations;
using TwinShop.DAL.Entities;

namespace Twin_Shop__Web_API.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string MainImageUrl { get; set; } = null!;

        public ICollection<BrandCategory>? BrandCategories { get; set; }

        public ICollection<Product>? Products { get; set; }

        public bool IsDeleted { get; set; }

    }
}