using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TwinShop.DAL.Entities;

namespace Twin_Shop__Web_API.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        [Required]
        public string? ProductName { get; set; }

        [Range(0,int.MaxValue)]
        [Required]
        public int InitialPrice { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int SecondryPrice { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(2000)]
        [Required]
        public string? Description { get; set; }

        [Required]
        public string? MainImageUrl { get; set; }

        public ICollection<ProductSideImage>? SideImages { get; set; }

        public int SoldNumber { get; set; } = 0;

        [Required]
        public int NumberInStorage {  get; set; }

        [StringLength(50)]
        [Required]
        public string? BrandName { get; set; }

        [StringLength(50)]
        [Required]
        public string? CategoryName { get; set; }

        public int? CategoryId { get; set; }

        public int AveScoreOfUsers { get; set; }

        public Brand? Brand { get; set; }

        public int? BrandId { get; set; }

        public bool IsDeleted { get; set;} = false;

    }
}
