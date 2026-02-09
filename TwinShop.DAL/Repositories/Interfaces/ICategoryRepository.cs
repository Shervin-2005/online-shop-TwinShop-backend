using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Repositories.Interfaces
{
    internal interface ICategoryRepository
    {
        public Task<bool> InsertAsync(Category category);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Category category);
        public Task<List<Category>> GetCategoriesByNameAsync(string CategoryName);
    }
}
