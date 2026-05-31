using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Data;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

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
            try
            {
                var product = await _dbContext.Products
               .FirstOrDefaultAsync(p => p.ProductId == id && !p.IsDeleted);

                if (product == null) return false; 

                product.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to delete product.", ex);
            }
        }
        public async Task<List<ProductDto>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Products
               .AsNoTracking()
               .Where(p => !p.IsDeleted)
               .Select(p => new ProductDto
               {
                   ProductId = p.ProductId,
                   CategoryId = p.CategoryId,
                   ProductName = p.ProductName,
                   BrandId = p.BrandId,
                   Description = p.Description,
                   InitialPrice = p.InitialPrice,
                   SecondaryPrice = p.SecondaryPrice,
                   NumberInStorage = p.NumberInStorage,
                   ImageUrls = p.Images!
                    .Where(i => !i.IsDeleted)
                    .Select(i => i.ImageUrl ?? string.Empty)
                    .ToList()
               })
               .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve products.", ex);
            }
        }
        public async Task<ProductDto?> GetByIdAsync(int productId)
        {
            try
            {
               return await _dbContext.Products
              .AsNoTracking()
              .Where(p => p.ProductId == productId && !p.IsDeleted)
              .Select(p => new ProductDto
                {
                  ProductId = p.ProductId,
                  ProductName = p.ProductName,
                  BrandId = p.BrandId,
                  CategoryId = p.CategoryId,
                  Description = p.Description,
                  InitialPrice = p.InitialPrice,
                  SecondaryPrice = p.SecondaryPrice,
                  NumberInStorage = p.NumberInStorage,
                  ImageUrls = p.Images!
                    .Where(i => !i.IsDeleted)
                    .Select(i => i.ImageUrl ?? string.Empty)
                    .ToList()
              })
              .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve product", ex);
            }
        }
        public async Task<List<ProductDto>> GetProductsByCategoryNameAsync(string categoryName)
        {
            try
            {
                return await _dbContext.Products
               .AsNoTracking()
               .Where(p => !p.IsDeleted &&
                           !p.Category!.IsDeleted &&
                           p.Category.CategoryName.ToLower() == categoryName.ToLower())
               .Select(p => new ProductDto
               {
                   ProductId = p.ProductId,
                   ProductName = p.ProductName,
                   BrandId = p.BrandId,
                   CategoryId = p.CategoryId,
                   Description = p.Description,
                   InitialPrice = p.InitialPrice,
                   SecondaryPrice = p.SecondaryPrice,
                   NumberInStorage = p.NumberInStorage,
                   ImageUrls = p.Images!
                    .Where(i => !i.IsDeleted)
                    .Select(i => i.ImageUrl ?? string.Empty)
                    .ToList()
               })
               .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to find product.", ex);
            }
        }
        public async Task<int> InsertAsync(ProductDto productDto)
        {
            try
            {
                var product = new Product
                {
                    ProductName = productDto.ProductName!,
                    BrandId = productDto.BrandId,
                    CategoryId = productDto.CategoryId,
                    Description = productDto.Description!,
                    InitialPrice = productDto.InitialPrice,
                    SecondaryPrice = productDto.SecondaryPrice,
                    NumberInStorage = productDto.NumberInStorage,
                    IsDeleted = false
                };

                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();

                return product.ProductId;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to create product", ex);
            }
        }
        public async Task<bool> UpdateAsync(ProductDto productDto,int id)
        {
            try
            {
                var existingProduct = await _dbContext.Products.Where(p => p.ProductId == id && !p.IsDeleted)
                    .FirstOrDefaultAsync();

                if(existingProduct == null) return false;

                existingProduct.ProductName = productDto.ProductName!;
                existingProduct.BrandId = productDto.BrandId;
                existingProduct.CategoryId = productDto.CategoryId;
                existingProduct.Description = productDto.Description!;
                existingProduct.NumberInStorage = productDto.NumberInStorage;
                existingProduct.InitialPrice = productDto.InitialPrice;
                existingProduct.SecondaryPrice = productDto.SecondaryPrice;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to update product.", ex);
            } 
        } 
        public async Task<bool> ProductNameExistAsync(string name)
        {
            try
            {
                return await _dbContext.Products
                  .AsNoTracking()
                  .AnyAsync(p => !p.IsDeleted && p.ProductName.ToLower() == name.ToLower());
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to check product name.", ex);
            }
        }
        public async Task<List<ProductDto>> SearchProductByNameAsync(string searchTerm)
        {
            try
            {
                return await _dbContext.Products
                    .AsNoTracking()
                    .Where(p => !p.IsDeleted &&
                    p.ProductName.ToLower().Contains(searchTerm.ToLower()))
                   .Select(p => new ProductDto
                   {
                     ProductId = p.ProductId,
                     ProductName = p.ProductName,
                     BrandId = p.BrandId,
                     CategoryId = p.CategoryId,
                     Description = p.Description,
                     InitialPrice = p.InitialPrice,
                     NumberInStorage = p.NumberInStorage,
                       ImageUrls = p.Images!
                      .Where(i => !i.IsDeleted)
                      .Select(i => i.ImageUrl ?? string.Empty)
                      .ToList()
                   })
                     .ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to search product.", ex);
            }
        }

        public async Task<int?> GetProductIdByNameAsync(string productName)
        {
            try
            {
                return await _dbContext.Products
              .AsNoTracking()
              .Where(p => !p.IsDeleted && p.ProductName.ToLower() == productName.ToLower())
              .Select(p => p.ProductId)
              .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to get product ID.", ex);
            }
        }
    }
}
