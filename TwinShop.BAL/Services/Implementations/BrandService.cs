
using AutoMapper;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Repositories.Interfaces;
using Twin_Shop__Web_API.Services.Interfaces;
namespace Twin_Shop__Web_API.Services.Implementations;

public class BrandService : IBrandService
{
    private readonly IGenericRepository<Brand> _brandRepository;
    private readonly IMapper _mapper;

    public BrandService(IGenericRepository<Brand> brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<List<BrandDto>> GetAllBrandsAsync()
    {
        var brands = await _brandRepository.GetAllAsync();
        return _mapper.Map<List<BrandDto>>(brands);
    }

    public async Task<BrandDto?> GetBrandByIdAsync(int id)
    {
        var brand = await _brandRepository.GetByIdAsync(id);
        if (brand == null) return null;

        return _mapper.Map<BrandDto>(brand);
    }

    public async Task<BrandDto> CreateBrandAsync(CreateBrandDto dto)
    {
        var brand = _mapper.Map<Brand>(dto);
        await _brandRepository.AddAsync(brand);
        await _brandRepository.SaveAsync();
        return _mapper.Map<BrandDto>(brand);
    }
}
