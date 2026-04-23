using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Product;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IProductSideImageRepository
    {
        Task<OperationResult> InsertSideImagesAsync(ProductSideImageDto dto);
        Task<OperationResult<List<ProductSideImageDto>>> GetSideImagesByProductIdAsync(int productId);
        Task<OperationResult> DeleteAsync(int sideImageId);
    }
}
