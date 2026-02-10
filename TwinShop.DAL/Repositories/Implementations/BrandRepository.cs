using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {

        private readonly AppDbContext _dbContext;

        public BrandRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var brand = new Brand { BrandId = id };
                _dbContext.Attach(brand);
                brand.IsDeleted = true;
                var entry = _dbContext.Entry(brand);
                entry.Property(x => x.IsDeleted).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Brand> GetByIdAsync(int brandId)
        {
            var brands = await _dbContext.Brands.Where(x => x.BrandId == brandId).FirstOrDefaultAsync();
            return brands;
        }

        public async Task<bool> InsertAsync(Brand brand)
        {
            try
            {
                brand = new Brand
                {
                    BrandId = brand.BrandId,
                    CategoryId = brand.CategoryId,
                    BrandName = brand.BrandName,
                    Category = brand.Category
                };
                _dbContext.Brands.Add(brand);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Brand brand)
        {
            try
            {
                brand = new Brand
                {
                    BrandId = brand.BrandId,
                    BrandName = brand.BrandName,
                    Category = brand.Category,
                    CategoryId = brand.CategoryId
                };
                _dbContext.Attach(brand);
                var entry = _dbContext.Entry(brand);
                entry.Property(x => x.BrandId).IsModified = true;
                entry.Property(x => x.BrandName).IsModified = true;
                entry.Property(x => x.Category).IsModified = true;
                entry.Property(x => x.CategoryId).IsModified = true;
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        async Task<List<Brand>> IBrandRepository.GetAllAsync()
        {
            return await _dbContext.Brands.ToListAsync();
        }

        async Task<List<Brand>> IBrandRepository.GetBrandsByCategoryAsync(int categoryId)
        {
            var brands = await _dbContext.Brands.Where(x => x.CategoryId == categoryId).ToListAsync();
            return brands;
        }

        async Task<List<Brand>> IBrandRepository.GetBrandsByNameAsync(string BrandName)
        {
            var result = await _dbContext.Brands.Where(x => x.BrandName!.Contains(BrandName) && x.IsDeleted == false).Select(x => new Brand
            {
                BrandId = x.BrandId,
                Category = x.Category,
                CategoryId = x.CategoryId
            }).ToListAsync();
            return result;
        }
    }
}
