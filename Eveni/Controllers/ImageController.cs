using ApplicationCore.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Image;
using Web.Services.Interfaces;

namespace Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageServices _imageService;
        public ImageController(IImageServices imageServices)
        {
            this._imageService = imageServices;
        }
        [Authorize]
        public async Task<IActionResult> RemoveImage(int id)
        {
            await _imageService.RemoveImage(id);
            return RedirectToAction("AllProducts", "Manager");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditImageEnum([FromBody]Image imageEditModel)
        {
           await _imageService.EditImageEnum(imageEditModel);

            return Ok();
        }
    }
}
