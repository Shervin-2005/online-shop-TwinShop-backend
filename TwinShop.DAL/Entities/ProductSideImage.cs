using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Entities
{
    public class ProductSideImage
    {
        [Key]
        public int SideImageId { get; set; }

        [Required]
        public string? SideImageUrl { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
