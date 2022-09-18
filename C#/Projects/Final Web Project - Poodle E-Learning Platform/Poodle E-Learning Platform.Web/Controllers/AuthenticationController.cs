

using Microsoft.AspNetCore.Mvc;
using Poodle_E_Learning_Platform.Services;
using Poodle_E_Learning_Platform.Web.Models;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Web.Helpers;
using Poodle_E_Learning_Platform.Helpers;
using System;
using Poodle_E_Learning_Platform.Exceptions;

namespace Poodle_E_Learning_Platform.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ModelMapper modelMapper;
        private readonly AuthorizationHelper authHelper;

        public AuthenticationController(IUsersService usersService, ModelMapper modelMapper,AuthorizationHelper authHelper)
        {
            this.usersService = usersService;
            this.modelMapper = modelMapper;
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
                User user = this.authHelper.TryGetUser(viewModel.Username);
                if(user != null)
                {
                    try
                    {
                        this.authHelper.TryGetUser(viewModel.Username, viewModel.Password);
                    }catch(AuthenticationException e)
                    {
                        this.ModelState.AddModelError("Password", e.Message);
                        return this.View(model: viewModel);
                    }
                    this.authHelper.CurrentUser = user.Email;
                }
            }catch (EntityNotFoundException e)
            {
                this.ModelState.AddModelError("Username", e.Message);

                return this.View(model: viewModel);
            }

            return this.RedirectToAction(actionName: "Index", controllerName: "Home");
            //catch (AuthenticationException e)
            //{
            //    this.ModelState.AddModelError("Password", e.Message);
            //    return this.View(model: viewModel);
            //}
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
        public IActionResult Register (RegisterViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }
            if(viewModel.IsChecked == false)
            {
                this.ModelState.AddModelError("IsChecked", "You have not agreed to the terms of service.");
                return this.View(model: viewModel);
            }

            if (this.usersService.IsUserExisting(viewModel.Username))
            {
                this.ModelState.AddModelError("Username", "E-mail is already in use.");

                return this.View(model: viewModel);
            }

            if(viewModel.Password != viewModel.ConfirmPassword)
            {
                this.ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

                return this.View(model: viewModel);
            }

            User user = this.modelMapper.Convert(viewModel);
            this.usersService.CreateUser(user);

            return this.RedirectToAction(actionName: "Login", controllerName: "Authentication");
        }
    }

}
