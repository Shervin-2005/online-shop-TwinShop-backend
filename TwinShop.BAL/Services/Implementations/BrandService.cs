using AutoMapper;
using Microsoft.EntityFrameworkCore;
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


        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<List<BrandDto>>(brands);
        }

        public async Task<BrandDto> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return null;

            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<BrandDto> CreateBrandAsync(CreateBrandDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);
            await _brandRepository.InsertAsync(brand);
            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                return false;

            return await _brandRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var brand= _mapper.Map<Brand>(updateBrandDto);
            return await _brandRepository.UpdateAsync(brand);
        }

        public async Task<List<BrandDto?>> GetBrandByNameAsync(string name)
        {
           var brands= await _brandRepository.GetBrandsByNameAsync(name);
            return _mapper.Map<List<BrandDto>>(brands)!;
        }

        public async Task<List<BrandDto?>> GetBrandsByCategoryNameAsync(string categoryName)
        {
            var brands=await _brandRepository.GetBrandsByCategoryNameAsync(categoryName);
            return _mapper.Map<List<BrandDto>>(brands)!;
        }
    }

}
