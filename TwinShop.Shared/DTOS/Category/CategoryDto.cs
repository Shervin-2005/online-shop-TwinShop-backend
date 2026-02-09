// CategoryDto.cs
using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    // CreateCategoryDto.cs
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}