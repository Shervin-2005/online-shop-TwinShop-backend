using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        public Task<bool> InsertAsync(Brand brand);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Brand brand);
        public Task<List<Brand>> GetBrandsByNameAsync(string BrandName);
        public Task<List<Brand>> GetBrandsByCategoryAsync(int brandId);
        public Task<Brand> GetByIdAsync(int brandId);
        public Task<List<Brand>> GetAllAsync();

    }
}
