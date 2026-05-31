using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Entities
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        public Product? Product { get; set; }

        [Required]
        [Range(0, 10)]
        public int DisplayOrder { get; set; }

        public bool IsMainImage {  get; set; } = false; 

        public bool IsDeleted { get; set; } = false;
    }
}
