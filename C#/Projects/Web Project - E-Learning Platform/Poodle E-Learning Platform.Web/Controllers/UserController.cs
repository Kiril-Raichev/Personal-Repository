using Microsoft.AspNetCore.Mvc;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Repositories;
using Poodle_E_Learning_Platform.Services;
using Poodle_E_Learning_Platform.Web.Helpers;
using Poodle_E_Learning_Platform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle_E_Learning_Platform.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ModelMapper modelMapper;
        private readonly IUserCourseRepository userCourseRepository;

        public UserController(IUsersService usersService, ModelMapper modelMapper,
            IUserCourseRepository userCourseRepository)
        {
            this.usersService = usersService;
            this.modelMapper = modelMapper;
            this.userCourseRepository = userCourseRepository;
        }


        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Unenroll(int courseId, int userId)
        {
            this.userCourseRepository.RemoveCourseFromUser(courseId, userId);
            return RedirectToAction("Courses","User");
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int userId)
        {
            try
            {
                User user = this.usersService.GetById(userId);
                var viewModel = this.modelMapper.Convert(user);
                return this.View(viewName: "Edit", viewModel);
            }
            catch (EntityNotFoundException)
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
                this.usersService.UpdateUser(Id, user);           

                return this.RedirectToAction(actionName: "Profile", controllerName: "User");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("Email", "Email is already in use.");
                return this.View(model: viewModel);
            }
        }
    }
}
