using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels.Base;

namespace TwinShop.Shared.ViewModels
{
    public class BrandViewModel:BaseValidatoin
    {
       
        [Required(ErrorMessage = Messages.BrandName)]
        public string BrandName { get; set; }

        [Required(ErrorMessage = Messages.BrandPhoto)]
        public string MainImage { get; set; }

        [Required(ErrorMessage = Messages.BrandCategoryName)]
        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = Messages.BrandCategoryId)]
        public int CategoryId { get; set; }

    }
}
