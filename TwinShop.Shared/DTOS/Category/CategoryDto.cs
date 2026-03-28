// CategoryDto.cs
using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Category
{
    public class CategoryDto
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        
        [Required]
        public string MainImage { get; set; }

        public bool IsDeleted { get; set; }

    }
}