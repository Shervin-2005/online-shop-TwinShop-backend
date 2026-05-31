using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandViewModel>> GetAllBrandsAsync();
        Task<BrandViewModel> GetBrandByIdAsync(int id);
        Task<List<BrandViewModel>> GetBrandsByCategoryNameAsync(string categoryName);
        Task<int> CreateBrandAsync(BrandViewModel brandViewModel);
        Task DeleteBrandAsync(int id);
        Task UpdateBrandAsync(BrandViewModel brandViewModel, int id);
        Task<List<BrandViewModel>> SearchBrandsAsync(string searchTerm);
    }
}