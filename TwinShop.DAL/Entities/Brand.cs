using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }

        [StringLength(50)]
        [Required]
        public string BrandName { get; set; }

        public int CategoryId {  get; set; }

        [Required]
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public bool IsDeleted { get; set; } = false;

    }
}
