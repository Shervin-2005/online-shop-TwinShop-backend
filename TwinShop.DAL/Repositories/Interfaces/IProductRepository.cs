using Twin_Shop__Web_API.Entities;

namespace Twin_Shop__Web_API.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        Task<List<Product>> GetProductsByBrandAsync(int brandId);

    }
}
