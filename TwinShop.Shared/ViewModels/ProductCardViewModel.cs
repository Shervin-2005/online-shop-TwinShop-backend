using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.CustomAtribute;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels.Base;

namespace TwinShop.Shared.ViewModels
{
    public class ProductCardViewModel:BaseValidatoin
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage=MessagesAndConsts.ProductName)]
        public string? ProductName { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        [ProductNumberValidation]
        public int NumberInStorage { get; set; }

        [InitialPriceValidation]
        public decimal InitialPrice { get; set; }

        [SecondryPriceValidationAtribute]
        public decimal SecondaryPrice { get; set; }

        [Required(ErrorMessage = "Please upload an image at least")]
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        [Required(ErrorMessage = MessagesAndConsts.ProductDescription)]
        [StringLength(2000, ErrorMessage = MessagesAndConsts.ProductDescriptionLength)]
        public string? Description { get; set; }
        
        public bool IsDeleted { get; set; } = false;
    }
}
