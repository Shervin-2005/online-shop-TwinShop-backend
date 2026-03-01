using AutoMapper;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
namespace Twin_Shop__Web_API.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandService> _logger;

        public BrandService(IBrandRepository brandRepository, IMapper mapper,ILogger<BrandService> logger)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<BrandDto>> GetAllBrandsAsync()
        {
            try
            {
                var brands = await _brandRepository.GetAllAsync();
                return _mapper.Map<List<BrandDto>>(brands);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all brands.");
                throw;
            }
        }

        public async Task<BrandDto> GetBrandByIdAsync(int id)
        {
            try
            {
                var brand = await _brandRepository.GetByIdAsync(id);
                if (brand != null) return _mapper.Map<BrandDto>(brand);
                else
                {
                    _logger.LogError("No brand found with BrandId: {BrandId}", id);
                    throw new Exception("No brand found with the provided BrandId");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting brand by ID: {Id}", id);
                throw;
            }
        }

        public async Task<BrandDto> CreateBrandAsync(CreateBrandDto dto)
        {
            try 
            {
                var brand = _mapper.Map<Brand>(dto);
                await _brandRepository.InsertAsync(brand);
                return _mapper.Map<BrandDto>(brand);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new brand.");
                throw;
            }
           
        }
        public async Task<bool> DeleteBrandAsync(int id)
        {
            try
            {
                var brand = await _brandRepository.GetByIdAsync(id);
                if (brand != null) return await _brandRepository.DeleteAsync(id);
                else return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting brand by ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            try
            {
                var brand = _mapper.Map<Brand>(updateBrandDto);
                return await _brandRepository.UpdateAsync(brand);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating brand.");
                throw;
            }
        }

        public async Task<List<BrandDto?>> GetBrandByNameAsync(string name)
        {
            try
            {
                var brands = await _brandRepository.GetBrandsByNameAsync(name);
                return _mapper.Map<List<BrandDto>>(brands)!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting brands by name: {Name}", name);
                throw;
            }
        }

        public async Task<List<BrandDto?>> GetBrandsByCategoryNameAsync(string categoryName)
        {
             try
             {
                var brands = await _brandRepository.GetBrandsByCategoryNameAsync(categoryName);
                return _mapper.Map<List<BrandDto>>(brands)!;
             }
             catch (Exception ex)
             {
                _logger.LogError(ex, "Error occurred while getting products by category name: {CategoryName}", categoryName);
                throw;
             }
        }
    }

}
