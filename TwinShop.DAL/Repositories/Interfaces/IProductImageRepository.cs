using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Product;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IProductImageRepository
    {
        Task InsertImagesAsync(ProductImageDto dto);
        Task<List<ProductImageDto>> GetImagesByProductIdAsync(int productId);
        Task<bool> DeleteAsync(int ImageId);
    }
}
