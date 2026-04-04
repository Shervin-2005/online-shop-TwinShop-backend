// CategoryDto.cs
using System.ComponentModel.DataAnnotations;

namespace Twin_Shop__Web_API.DTOs.Category
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }

        
        public string MainImage { get; set; }

        public bool IsDeleted { get; set; }

    }
}