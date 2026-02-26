// CategoryDto.cs
using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Category
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
    }

    // CreateCategoryDto.cs
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }

    public class DeleteCategoryDto
    {
        [Required]
        public int CategoryId { get; set; }
    }

    public class UpdateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}