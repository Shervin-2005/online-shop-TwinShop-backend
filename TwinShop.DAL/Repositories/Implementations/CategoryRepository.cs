using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Data;
using TwinShop.DAL.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;


        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _dbContext.Categories
               .Include(bc => bc.BrandCategories)
               .FirstOrDefaultAsync(c => c.CategoryId == id && !c.IsDeleted);

                if (category == null) return false;

                category.IsDeleted = true;

                if (category.BrandCategories?.Any() == true)
                {
                    foreach (var bc in category.BrandCategories.Where(bc => !bc.IsDeleted))
                    {
                        bc.IsDeleted = true;
                    }
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to delete categoty.", ex);
            }
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Categories
               .AsNoTracking()
               .Where(b => !b.IsDeleted)
               .Select(b => new CategoryDto
               {
                   CategoryId = b.CategoryId,
                   CategoryName = b.CategoryName,
                   MainImageUrl = b.MainImageUrl,
                   BrandIds = b.BrandCategories!
                    .Where(bc => !bc.IsDeleted)
                        .Select(bc => bc.BrandId)
                        .ToList()
               })
               .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve categories.", ex);
            }
        }
        public async Task<CategoryDto?> GetByIdAsync(int categoryId)
        {
            try
            {
                return await _dbContext.Categories

               .AsNoTracking()
               .Where(b => b.CategoryId == categoryId && !b.IsDeleted)
               .Select(b => new CategoryDto
               {
                   CategoryId = b.CategoryId,
                   CategoryName = b.CategoryName,
                   MainImageUrl = b.MainImageUrl,
                   BrandIds = b.BrandCategories!
                       .Where(bc => !bc.IsDeleted)
                       .Select(bc => bc.BrandId)
                       .ToList()
               })
               .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve category", ex);
            }

        }

        public async Task<List<CategoryDto>> SearchCategoriesAsync(string categoryName)
        {
            try
            {
                return await _dbContext.Categories
               .AsNoTracking()
               .Where(b => !b.IsDeleted && b.CategoryName.ToLower().Contains(categoryName.ToLower()))
               .Select(b => new CategoryDto
               {
                   CategoryId = b.CategoryId,
                   CategoryName = b.CategoryName,
                   MainImageUrl = b.MainImageUrl,
                   BrandIds = b.BrandCategories!
                      .Where(bc => !bc.IsDeleted)
                      .Select(bc => bc.BrandId)
                      .ToList()
               })
               .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to search category.", ex);
            }
        }

        public async Task<int> InsertAsync(CategoryDto categoryDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var category = new Category
                {
                    CategoryName = categoryDto.CategoryName!,
                    MainImageUrl = categoryDto.MainImageUrl!,
                    IsDeleted = false
                };

                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();

                if (categoryDto.BrandIds != null && categoryDto.BrandIds.Any())
                {
                    var brandCategories = categoryDto.BrandIds
                        .Select(brandId => new BrandCategory
                        {
                            CategoryId = category.CategoryId,
                            BrandId = brandId
                        })
                        .ToList();

                    _dbContext.BrandCategories.AddRange(brandCategories);
                    await _dbContext.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return category.CategoryId;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                await transaction.RollbackAsync();
                throw new DatabaseException("Failed to create category", ex);
            }
        }

        public async Task<bool> UpdateAsync(CategoryDto categoryDto, int id)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.Where(c => c.CategoryId == id && !c.IsDeleted)
                .FirstOrDefaultAsync();

                if (existingCategory == null) return false;

                existingCategory.CategoryName = categoryDto.CategoryName!;
                existingCategory.MainImageUrl = categoryDto.MainImageUrl!;

                var oldRelations = await _dbContext.BrandCategories
                    .Where(bc => bc.CategoryId == id)
                    .ToListAsync();

                _dbContext.BrandCategories.RemoveRange(oldRelations);

                if (categoryDto.BrandIds != null && categoryDto.BrandIds.Any())
                {
                    var newRelations = categoryDto.BrandIds
                        .Select(brandId => new BrandCategory
                        {
                            CategoryId = id,
                            BrandId = brandId

                        })
                        .ToList();

                    _dbContext.BrandCategories.AddRange(newRelations);
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to update category.", ex);
            }
        }
        public async Task<bool> CategoryNameExistsAsync(string categoryName)
        {
            try
            {
                return await _dbContext.Categories
                .AsNoTracking()
                .AnyAsync(b => !b.IsDeleted && b.CategoryName.ToLower() == categoryName.ToLower());
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to check category name.", ex);
            }
        }

        public async Task<int?> GetCategoryIdByNameAsync(string categoryName)
        {
            try
            {
                return await _dbContext.Categories
                .AsNoTracking()
                .Where(b => !b.IsDeleted && b.CategoryName.ToLower() == categoryName.ToLower())
                .Select(b => b.CategoryId)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve category id.", ex);
            }
        }

        public async Task<bool> CategoryIdExistsAsync(int categoryId)
        {
            try
            {
                return await _dbContext.Categories
                .AsNoTracking()
                .AnyAsync(b => !b.IsDeleted && b.CategoryId == categoryId);
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to check category id.", ex);
            }
        }
    }
}
