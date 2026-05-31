using System.ComponentModel.DataAnnotations;
namespace Twin_Shop__Web_API.DTOs.Brand
{
    public class BrandDto
    {

        public int BrandId { get; set; }

        public string? BrandName { get; set; }

        public string? MainImageUrl { get; set; }

        public List<int> CategoryIds { get; set; } = null!;

        public bool IsDeleted { get; set; }

    }
}