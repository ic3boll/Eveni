using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Image;

namespace Web.Services.Interfaces
{
   public interface IImageServices
    {
        public Task<IReadOnlyCollection<Image>> GetAllAsync();

        public Task<IReadOnlyCollection<Image>> GetProductImage(int id);

        public Task RemoveImage(int id);

        public Task EditImageEnum(Image imageEditModel);
    }
}
