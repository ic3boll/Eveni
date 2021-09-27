using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.Services.Interfaces;
using Web.ViewModels.Services.Interfaces;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly IViewModelServices _viewModelServices;
        public OrderController(IOrderServices orderServices, IViewModelServices viewModelServices)
        {
            this._orderServices = orderServices;
            this._viewModelServices = viewModelServices;
        }

        public IActionResult Complete()
        {
            return View("Order");
        }
        [HttpPost]
        public async Task<IActionResult> Complete(OrderDetailInputModel orderDetailInput)
            {
            if (ModelState.IsValid)
            {
                var items = Request.Cookies["CookieCart"];
                if (items == null)
                {
                    return BadRequest();
                }
                var UserId = Request.Cookies["UserID"];


               await _orderServices.CreateAsync(orderDetailInput, items, UserId);
            }
            return Ok();

        }

        public async Task<IActionResult> UserOrder()
        {
            var UserId = Request.Cookies["UserID"];
            var UserOrders = await _orderServices.GetUserOrdersAsync(UserId);
            var UserOrdersAsList = _viewModelServices.SetUserOrdersCollection(UserOrders);
            ViewData["Orders"] = UserOrdersAsList;

            return View();
        }
    }
}
