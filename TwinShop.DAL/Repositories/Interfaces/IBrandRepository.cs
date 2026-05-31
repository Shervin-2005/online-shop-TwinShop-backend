using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<bool> DeleteAsync(int id);
        Task<BrandDto?> GetByIdAsync(int brandId);
        Task<int> InsertAsync(BrandDto brandDto);
        Task<bool> UpdateAsync(BrandDto brandDto, int id);
        Task<List<BrandDto>> GetAllAsync();
        Task<List<BrandDto>> GetBrandsByCategoryNameAsync(string categoryName);
        Task<List<BrandDto>> SearchBrandsAsync(string brandName);
        Task<int?> GetBrandIdByNameAsync(string brandName);
        Task<bool> BrandNameExistsAsync(string brandName);
        Task<bool> BrandIdExistsAsync(int brandId);
    }
}