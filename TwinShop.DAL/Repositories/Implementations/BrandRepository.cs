using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

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
                var brand = new Brand { BrandId = id };
                _dbContext.Attach(brand);
                brand.IsDeleted = true;
                var entry = _dbContext.Entry(brand);
                entry.Property(x => x.IsDeleted).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Brand> GetByIdAsync(int brandId)
        {
            var brand = await _dbContext.Brands.Where(x => x.BrandId == brandId && !x.IsDeleted).FirstOrDefaultAsync();
            return brand;
        }

        public async Task<bool> InsertAsync(Brand brand)
        {
            try
            {
                _dbContext.Brands.Add(brand);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Brand brand)
        {
            try
            {
                var existing = await _dbContext.Brands.FindAsync(brand.BrandId);
                if (existing == null) return false;

                existing.BrandName = brand.BrandName;
                existing.CategoryId = brand.CategoryId;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Brand>>GetAllAsync()
        {
            return await _dbContext.Brands.ToListAsync();
        }

        public async Task<List<Brand?>> GetBrandsByCategoryAsync(int categoryId)
        {
            var brands = await _dbContext.Brands.Where(x => x.CategoryId == categoryId).ToListAsync();
            return brands;
        }

        public async Task<List<Brand?>>GetBrandsByNameAsync(string brandName)
        {
            var brands = await _dbContext.Brands.Where(x => x.BrandName.Contains(brandName) && x.IsDeleted == false).Select(x => new Brand
            {
                BrandName = x.BrandName,
                Category = x.Category,
                CategoryId = x.CategoryId
            }).ToListAsync();
            return brands;
        }
    }
}
