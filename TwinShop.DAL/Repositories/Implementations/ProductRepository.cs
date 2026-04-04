using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            try
            {
                var product=new Product { ProductId=id};
                _dbContext.Attach(product);
                product.IsDeleted = true;
              _dbContext.Entry(product).Property(p => p.IsDeleted).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<ProductDto>>> GetAllAsync()
        {
            try
            {
                var products= await _dbContext.Products.AsNoTracking()
                    .Where(p=>p.IsDeleted==false).Select(p=>new ProductDto
                    {
                        ProductName=p.ProductName,
                        BrandName=p.BrandName,
                        BrandId=p.BrandId,
                        CategoryName=p.CategoryName,
                        Description=p.Description,
                        MainImage=p.MainImage,
                        InitialPrice=p.InitialPrice,
                        SecondryPrice=p.SecondryPrice,
                        NumberInStorage=p.NumberInStorage,
                    }).ToListAsync();
                return OperationResult<List<ProductDto>>.SuccessedResult(products);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<ProductDto>> GetByIdAsync(int productId)
        {
            try
            {
                var product = await _dbContext.Products.AsNoTracking().Where(p => p.ProductId == productId && p.IsDeleted==false).
                    Select(p=>new ProductDto
                    {
                        ProductName = p.ProductName,
                        BrandName = p.BrandName,
                        BrandId=p.BrandId,
                        CategoryName = p.CategoryName,
                        Description = p.Description,
                        MainImage = p.MainImage,
                        InitialPrice = p.InitialPrice,
                        SecondryPrice = p.SecondryPrice,
                        NumberInStorage = p.NumberInStorage,
                    }).FirstAsync();
                return OperationResult<ProductDto>.SuccessedResult(product);
            }
            catch (Exception ex)
            {
                return OperationResult<ProductDto>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<ProductDto>>> GetProductsByBrandNameAsync(string brandName)
        {
            try
            {
                var products = await _dbContext.Products.AsNoTracking().Where(p => p.BrandName == brandName && p.IsDeleted==false)
                    .Select(p=>new ProductDto
                    {
                        ProductName = p.ProductName,
                        BrandName = p.BrandName,
                        BrandId = p.BrandId,
                        CategoryName = p.CategoryName,
                        Description = p.Description,
                        MainImage = p.MainImage,
                        InitialPrice = p.InitialPrice,
                        SecondryPrice = p.SecondryPrice,
                        NumberInStorage = p.NumberInStorage,
                    }).ToListAsync();
                return OperationResult<List<ProductDto>>.SuccessedResult(products);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<ProductDto>>> GetProductsByCategoryNameAsync(string categoryName)
        {
            try
            {
                var products = await _dbContext.Products.AsNoTracking().Where(p => p.CategoryName == categoryName && p.IsDeleted == false)
                   .Select(p => new ProductDto
                   {
                       ProductName = p.ProductName,
                       BrandName = p.BrandName,
                       BrandId = p.BrandId,
                       CategoryName = p.CategoryName,
                       Description = p.Description,
                       MainImage = p.MainImage,
                       InitialPrice = p.InitialPrice,
                       SecondryPrice = p.SecondryPrice,
                       NumberInStorage = p.NumberInStorage,
                   }).ToListAsync();
                return OperationResult<List<ProductDto>>.SuccessedResult(products);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<ProductDto>>> GetProductsByNameAsync(string productName)
        {
            try
            {
                var products = await _dbContext.Products.AsNoTracking().Where(p => p.ProductName.Contains(productName) && p.IsDeleted == false)
                  .Select(p => new ProductDto
                  {
                      ProductName = p.ProductName,
                      BrandName = p.BrandName,
                      BrandId = p.BrandId,
                      CategoryName = p.CategoryName,
                      Description = p.Description,
                      MainImage = p.MainImage,
                      InitialPrice = p.InitialPrice,
                      SecondryPrice = p.SecondryPrice,
                      NumberInStorage = p.NumberInStorage,
                  }).ToListAsync();
                return OperationResult<List<ProductDto>>.SuccessedResult(products);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> InsertAsync(ProductDto productDto)
        {
            try
            {
                Product product = new Product
                {
                    ProductName = productDto.ProductName,
                    BrandName = productDto.BrandName,
                    BrandId = productDto.BrandId,
                    CategoryName = productDto.CategoryName,
                    Description = productDto.Description,
                    MainImage = productDto.MainImage,
                    InitialPrice = productDto.InitialPrice,
                    SecondryPrice = productDto.SecondryPrice,
                    NumberInStorage = productDto.NumberInStorage,
                };
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch(Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> UpdateAsync(ProductDto productDto,int id)
        {
            try
            {
                var existing = await _dbContext.Products.Where(p => p.ProductId == id).FirstAsync();
                
                existing.ProductName = productDto.ProductName;
                existing.BrandName= productDto.BrandName;
                existing.CategoryName= productDto.CategoryName;
                existing.Description = productDto.Description;
                existing.NumberInStorage= productDto.NumberInStorage;
                existing.MainImage = productDto.MainImage;
                existing.InitialPrice = productDto.InitialPrice;
                existing.SecondryPrice = productDto.SecondryPrice;
                existing.IsDeleted = productDto.IsDeleted;

                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult(); ;
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }
}
