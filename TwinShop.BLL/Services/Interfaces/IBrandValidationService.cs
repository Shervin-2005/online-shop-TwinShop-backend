using TwinShop.Shared.ViewModels;

namespace TwinShop.BLL.Services.Interfaces
{
    public interface IBrandValidationService
    {
        Task ValidateBrandAsync(BrandViewModel brandViewModel);
    }
}
