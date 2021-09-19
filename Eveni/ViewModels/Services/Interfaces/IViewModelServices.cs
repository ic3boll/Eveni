using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Images;
using Web.ViewModels.Orders;
using Web.ViewModels.Products;

namespace Web.ViewModels.Services.Interfaces
{
    public interface IViewModelServices
    {
        List<ProductViewModel> SetProductCollection(IReadOnlyCollection<Product> products);

        public List<ImageViewModel> SetImageCollection(IReadOnlyCollection<Image> images);

        public List<ImageViewModel> SetProductImageCollection(IReadOnlyCollection<Image> images, int id);

        public List<OrderViewModel> SetUserOrdersCollection(IReadOnlyCollection<OrderViewModel> UserOrders);
        public List<ImageEditViewModel> EditProductImageCollection(IReadOnlyCollection<Image> images, int id);
    }
}
