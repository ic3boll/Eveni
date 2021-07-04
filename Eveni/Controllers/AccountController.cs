using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels.Account.Login;
using Web.ViewModels.Account.Register;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public AccountController(SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
        UserManager<ApplicationUser> userManager)
        {
            this._signInManager = signInManager;
            this._mapper = mapper;
           this._userManager = userManager;

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Home", "Home");
            }
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username,loginViewModel.Password, loginViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Home", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(loginViewModel);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
           if(_signInManager.IsSignedIn(User))
            {
              return RedirectToAction("Home","Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            //configure service for register map
        

            var registerData = new ApplicationUser()
            {
                UserName=registerViewModel.UserName,
                Email=registerViewModel.Email
            };
            
             var registerInput = await this._userManager.CreateAsync(registerData, registerViewModel.Password);
            if (registerInput.Succeeded)
            {
               return this.RedirectToAction("Login","Account");
            }
                return this.RedirectToAction("Home","Home");
            
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Home", "Home");
        }
    }
}
