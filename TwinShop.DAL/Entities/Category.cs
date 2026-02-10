using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }

        public ICollection<Brand> Brands { get; set; } = new List<Brand>();
        public bool IsDeleted { get; set; } = false;

    }
}
