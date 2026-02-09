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

        public async Task<List<Product>> GetProductsByBrandAsync(int brandId)
        {
         var products= await _dbContext.Products.Where(x=>x.BrandId == brandId).ToListAsync();
            return products;
        }
    }
}
