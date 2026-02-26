// BrandDto.cs
using System.ComponentModel.DataAnnotations;
namespace Twin_Shop__Web_API.DTOs.Brand
{
    public class BrandDto
    {
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
    public class DeleteBrandDto
    {
        [Required]
        public int BrandId { get; set; }
    }

    public class UpdateBrandDto
    {
        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}