using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;
using Web.ViewModels.Products;

namespace Web.Services.Interfaces
{
    public interface IProductServices
    {
        public Task CreateProductAsync(ProductInputModel productInputModel, ApplicationUser user, string picture);

        public Task<IReadOnlyCollection<Product>> GetAllProducts();

        public Task<Product> GetProductId(int id);
    }
}
