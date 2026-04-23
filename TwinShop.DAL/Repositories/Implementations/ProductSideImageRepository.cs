using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.DAL.Data;
using TwinShop.DAL.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Product;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class ProductSideImageRepository : IProductSideImageRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductSideImageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> DeleteAsync(int sideImageId)
        {
            try
            {
                var productSideImage = new ProductSideImage { SideImageId = sideImageId };
                _dbContext.Attach(productSideImage);
                productSideImage.IsDeleted = true;
                _dbContext.Entry(productSideImage).Property(b => b.IsDeleted).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<ProductSideImageDto>>> GetSideImagesByProductIdAsync(int productId)
        {
            try
            {
                var productSideImages = await _dbContext.productSideImages.AsNoTracking().Where(i=> i.ProductId == productId && i.IsDeleted == false).
                    Select(i => new ProductSideImageDto
                    {
                        SideImageId = i.SideImageId,
                        SideImageUrl = i.SideImageUrl,
                        ProductId = i.ProductId,

                    }).ToListAsync();

                return OperationResult<List<ProductSideImageDto>>.SuccessedResult(productSideImages);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductSideImageDto>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> InsertSideImagesAsync(ProductSideImageDto dto)
        {
            try
            {
                ProductSideImage productSideImages = new ProductSideImage
                {
                    SideImageId = dto.SideImageId,
                    SideImageUrl = dto.SideImageUrl,
                    ProductId = dto.ProductId,
                };
                _dbContext.productSideImages.Add(productSideImages);
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }
}
