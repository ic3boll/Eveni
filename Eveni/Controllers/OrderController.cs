using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.Services.Interfaces;
using Web.ViewModels.Item;
using Web.ViewModels.Orders;
using Web.ViewModels.Products;
using Web.ViewModels.Services.Interfaces;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly IViewModelServices _viewModelServices;
        private readonly IMapper _mapper;
        public OrderController(IOrderServices orderServices, IViewModelServices viewModelServices, IMapper mapper)
        {
            this._orderServices = orderServices;
            this._viewModelServices = viewModelServices;
            this._mapper = mapper;
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
            var UserOrdersAsList =  _viewModelServices.SetUserOrdersCollection(UserOrders);

            var deserializedOrders = _orderServices.DeserializeOrderItems(UserOrdersAsList);

            ViewData["Orders"] =  deserializedOrders;

            return View();
        }


    }
}
