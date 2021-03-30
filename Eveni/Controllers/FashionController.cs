using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FashionController : Controller
    {   
        [Route("Fasion")]
        public async Task<IActionResult> Fashion()
        {
            return View();
        }
        [Route("Kids")]
        public async Task<IActionResult> Kid()
        {
            return View();
        }
    }
}
