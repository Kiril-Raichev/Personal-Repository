using Microsoft.AspNetCore.Mvc;
using Project.API.Models;
using Project.API.Repositories.Interfaces;
using Project.Web.Helpers;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly AuthorizationHelper authHelper;
        private readonly ModelMapper modelMapper;

        public AuthenticationController(IUserRepository userRepository, ModelMapper modelMapper, AuthorizationHelper authHelper)
        {
            this.modelMapper = modelMapper;
            this.userRepository = userRepository;
            this.authHelper = authHelper;
        }

        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();

            return this.View(model: viewModel);
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
                User user = this.authHelper.TryGetUser(viewModel.Email);
                if (user != null)
                {
                    try
                    {
                        this.authHelper.TryGetUser(viewModel.Email, viewModel.Password);
                    }
                    catch (Exception e)
                    {
                        this.ModelState.AddModelError("Password", e.Message);
                        return this.View(model: viewModel);
                    }
                    this.authHelper.CurrentUser = user.Email;
                }
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("Username", e.Message);

                return this.View(model: viewModel);
            }

            return this.RedirectToAction(actionName: "Index", controllerName: "Home");
        }


        public IActionResult Logout()
        {
            this.authHelper.CurrentUser = null;

            return this.RedirectToAction(actionName: "index", controllerName: "home");
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
            if (viewModel.IsChecked == false)
            {
                this.ModelState.AddModelError("IsChecked", "You have not agreed to the terms of service.");
                return this.View(model: viewModel);
            }

            if (this.userRepository.IsUserExisting(viewModel.Email))
            {
                this.ModelState.AddModelError("Email", "E-mail is already in use.");

                return this.View(model: viewModel);
            }

            if (viewModel.Password != viewModel.ConfirmPassword)
            {
                this.ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

                return this.View(model: viewModel);
            }

            User user = this.modelMapper.Convert(viewModel);
            this.userRepository.CreateUser(user);

            return this.RedirectToAction(actionName: "Login", controllerName: "Authentication");
        }
    }
}
