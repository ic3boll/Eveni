using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Intefaces
{
   public interface IImageServices
    {
        public Task<IReadOnlyCollection<Image>> GetAllAsync();
    }
}
