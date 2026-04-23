using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IBrandService
    {
        Task<OperationResult<List<BrandViewModel>>> GetAllBrandsAsync();
        Task<OperationResult<BrandDto>> GetBrandByIdAsync(int id);
        Task<OperationResult<List<BrandDto>>> GetBrandsByNameAsync(string name);
        Task<OperationResult<List<BrandDto>>> GetBrandsByCategoryNameAsync(string categoryName);
        Task<OperationResult> CreateBrandAsync(BrandViewModel brandView);
        Task<OperationResult> DeleteBrandAsync(int id);
        Task<OperationResult> UpdateBrandAsync(BrandViewModel brandView, int id);
        Task<OperationResult<List<BrandViewModel>>> SearchBrandsAsync(string searchTerm);
    }
}