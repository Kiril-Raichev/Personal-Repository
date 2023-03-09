

using Microsoft.AspNetCore.Mvc;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Services;
using Poodle_E_Learning_Platform.Web.Models;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Services.Contracts;
using Poodle_E_Learning_Platform.Web.Helpers;
using PagedList;
using PagedList.Mvc;
using Poodle_E_Learning_Platform.Repositories;

namespace Poodle_E_Learning_Platform.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly ISectionService sectionService;
        private readonly IUsersService usersService;
        private readonly IUserCourseRepository userCourseRepository;
        private readonly ModelMapper modelMapper;

        public CoursesController(ICourseService courseService, ISectionService sectionService,
                                ModelMapper modelMapper, IUsersService usersService, IUserCourseRepository userCourseRepository)
        {
            this.courseService = courseService;
            this.sectionService = sectionService;
            this.modelMapper = modelMapper;
            this.usersService = usersService;
            this.userCourseRepository = userCourseRepository;
        }

        public IActionResult Details(int id)
        {
            try
            {
                var course = this.courseService.GetById(id);
                return View(course);
            }
            catch (System.Exception)
            {
                return View("Error");
            }

        }

        [HttpGet]
        public IActionResult Edit(int courseId)
        {

            try
            {
                Course course = this.courseService.GetById(courseId);
                var viewModel = this.modelMapper.Convert(course);
                return this.View(viewName: "Edit", viewModel);
            }
            catch (EntityNotFoundException)
            {
                return this.View(viewName: "Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(CourseEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            try
            {
                Course course = this.modelMapper.Convert(viewModel);
                this.courseService.UpdateCourse(viewModel.courseId, course);
                return this.RedirectToAction(actionName: "Courses", controllerName: "Home");
            }
            catch (DuplicateEntityException)
            {
                this.ModelState.AddModelError("Title", "Title is already in use.");
                return this.View(model: viewModel);
            }

        }

        [HttpGet("courses/details/{courseId}/section/{sectionId}")]
        public IActionResult Section(int sectionId)
        {
            var section = this.sectionService.GetById(sectionId);
            return View(section);
        }

        public IActionResult Create(string createdBy)
        {
            var viewModel = new CourseCreateViewModel
            {
                CreatedBy = createdBy
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CourseCreateViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            Course course = new Course
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Duration = viewModel.Duration,
                Visibility = viewModel.Visibility,
                ImgSource = viewModel.ImgSource,
                CreatedBy = viewModel.CreatedBy
            };
            try
            {
                this.courseService.CreateCourse(course);
            }
            catch (DuplicateEntityException e)
            {
                this.ModelState.AddModelError("Title", e.Message);
                return this.View(model: viewModel);
            }
            return this.RedirectToAction(actionName: "Courses", controllerName: "Home");
        }
        public IActionResult Delete(int Id)
        {
            this.courseService.Delete(Id);
            return this.RedirectToAction(actionName: "Courses", controllerName: "Home");
        }

        public IActionResult Students(int courseId)
        {
            var course = this.courseService.GetById(courseId);
            return View(course);
        }


        public IActionResult Enroll(int courseId)
        {
            var viewModel = new Enroll
            {
                CourseId = courseId
            };
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Enroll(Enroll model)
        {
            if (ModelState.IsValid)
            {
                var student = this.usersService.GetByEmail(model.Email);
                this.userCourseRepository.AddUserToCourse(student.Id, model.CourseId);
            }

            return Redirect($"http://localhost:5555/courses/details/{model.CourseId}");
        }
    }
}
