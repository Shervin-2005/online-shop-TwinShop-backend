using Twin_Shop__Web_API.DTOs.Brand;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllBrandsAsync();
        Task<BrandDto?> GetBrandByIdAsync(int id);
        Task<BrandDto> CreateBrandAsync(CreateBrandDto dto);
    }
}