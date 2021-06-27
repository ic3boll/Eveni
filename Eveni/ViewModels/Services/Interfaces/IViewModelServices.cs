using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Images;
using Web.ViewModels.Products;

namespace Web.ViewModels.Services.Interfaces
{
    public interface IViewModelServices
    {
        List<ProductViewModel> SetProductCollection(IReadOnlyCollection<Product> products);

        public List<ImageViewModel> SetImageCollection(IReadOnlyCollection<Image> images);
    }
}
