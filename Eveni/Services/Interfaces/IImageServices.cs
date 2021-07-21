using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Interfaces
{
   public interface IImageServices
    {
        public Task<IReadOnlyCollection<Image>> GetAllAsync();

        public Task<IReadOnlyCollection<Image>> GetProductImage(int id);

        public Task RemoveImage(int id);
    }
}
