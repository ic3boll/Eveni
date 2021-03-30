using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Products;

namespace Web.ViewModels.Services.Interfaces
{
    public interface IViewModelServices
    {
        List<ProductViewModel> SetProductCollection(IReadOnlyCollection<Product> products);
    }
}
