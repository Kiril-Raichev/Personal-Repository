using Microsoft.AspNetCore.Mvc;
using System;
using Project.API.Repositories.Interfaces;
using Project.API.Models;
using Project.Web.Helpers;
using Project.Web.Models;
namespace Project.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ModelMapper modelMapper;

        public UserController(IUserRepository userRepository, ModelMapper modelMapper)
        {
            this.userRepository = userRepository;
            this.modelMapper = modelMapper;
        }

        [HttpGet]
        public IActionResult Edit(int userId)
        {
            try
            {
                User user = userRepository.GetById(userId);
                var viewModel = this.modelMapper.Convert(user);
                return this.View(viewName: "Edit", viewModel);
            }
            catch (Exception)
            {
                return this.View(viewName: "Error");
            }
        }


        [HttpPost]
        public IActionResult Edit(int Id, UserEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            try
            {
                User user = this.modelMapper.Convert(viewModel);
                this.userRepository.UpdateUser(Id, user);

                return this.RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("Email", "Email is already in use.");
                return this.View(model: viewModel);
            }
        }
    }
}
