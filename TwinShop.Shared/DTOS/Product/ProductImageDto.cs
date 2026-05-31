using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.DTOS.Product
{
    public class ProductImageDto
    {
        public int ImageId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int ProductId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsMainImage { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
    }
}
