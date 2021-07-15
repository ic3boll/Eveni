using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
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

        public async Task<IReadOnlyCollection<Image>> GetProductImage(int id)
        {
            var image = await this._imageRepository.GetAllAsync();
            return image;
        }
    }
}
