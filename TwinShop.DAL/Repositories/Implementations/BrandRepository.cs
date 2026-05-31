using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Data;
using TwinShop.DAL.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _dbContext;

        public BrandRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var brand = await _dbContext.Brands
              .Include(b => b.BrandCategories)
              .FirstOrDefaultAsync(b => b.BrandId == id && !b.IsDeleted);

                if (brand == null) return false;

                brand.IsDeleted = true;

                if (brand.BrandCategories?.Any() == true)
                {
                    foreach (var bc in brand.BrandCategories.Where(bc => !bc.IsDeleted))
                    {
                        bc.IsDeleted = true;
                    }
                }

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to delete brand.", ex);
            }
        }
        public async Task<BrandDto?> GetByIdAsync(int brandId)
        {
            try
            {
                return await _dbContext.Brands
                .AsNoTracking()
                .Where(b => b.BrandId == brandId && !b.IsDeleted)
                .Select(b => new BrandDto
                {
                    BrandId = b.BrandId,
                    BrandName = b.BrandName,
                    MainImageUrl = b.MainImageUrl,
                    CategoryIds = b.BrandCategories
                        .Where(bc => !bc.IsDeleted)
                        .Select(bc => bc.CategoryId)
                        .ToList()
                })
                .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve brand", ex);
            }
        }

        public async Task<int> InsertAsync(BrandDto brandDto)
        {
           await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var brand = new Brand
                {
                    BrandName = brandDto.BrandName!,
                    MainImageUrl = brandDto.MainImageUrl!,
                    IsDeleted = false
                };

                _dbContext.Brands.Add(brand);

                await _dbContext.SaveChangesAsync();

                if (brandDto.CategoryIds != null && brandDto.CategoryIds.Any())
                {
                    var brandCategories = brandDto.CategoryIds
                        .Select(categoryId => new BrandCategory
                        {
                            BrandId = brand.BrandId,
                            CategoryId = categoryId
                        })
                        .ToList();

                    _dbContext.BrandCategories.AddRange(brandCategories);
                    await _dbContext.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return brand.BrandId;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                await transaction.RollbackAsync();
                throw new DatabaseException("Failed to create brand", ex);
            }
        }

        public async Task<bool> BrandNameExistsAsync(string brandName)
        {
            try
            {
                return await _dbContext.Brands
              .AsNoTracking()
              .AnyAsync(b => !b.IsDeleted && b.BrandName.ToLower() == brandName.ToLower());
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to check brand name.", ex);
            }
        }

        public async Task<bool> UpdateAsync(BrandDto brandDto, int id)
        {
            try
            {
                var existingBrand = await _dbContext.Brands.Where(b => b.BrandId == id && !b.IsDeleted)
                .FirstOrDefaultAsync();

                if (existingBrand == null) return false;

                existingBrand.BrandName = brandDto.BrandName!;
                existingBrand.MainImageUrl = brandDto.MainImageUrl!;

                var oldRelations = await _dbContext.BrandCategories
                    .Where(bc => bc.BrandId == id && !bc.IsDeleted)
                    .ToListAsync();

                _dbContext.BrandCategories.RemoveRange(oldRelations);

                if (brandDto.CategoryIds != null && brandDto.CategoryIds.Any())
                {
                    var newRelations = brandDto.CategoryIds
                        .Select(categoryId => new BrandCategory
                        {
                            BrandId = id,
                            CategoryId = categoryId
                        })
                        .ToList();

                    _dbContext.BrandCategories.AddRange(newRelations);
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to update brand.", ex);
            }
        }

        public async Task<List<BrandDto>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Brands
                .AsNoTracking()
                .Where(b => !b.IsDeleted)
                .Select(b => new BrandDto
                {
                    BrandId = b.BrandId,
                    BrandName = b.BrandName,
                    MainImageUrl = b.MainImageUrl,
                    CategoryIds = b.BrandCategories
                        .Where(bc => !bc.IsDeleted)
                        .Select(bc => bc.CategoryId)
                        .ToList()
                })
                .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve brands.", ex);
            }
        }

        public async Task<List<BrandDto>> GetBrandsByCategoryNameAsync(string categoryName)
        {
            try
            {
                 return await _dbContext.Brands
                .AsNoTracking()
                .Where(b => !b.IsDeleted &&
                            b.BrandCategories.Any(bc =>
                                !bc.IsDeleted &&
                                bc.Category != null &&
                                !bc.Category.IsDeleted &&
                                bc.Category.CategoryName.ToLower() == categoryName.ToLower()))
                .Select(b => new BrandDto
                {
                    BrandId = b.BrandId,
                    BrandName = b.BrandName,
                    MainImageUrl = b.MainImageUrl,
                    CategoryIds = b.BrandCategories
                        .Where(bc => !bc.IsDeleted)
                        .Select(bc => bc.CategoryId)
                        .ToList()
                })
                .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to find brands.", ex);
            }
        }

        public async Task<List<BrandDto>> SearchBrandsAsync(string searchTerm)
        {
            try
            {
                return await _dbContext.Brands
                .AsNoTracking()
                .Where(b => !b.IsDeleted && b.BrandName.ToLower().Contains(searchTerm.ToLower()))
                .Select(b => new BrandDto
                {
                    BrandId = b.BrandId,
                    BrandName = b.BrandName,
                    MainImageUrl = b.MainImageUrl,
                    CategoryIds = b.BrandCategories
                        .Where(bc => !bc.IsDeleted)
                        .Select(bc => bc.CategoryId)
                        .ToList()
                })
                .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to search brand.", ex);
            }
        }

        public async Task<int?> GetBrandIdByNameAsync(string brandName)
        {
            try
            {
                return await _dbContext.Brands
             .AsNoTracking()
             .Where(b => !b.IsDeleted && b.BrandName.ToLower() == brandName.ToLower())
             .Select(b => b.BrandId)
             .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve brand id.", ex);
            }
        }

        public async Task<bool> BrandIdExistsAsync(int brandId)
        {
            try
            {
                return await _dbContext.Brands
                .AsNoTracking()
                .AnyAsync(b => !b.IsDeleted && b.BrandId == brandId);
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to check brand id.", ex);
            }
        }

    }
}