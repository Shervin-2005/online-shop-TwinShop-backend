using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

namespace TwinShop.DAL.Repositories.Implementations
{
    internal class CategoryRepository : ICategoryRepository
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
                var category = new Category { CategoryId = id };
                _dbContext.Attach(category);
                category.IsDeleted = true;
                var entry = _dbContext.Entry(category);
                entry.Property(x => x.IsDeleted).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetCategoriesByNameAsync(string CategoryName)
        {
            var result = await _dbContext.Categories.Where(x => x.CategoryName!.Contains(CategoryName) && x.IsDeleted == false).Select(x => new Category
            {
                CategoryId = x.CategoryId
            }).ToListAsync();
            return result;
        }
         
        public async Task<bool> InsertAsync(Category category)
        {
            try
            {
                category = new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
                _dbContext.Categories.Add(category);
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
                category= new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
                _dbContext.Attach(category);
                var entry = _dbContext.Entry(category);
                entry.Property(x => x.CategoryId).IsModified = true;
                entry.Property(x => x.CategoryName).IsModified = true;
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
