using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(AppDbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product not found with ID: {Id}", id);
                    return false;
                }

                product.IsDeleted = true;

                _dbContext.Entry(product).Property(c => c.IsDeleted).IsModified = true;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error deleting product with ID: {Id}", id);
                throw new Exception("Failed to delete product", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error deleting product with ID: {Id}", id);
                throw;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting all products");
                throw new Exception("Failed to get all products", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting all products");
                throw;
            }
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            try
            {
                var product = await _dbContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                return product;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting product by ID: {ProductId}", productId);
                throw new Exception("Failed to get product by ID", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting product by ID: {ProductId}", productId);
                throw;
            }
        }

        public async Task<List<Product>> GetProductsByBrandNameAsync(string brandName)
        {
            try
            {
                var products = await _dbContext.Products.Where(x => x.BrandName == brandName).ToListAsync();
                return products;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting products by brand name: {BrandName}", brandName);
                throw new Exception("Failed to get products by brand name", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting products by brand name: {BrandName}", brandName);
                throw;
            }
        }

        public async Task<List<Product>> GetProductsByCategoryNameAsync(string categoryName)
        {
            try
            {
                var products = await _dbContext.Products.Where(x => x.CategoryName == categoryName).ToListAsync();
                return products;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting products by category name: {CategoryName}", categoryName);
                throw new Exception("Failed to get products by category name", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting products by category name: {CategoryName}", categoryName);
                throw;
            }
        }

        public async Task<List<Product?>> GetProductsByNameAsync(string productName)
        {
            try
            {
                var products = await _dbContext.Products.Where(x => x.ProductName.Contains(productName) && x.IsDeleted == false).Select(x => new Product
                {
                    BrandId = x.BrandId,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    Brand = x.Brand
                }).ToListAsync();
                return products;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error getting products by name: {ProductName}", productName);
                throw new Exception("Failed to get products by name", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting products by name: {ProductName}", productName);
                throw;
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error inserting product: {Product}", product);
                throw new Exception("Failed to insert product", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error inserting product: {Product}", product);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {

            try
            {
                var existing = await _dbContext.Products.FindAsync(product.ProductId);
                if (existing == null)
                {
                    _logger.LogWarning("Product not found with ID: {ProductId}", product.ProductId);
                    return false;
                }

                existing.ProductName = product.ProductName;
                existing.Description = product.Description;
                existing.ImageUrl = product.ImageUrl;
                existing.Price = product.Price;
                existing.BrandId = product.BrandId;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating product: {Product}", product);
                throw new Exception("Failed to update product", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error updating product: {Product}", product);
                throw;
            }
        }
    }
}
