using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Data;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;

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
                        ProductId=p.ProductId,
                        ProductName=p.ProductName,
                        BrandName=p.BrandName,
                        BrandId=p.BrandId,
                        CategoryName=p.CategoryName,
                        Description=p.Description,
                        MainImageUrl=p.MainImageUrl,
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
                        MainImageUrl = p.MainImageUrl,
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
                        MainImageUrl = p.MainImageUrl,
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
                       MainImageUrl = p.MainImageUrl,
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
                var products = await _dbContext.Products.AsNoTracking().Where(p => p.ProductName!.Contains(productName) && p.IsDeleted == false)
                  .Select(p => new ProductDto
                  {
                      ProductName = p.ProductName,
                      BrandName = p.BrandName,
                      BrandId = p.BrandId,
                      CategoryName = p.CategoryName,
                      Description = p.Description,
                      MainImageUrl = p.MainImageUrl,
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
                    CategoryId = productDto.CategoryId,
                    Description = productDto.Description,
                    MainImageUrl = productDto.MainImageUrl,
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
                existing.BrandId = productDto.BrandId;
                existing.CategoryName= productDto.CategoryName;
                existing.CategoryId = productDto.CategoryId;
                existing.Description = productDto.Description;
                existing.NumberInStorage= productDto.NumberInStorage;
                existing.MainImageUrl = productDto.MainImageUrl;
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
        public async Task<OperationResult> ProductNameExist(string Name)
        {
            var user = await _dbContext.Products.Where(x => x.ProductName == Name).FirstOrDefaultAsync();

            return user != null ? OperationResult.SuccessedResult() : OperationResult<UserDto>.Failed();
        }

        public async Task<OperationResult<List<ProductDto>>> SearhProductByName(string searchTerm)
        {
            try
            {
                var products = await _dbContext.Products
                    .AsNoTracking()
                    .Where(p => p.IsDeleted == false &&
                                 p.ProductName!.Contains(searchTerm))
                    .Select(p => new ProductDto
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        BrandId = p.BrandId,
                        BrandName = p.BrandName,
                        CategoryId = p.CategoryId,
                        CategoryName = p.CategoryName,
                        Description = p.Description, 
                        InitialPrice = p.InitialPrice,
                        SecondryPrice = p.SecondryPrice,
                        NumberInStorage = p.NumberInStorage,
                        MainImageUrl = p.MainImageUrl,
                    })
                    .ToListAsync();

                return OperationResult<List<ProductDto>>.SuccessedResult(products);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductDto>>.Failed(GetType().Name, ex);
            }
        }
    }
}
