using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.Services.Interfaces;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        [Route("getsomething")]
        public async Task<ActionResult> DoStuff()
        {
            return Ok();
        }
        [HttpPost]
        [Route("post")]
        public async Task<ActionResult> post([FromForm]OrderDetailInputModel odim)
        {
            if (ModelState.IsValid)
            {

                var items = Request.Cookies["CookieCart"];
                if (items == null)
                {
                    return BadRequest();
                }
                var UserId = Request.Cookies["UserID"];

                await _orderServices.CreateAsync(odim, items, UserId);
            }
            return Ok();
        }
    }
}
