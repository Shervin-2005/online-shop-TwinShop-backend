// BrandDto.cs
using System.ComponentModel.DataAnnotations;
namespace Twin_Shop__Web_API.DTOs.Brand
{
    public class BrandDto
    {
        [StringLength(50)]
        [Required]
        public string BrandName { get; set; }

        [Required]
        public string MainImage { get; set; }

        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public int CategoryId {  get; set; }

    }
}
