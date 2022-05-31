using Forum1.Hellper;
using Forum1.Models;
using Forum1.Models.Mappers;
using Forum1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Forum1.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AuthorisationHelper authHelper;
        private readonly IUserService userService;
        private readonly UserMapper userMapper;


        public AuthenticationController(AuthorisationHelper authHelper, IUserService userService, UserMapper userMapper)
        {
            this.authHelper = authHelper;
            this.userService = userService;
            this.userMapper = userMapper;
        }

        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(model: viewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            try
            {
                User user = this.authHelper.TryGetUser(viewModel.Username, viewModel.Password);
                this.HttpContext.Session.SetString("CurrentUser", user.Username);
                TempData["username"] = viewModel.Username;
                TempData.Keep();
                return this.RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch (AuthenticationException e)
            {
                this.ModelState.AddModelError("Username", e.Message);
                return this.View(model: viewModel);
            }

        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("CurrentUser");
            this.HttpContext.Session.Clear();
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel();
            return this.View(model: viewModel);
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }
            if (this.userService.Exists(viewModel.Username))
            {
                this.ModelState.AddModelError("Username", "User with same username already exists.");
                return this.View(model: viewModel);
            }
            if (viewModel.Password != viewModel.ConfirmPassword)
            {
                this.ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");
                return this.View(model: viewModel);
            }
            User user = this.userMapper.Convert(viewModel); 
            this.userService.RegisterUser(user);

            return this.RedirectToAction(actionName: "Login", controllerName: "Authentication");
        }
    }
}
