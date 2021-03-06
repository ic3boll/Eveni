using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
using Web.Models.Image;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class ImageServices : IImageServices
    {
        private readonly IAsyncRepository<Image> _imageRepository;
        public ImageServices(IAsyncRepository<Image> imageRepository)
        {
            this._imageRepository = imageRepository;
        }

        public async Task<IReadOnlyCollection<Image>> GetAllAsync()
        {
            var images = await this._imageRepository.GetAllAsync();
            
            return images;
        }

        public async Task RemoveImage(int id)
        {
            var tbdeleted = await this._imageRepository.GetByIdAsync(id);
            await this._imageRepository.RemoveAsync(tbdeleted);
        }

        public async Task EditImageEnum(Image imageEditModel)
        {
            var image = await this._imageRepository.GetByIdAsync(imageEditModel.Id);
            image.imageEnum = imageEditModel.imageEnum;

            await this._imageRepository.UpdateAsync(image);
        }
    }
}
