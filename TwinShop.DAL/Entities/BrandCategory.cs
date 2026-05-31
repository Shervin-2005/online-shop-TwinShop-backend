using System.ComponentModel.DataAnnotations;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Entities
{
    public class BrandCategory
    {
        [Required]
        public Brand Brand { get; set; } = null!;

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

    }
}
