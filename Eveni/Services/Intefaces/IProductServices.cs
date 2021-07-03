using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.Product;
using Web.ViewModels.Products;

namespace Web.Services.Interfaces
{
    public interface IProductServices
    {
        public Task CreateAsync(ProductInputModel productInputModel, ApplicationUser user, string picture);

        public Task<IReadOnlyCollection<Product>> GetAllAsync();

        public Task<Product> GetIdAsync(int id);


        public Task EditAsync(ProductEditModel productEditModel, string imageModel, int id);
    }
}
