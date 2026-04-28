using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Twin_Shop__Web_API.DTOs.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? BrandName { get; set; }
        public int? BrandID { get; set; }
        public int? BrandId { get; set; }
        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string? MainImageUrl { get; set; }
        public List<string>? SideImageUrls { get; set; }
        public int NumberInStorage { get; set; }
        public int InitialPrice { get; set; }
        public int SecondryPrice { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        
    }
}
