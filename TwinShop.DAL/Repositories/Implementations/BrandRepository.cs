using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Data;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _dbContext;

        public BrandRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            try
            {
                var brand = new Brand { BrandId = id };
                _dbContext.Attach(brand);
                brand.IsDeleted = true;
                _dbContext.Entry(brand).Property(b => b.IsDeleted).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<BrandDto>> GetByIdAsync(int brandId)
        {
            try
            {
                var brand = await _dbContext.Brands.AsNoTracking().Where(b => b.BrandId == brandId && b.IsDeleted == false).
                    Select(b => new BrandDto
                    {
                       BrandName = b.BrandName,
                       MainImage = b.MainImage,
                       CategoryName = b.CategoryName,
                       CategoryId = b.CategoryId,
                    }).FirstAsync();
                return OperationResult<BrandDto>.SuccessedResult(brand);
            }
            catch (Exception ex)
            {
                return OperationResult<BrandDto>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> InsertAsync(BrandDto brandDto)
        {
            try
            {
                Brand brand = new Brand
                {
                    BrandName = brandDto.BrandName!,
                    MainImage = brandDto.MainImage!,
                    CategoryName = brandDto.CategoryName!,
                    CategoryId =brandDto.CategoryId,
                };
                _dbContext.Brands.Add(brand);
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> UpdateAsync(BrandDto brandDto, int id)
        {
            try
            {
                var existing = await _dbContext.Brands.Where(b => b.BrandId == id).FirstAsync();

                existing.BrandName = brandDto.BrandName!;
                existing.MainImage = brandDto.MainImage!;
                existing.CategoryName = brandDto.CategoryName!;
                existing.CategoryId = brandDto.CategoryId;
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult(); ;
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<BrandDto>>> GetAllAsync()
        {
            try
            {
                var brands = await _dbContext.Brands.AsNoTracking()
                    .Where(b => b.IsDeleted == false).Select(b => new BrandDto
                    {
                        BrandId = b.BrandId,
                        BrandName = b.BrandName,
                        MainImage = b.MainImage,
                        CategoryName = b.CategoryName,
                        CategoryId = b.CategoryId,
                    }).ToListAsync();
                return OperationResult<List<BrandDto>>.SuccessedResult(brands);
            }
            catch (Exception ex)
            {
                return OperationResult<List<BrandDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<BrandDto>>> GetBrandsByCategoryNameAsync(string categoryName)
        {
            try
            {
                var brands = await _dbContext.Brands.AsNoTracking().Where(b => b.CategoryName == categoryName && b.IsDeleted == false)
                   .Select(b => new BrandDto
                   {
                       BrandName = b.BrandName,
                       MainImage = b.MainImage,
                       CategoryName = b.CategoryName,
                       CategoryId = b.CategoryId,
                   }).ToListAsync();
                return OperationResult<List<BrandDto>>.SuccessedResult(brands);
            }
            catch (Exception ex)
            {
                return OperationResult<List<BrandDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<BrandDto>>> GetBrandsByNameAsync(string brandName)
        {

            try
            {
                var brands = await _dbContext.Brands.AsNoTracking().Where(b => b.BrandName.Contains(brandName) && b.IsDeleted == false)
                   .Select(b => new BrandDto
                   {
                       BrandName = b.BrandName,
                       MainImage = b.MainImage,
                       CategoryName = b.CategoryName,
                       CategoryId = b.CategoryId,
                   }).ToListAsync();
                return OperationResult<List<BrandDto>>.SuccessedResult(brands);
            }
            catch (Exception ex)
            {
                return OperationResult<List<BrandDto>>.Failed(GetType().Name, ex);
            }
        }
        public async Task<OperationResult<int>> GetBrandByNameAsync(string brandName)
        {
            try
            {
                var brandId = await _dbContext.Brands.AsNoTracking().
                     Where(b => b.BrandName == brandName && b.IsDeleted == false)
                     .Select(b => b.BrandId)
                     .FirstOrDefaultAsync();
                return OperationResult<int>.SuccessedResult(brandId!);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> BrandNameExist(string Name)
        {
            var user = await _dbContext.Brands.Where(x => x.BrandName == Name).FirstOrDefaultAsync();

            return user != null ? OperationResult.SuccessedResult() : OperationResult<UserDto>.Failed();
        }
        public async Task<OperationResult<List<BrandDto>>> SearhBrandByName(string searchTerm)
        {
            try
            {
                var brands = await _dbContext.Brands
                    .AsNoTracking()
                    .Where(c => c.IsDeleted == false &&
                                 c.BrandName!.Contains(searchTerm))
                    .Select(c => new BrandDto
                    {
                        BrandId = c.BrandId,
                        BrandName= c.BrandName,
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        MainImage = c.MainImage,
                    })
                    .ToListAsync();

                return OperationResult<List<BrandDto>>.SuccessedResult(brands);
            }
            catch (Exception ex)
            {
                return OperationResult<List<BrandDto>>.Failed(GetType().Name, ex);
            }
        }
    }
}
