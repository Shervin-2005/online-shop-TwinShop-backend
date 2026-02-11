// BrandDto.cs
using System.ComponentModel.DataAnnotations;
namespace Twin_Shop__Web_API.DTOs.Brand
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
    }

    // CreateBrandDto.cs
    public class CreateBrandDto
    {
        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}