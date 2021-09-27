﻿using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.Services.Interfaces;
using Web.ViewModels.Orders;
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
           UserOrderViewModel Orders = new  UserOrderViewModel();
            var asd = new List<UserOrderViewModel>();
            foreach (var item in UserOrdersAsList)
            {
              Orders.items= JsonConvert.DeserializeObject<List<Item>>(item.Items);
                asd.Add(Orders);
                
            }

            ViewData["Orders"] = asd ;

            return View();
        }
    }
}
