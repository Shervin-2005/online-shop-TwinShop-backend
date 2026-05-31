using Microsoft.AspNetCore.Http;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS.Product;

namespace TwinShop.BLL.Services.UploadImageService.Implementations
{
    public class SaveProductImagesService : ISaveProductImagesService
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly ISavePhotoService _savePhotoService;
        public SaveProductImagesService(IProductImageRepository productImageRepository,
                                        ISavePhotoService savePhotoService)
        {
            _productImageRepository = productImageRepository;
            _savePhotoService = savePhotoService;
        }
        public async Task UploadProductImages(List<IFormFile> images, int id, string productName)
        {
            if (images == null || !images.Any())
                throw new FileValidationException("At least one image is required.");

            int displayOrder= 0;

                foreach (var image in images)
                { 
                    string imageUrl =  await _savePhotoService.SaveProductImageAsync(image, productName);
                    
                    var productImageDto = new ProductImageDto
                    {
                        ProductId = id,
                        ImageUrl = imageUrl,
                        IsMainImage = displayOrder == 0,
                        DisplayOrder = displayOrder,  
                    };
                    await _productImageRepository.InsertImagesAsync(productImageDto);
                    displayOrder++;   
                }
        }
    }
}
