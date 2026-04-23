using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.DTOS.Product
{
    public class ProductSideImageDto
    {
        public int SideImageId { get; set; }

        public string? SideImageUrl { get; set; }

        public int ProductId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
