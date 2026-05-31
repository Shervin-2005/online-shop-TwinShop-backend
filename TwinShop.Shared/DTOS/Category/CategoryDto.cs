// CategoryDto.cs
using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        
        public string? MainImageUrl { get; set; }

        public List<int> BrandIds { get; set; } = null!;

        public bool IsDeleted { get; set; }

    }
}