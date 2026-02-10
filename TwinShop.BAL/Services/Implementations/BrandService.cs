using AutoMapper;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Repositories.Interfaces;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
namespace Twin_Shop__Web_API.Services.Implementations;

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
        if (brand == null)
           return null;

        var bradbsDTO = new BrandDto
        {
            BrandId = brand.BrandId,
            BrandName = brand.BrandName,
            CategoryId = brand.CategoryId
        };
        //var bradbsDTO=brand.Select(x=>new BrandDto()
        //{
        //    BrandId=x.BrandId,
        //    BrandName=x.BrandName,
        //    CategoryId=x.CategoryId
        //}).ToList();
        return bradbsDTO;
    }

    public async Task<BrandDto> CreateBrandAsync(CreateBrandDto dto)
    {
        var brand = _mapper.Map<Brand>(dto);
        await _brandRepository.InsertAsync(brand);
        return _mapper.Map<BrandDto>(brand);
    }
}
