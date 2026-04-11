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
    public class CategoryViewModel:BaseValidatoin
    {

        [Required(ErrorMessage = MessagesAndConsts.CategoryName)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = MessagesAndConsts.CategoryPhoto)]
        public string MainImage { get; set; }

        public bool IsDeleted { get; set; }
    }
}
