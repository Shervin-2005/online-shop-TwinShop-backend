using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Repositories.Interfaces;

namespace Twin_Shop__Web_API.Repositories.Implementations
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
            try
            {
                var product = new Product { ProductId = id };
                _dbContext.Attach(product);
                product.IsDeleted = true;
                var entry = _dbContext.Entry(product);
                entry.Property(x => x.IsDeleted).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            { 
            return false;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetByIdAsync(int ProductId)
        {
            var products = await _dbContext.Products.Where(x => x.ProductId == ProductId).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetProductsByBrandAsync(int brandId)
        {
         var products= await _dbContext.Products.Where(x=>x.BrandId == brandId).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetProductsByNameAsync(string ProductName)
        {
                var result = await _dbContext.Products.Where(x => x.ProductName!.Contains(ProductName) && x.IsDeleted == false).Select(x => new Product
                {
                    BrandId = x.BrandId,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    Brand = x.Brand
                }).ToListAsync();
                return result;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            try
            {
                product = new Product
                {
                    BrandId = product.BrandId,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    Brand = product.Brand,
                    ProductName = product.ProductName
                };
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
                product = new Product
                {
                    ProductId = product.ProductId,
                    BrandId = product.BrandId,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Brand = product.Brand,
                    ProductName = product.ProductName
                };
                _dbContext.Attach(product);
                var entry=_dbContext.Entry(product);
                entry.Property(x=> x.ProductId).IsModified=true;
                entry.Property(x => x.BrandId).IsModified = true;
                entry.Property(x => x.Description).IsModified = true;
                entry.Property(x => x.ImageUrl).IsModified = true;
                entry.Property(x => x.Price).IsModified = true;
                entry.Property(x => x.Brand).IsModified = true;
                entry.Property(x => x.ProductName).IsModified = true;
               return true;
            }

            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
