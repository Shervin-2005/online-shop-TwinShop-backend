using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.ViewModels;

namespace TwinShop.BLL.Services.Interfaces
{
    public interface IProductValidationService
    {
        Task ValidateProductAsync(ProductCardViewModel productCardViewModel);
    }
}
