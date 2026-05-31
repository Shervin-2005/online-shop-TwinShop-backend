using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Twin_Shop__Web_API.DTOs.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public List<string>? ImageUrls { get; set; }
        public int NumberInStorage { get; set; }
        public decimal InitialPrice { get; set; }
        public decimal SecondaryPrice { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        
    }
}
