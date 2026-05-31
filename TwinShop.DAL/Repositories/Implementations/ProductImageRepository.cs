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
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS.Product;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductImageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int ImageId)
        {
            try
            {
                var productImage = await _dbContext.ProductImages
                .FirstOrDefaultAsync(p => p.ImageId == ImageId && !p.IsDeleted);

                if (productImage == null) return false;

                productImage.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to delete product image.", ex);
            }
        }

        public async Task<List<ProductImageDto>> GetImagesByProductIdAsync(int productId)
        {
            try
            {
                return await _dbContext.ProductImages.AsNoTracking().Where(i => i.ProductId == productId && !i.IsDeleted).
                   Select(i => new ProductImageDto
                   {
                       ImageId = i.ImageId,
                       ImageUrl = i.ImageUrl,
                       DisplayOrder = i.DisplayOrder,
                       IsMainImage = i.IsMainImage,
                       ProductId = i.ProductId,
                   }).ToListAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve Product Images", ex);
            }
        }

        public async Task InsertImagesAsync(ProductImageDto dto)
        {
            try
            {
                ProductImage productImage = new ProductImage
                {
                    ImageUrl = dto.ImageUrl,
                    DisplayOrder = dto.DisplayOrder,
                    IsMainImage = dto.IsMainImage,
                    ProductId = dto.ProductId,
                    IsDeleted = false
                };
                _dbContext.ProductImages.Add(productImage);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to Add image", ex);
            }
        }
    }
}
