using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;


        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            try
            {
                var category = new Category { CategoryId = id };
                _dbContext.Attach(category);
                category.IsDeleted= true;
                _dbContext.Entry(category).Property(c => c.IsDeleted).IsModified=true;
                 await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();       
            }
           
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<CategoryDto>>> GetAllAsync()
        {
            try
            {
                var categories = await _dbContext.Categories.AsNoTracking()
                    .Where(c => c.IsDeleted == false).Select(c => new CategoryDto
                    {
                        CategoryName = c.CategoryName,
                        MainImage = c.MainImage,

                    }).ToListAsync();
                return OperationResult<List<CategoryDto>>.SuccessedResult(categories);
            }
            catch (Exception ex)
            {
                return OperationResult<List<CategoryDto>>.Failed(GetType().Name, ex);
            }
        }
        public async Task<OperationResult<CategoryDto>> GetByIdAsync(int CategoryId)
        {
            try
            {
                var category = await _dbContext.Categories.AsNoTracking().Where(c => c.CategoryId == CategoryId && c.IsDeleted == false).
                    Select(c => new CategoryDto
                    {
                        CategoryName = c.CategoryName,
                        MainImage = c.MainImage,

                    }).FirstAsync();
                return OperationResult<CategoryDto>.SuccessedResult(category);
            }
            catch (Exception ex)
            {
                return OperationResult<CategoryDto>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<CategoryDto>>> GetCategoriesByNameAsync(string CategoryName)
        {
            try
            {
                var categories = await _dbContext.Categories.AsNoTracking().Where(c => c.CategoryName == CategoryName && c.IsDeleted == false)
                    .Select(c => new CategoryDto
                    {
                        CategoryName = c.CategoryName,
                        MainImage = c.MainImage,
                    }).ToListAsync();
                return OperationResult<List<CategoryDto>>.SuccessedResult(categories);
            }
            catch (Exception ex)
            {
                return OperationResult<List<CategoryDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> InsertAsync(CategoryDto categoryDto)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = categoryDto.CategoryName,
                    MainImage = categoryDto.MainImage,
                };
                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> UpdateAsync(CategoryDto categoryDto,int id)
        {
            try
            {
                var existing = await _dbContext.Categories.Where(c => c.CategoryId == id).FirstAsync();

               existing.CategoryName = categoryDto.CategoryName;
                existing.MainImage= categoryDto.MainImage;
                existing.IsDeleted = categoryDto.IsDeleted;
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult(); ;
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }
}
