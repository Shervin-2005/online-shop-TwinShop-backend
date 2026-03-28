using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<OperationResult> InsertAsync(BrandDto brandDto);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult> UpdateAsync(BrandDto brandDto, int id);
        Task<OperationResult<List<BrandDto>>> GetBrandsByNameAsync(string brandName);
        Task<OperationResult<List<BrandDto>>> GetBrandsByCategoryNameAsync(string categoryName);
        Task<OperationResult<BrandDto>> GetByIdAsync(int brandId);
        Task<OperationResult<List<BrandDto>>> GetAllAsync();

    }
}
