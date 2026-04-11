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
       
        [Required(ErrorMessage = MessagesAndConsts.BrandName)]
        public string BrandName { get; set; }

        [Required(ErrorMessage = MessagesAndConsts.BrandPhoto)]
        public string MainImage { get; set; }

        [Required(ErrorMessage = MessagesAndConsts.BrandCategoryName)]
        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = MessagesAndConsts.BrandCategoryId)]
        public int CategoryId { get; set; }

    }
}
