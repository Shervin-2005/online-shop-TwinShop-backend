using AutoMapper;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
namespace Twin_Shop__Web_API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;


        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                return _mapper.Map<List<CategoryDto>>(categories);
            }
            catch (Exception ex)
            {   
                _logger.LogError(ex, "Error occurred while getting all categories.");
                throw;
            }
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category != null) return _mapper.Map<CategoryDto>(category);
                  else
                  {
                    _logger.LogError("No category found with CategoryId: {CategoryId}", id);
                    throw new Exception("No category found with the provided CategoryId");
                  }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting category by ID: {Id}", id);
                throw;
            }

        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
        {
            try
            {
                var category = _mapper.Map<Category>(dto);
                await _categoryRepository.InsertAsync(category);
                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new category.");
                throw;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category != null) return await _categoryRepository.DeleteAsync(id);
                else return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting category by ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            try
            {
                var category = _mapper.Map<Category>(dto);
                return await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating category.");
                throw;
            }
        }

        public async Task<List<CategoryDto?>> GetCategoriesByNameAsync(string name)
        {
            try
            {
                var categories = await _categoryRepository.GetCategoriesByNameAsync(name);
                return _mapper.Map<List<CategoryDto>>(categories)!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting categories by name: {Name}", name);
                throw;
            }
        }
    }
}


