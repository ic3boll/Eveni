using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.Products;

namespace Web.Services.Interfaces
{
    public interface IProductServices
    {
        public Task CreateAsync(ProductInputModel productInputModel, ApplicationUser user, string picture);

        public Task<IReadOnlyCollection<Product>> GetAllAsync();

        public Task<Product> GetIdAsync(int id);

        public Task DeleteAsync(int id);
        public Task EditAsync(ProductEditModel productEditModel, string imageModel, int id);

        public Task EditAsync(ProductEditModel productEditModel, int id);
    }
}
