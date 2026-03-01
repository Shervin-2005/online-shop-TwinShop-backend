using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BrandRepository> _logger;

        public BrandRepository(AppDbContext dbContext, ILogger<BrandRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var brand = await _dbContext.Brands.FindAsync(id);
                if (brand == null)
                {
                    _logger.LogWarning("Brand not found with ID: {Id}", id);
                    return false;
                }

                brand.IsDeleted = true;

                _dbContext.Entry(brand).Property(c => c.IsDeleted).IsModified = true;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error deleting brand with ID: {Id}", id);
                throw new Exception("Failed to delete brand", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error deleting brand with ID: {Id}", id);
                throw;
            }
        }

        public async Task<Brand> GetByIdAsync(int brandId)
        {
            try
            {
                var brand = await _dbContext.Brands.Where(x => x.BrandId == brandId && !x.IsDeleted).FirstOrDefaultAsync();
                return brand;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting brand by ID: {BrandId}", brandId);
                throw new Exception("Failed to get brand by ID", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting brand by ID: {BrandId}", brandId);
                throw;
            }
        }

        public async Task<bool> InsertAsync(Brand brand)
        {
            try
            {
                _dbContext.Brands.Add(brand);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error inserting brand: {Brand}", brand);
                throw new Exception("Failed to insert brand", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error inserting brand: {Brand}", brand);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Brand brand)
        {
            try
            {
                var existing = await _dbContext.Brands.FindAsync(brand.BrandId);
                if (existing == null)
                {
                    _logger.LogWarning("Brand not found with ID: {BrandId}", brand.BrandId);
                    return false;
                }

                existing.BrandName = brand.BrandName;
                existing.CategoryId = brand.CategoryId;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating brand: {Brand}", brand);
                throw new Exception("Failed to update brand", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error updating brand: {Brand}", brand);
                throw;
            }
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Brands.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting all brands");
                throw new Exception("Failed to get all brands", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting all brands");
                throw;
            }
        }

        public async Task<List<Brand>> GetBrandsByCategoryNameAsync(string categoryName)
        {
            try
            {
                var brands = await _dbContext.Brands.Where(x => x.CategoryName == categoryName).ToListAsync();
                return brands;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting brands by category name: {CategoryName}", categoryName);
                throw new Exception("Failed to get brands by category name", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting brands by category name: {CategoryName}", categoryName);
                throw;
            }
        }

        public async Task<List<Brand>> GetBrandsByNameAsync(string brandName)
        {
            try
            {
                var brands = await _dbContext.Brands.Where(x => x.BrandName.Contains(brandName) && !x.IsDeleted).ToListAsync();
                return brands;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting brands by name: {BrandName}", brandName);
                throw new Exception("Failed to get brands by name", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting brands by name: {BrandName}", brandName);
                throw;
            }
        }
    }
}
