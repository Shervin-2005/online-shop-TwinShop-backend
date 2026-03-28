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
    public class ProductViewModel:BaseValidatoin
    {
        [Required(ErrorMessage=Messages.ProductName)]
        public string ProductName { get; set; }
        [Required(ErrorMessage=Messages.ProductBrandName)]
        public string BrandName { get; set; }
        [Required(ErrorMessage = Messages.ProductBrandId)]
        public int BrandId { get; set; }
        [Required(ErrorMessage = Messages.ProductCategoryName)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = Messages.ProductPhoto)]
        public string? MainImage { get; set; }
        [ProductNumberValidation]
        public int NumberInStorage { get; set; }
        [InitialPriceValidation]
        public int InitialPrice { get; set; }
        [SecondryPriceValidationAtribute]
        public int SecondryPrice { get; set; }
        [Required(ErrorMessage = Messages.ProductDescription)]
        [StringLength(2000, ErrorMessage = Messages.ProductDescriptionLength)]
        public string Description { get; set; }     
        public bool IsDeleted { get; set; } = false;
    }
}
