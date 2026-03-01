using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(AppDbContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(id);
                if (category == null)
                {
                    _logger.LogWarning("Category not found with ID: {Id}", id);
                    return false;
                }

                category.IsDeleted = true;

                _dbContext.Entry(category).Property(c => c.IsDeleted).IsModified = true;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error deleting category with ID: {Id}", id);
                throw new Exception("Failed to delete category", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error deleting category with ID: {Id}", id);
                throw;
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Categories.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting all categories");
                throw new Exception("Failed to get all categories", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting all categories");
                throw;
            }
        }

        public async Task<Category> GetByIdAsync(int CategoryId)
        {
            try
            {
                var category = await _dbContext.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefaultAsync();
                return category;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting category by ID: {CategoryId}", CategoryId);
                throw new Exception("Failed to get category by ID", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting category by ID: {CategoryId}", CategoryId);
                throw;
            }
        }

        public async Task<List<Category>> GetCategoriesByNameAsync(string CategoryName)
        {
            try
            {
                var result = await _dbContext.Categories.Where(x => x.CategoryName.Contains(CategoryName) && !x.IsDeleted).Select(x => new Category
                {
                    CategoryName = x.CategoryName,
                }).ToListAsync();
                return result;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting categories by name: {CategoryName}", CategoryName);
                throw new Exception("Failed to get categories by name", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting categories by name: {CategoryName}", CategoryName);
                throw;
            }
        }

        public async Task<bool> InsertAsync(Category category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error inserting category: {Category}", category);
                throw new Exception("Failed to insert category", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error inserting category: {Category}", category);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                var existing = await _dbContext.Categories.FindAsync(category.CategoryId);
                if (existing == null)
                {
                    _logger.LogWarning("Category not found with ID: {CategoryId}", category.CategoryId);
                    return false;
                }

                existing.CategoryName = category.CategoryName;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating category: {Category}", category);
                throw new Exception("Failed to update category", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error updating category: {Category}", category);
                throw;
            }
        }
    }
}
