using TwinShop.Shared.ViewModels;

namespace TwinShop.BLL.Services.Interfaces
{
    public interface ICategoryValidationService
    {
        Task ValidateCategoryAsync(CategoryViewModel categoryViewModel);
    }
}
