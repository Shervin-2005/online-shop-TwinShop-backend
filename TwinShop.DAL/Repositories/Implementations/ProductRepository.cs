using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
                return false;

            product.IsDeleted = true;

            _dbContext.Entry(product).Property(c => c.IsDeleted).IsModified = true;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int ProductId)
        {
            var product = await _dbContext.Products.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetProductsByBrandNameAsync(string brandName)
        {
            var products= await _dbContext.Products.Where(x=>x.BrandName == brandName).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryNameAsync(string categoryName)
        {
            var products = await _dbContext.Products.Where(x => x.CategoryName == categoryName).ToListAsync();
            return products;
        }

        public async Task<List<Product?>> GetProductsByNameAsync(string ProductName)
        {
                var products = await _dbContext.Products.Where(x => x.ProductName.Contains(ProductName) && x.IsDeleted == false).Select(x => new Product
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

        public async Task<bool> InsertAsync(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return true;    
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            try
            {
                var existing = await _dbContext.Products.FindAsync(product.ProductId);
                if (existing == null) return false;

                existing.ProductName = product.ProductName;
                existing.Description = product.Description;
                existing.ImageUrl = product.ImageUrl;
                existing.Price = product.Price;
                existing.BrandId = product.BrandId;
                
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
