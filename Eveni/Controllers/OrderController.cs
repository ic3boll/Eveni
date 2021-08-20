using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.Services.Interfaces;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private IAsyncRepository<Order> _OrderRepository;
        private readonly IOrderServices _orderServices;
        public OrderController(IAsyncRepository<Order> OrderRepository,
            IOrderServices orderServices)
        {
            this._orderServices = orderServices;
            this._OrderRepository = OrderRepository;
        }

        public IActionResult Complete()
        {
            return View("Order");
        }
        [HttpPost]
        public async Task<IActionResult> Complete(OrderDetailInputModel orderDetailInput)
        {
            var items = Request.Cookies["CookieCart"];
            if (items == null)
            {

                return RedirectToAction("Home", "Home");
            }
            var UserId = Request.Cookies["UserID"];

            await _orderServices.CreateAsync(orderDetailInput, items, UserId);

            return RedirectToAction("Home", "Home");
        }
    }
}
