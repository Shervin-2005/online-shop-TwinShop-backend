using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

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
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            return false; 
            
            category.IsDeleted = true;

            _dbContext.Entry(category).Property(c => c.IsDeleted).IsModified = true;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllAsync()
        {
                return await _dbContext.Categories.ToListAsync();   
        }

        public async Task<Category> GetByIdAsync(int CategoryId)
        {
            var category = await _dbContext.Categories.Where(x => x.CategoryId == CategoryId).FirstAsync();
            return category;
        }

        public async Task<List<Category?>> GetCategoriesByNameAsync(string CategoryName)
        {
            var result = await _dbContext.Categories.Where(x => x.CategoryName.Contains(CategoryName) && x.IsDeleted == false).Select(x => new Category
            {
                CategoryName = x.CategoryName,
            }).ToListAsync();
            return result;
        }
         
        public async Task<bool> InsertAsync(Category category)
        {
            try
            {
                _dbContext.Add(category);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                var existing = await _dbContext.Categories.FindAsync(category.CategoryId);
                if (existing == null) return false;
                existing.CategoryName = category.CategoryName;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
