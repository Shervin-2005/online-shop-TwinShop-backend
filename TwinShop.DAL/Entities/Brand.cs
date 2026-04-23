using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Twin_Shop__Web_API.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }


        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required]
        public string BrandName { get; set; }

        
        [Required]
        public string MainImage {  get; set; }

        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public bool IsDeleted { get; set; } = false;

    }
}
