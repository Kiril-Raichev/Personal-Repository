

using Microsoft.AspNetCore.Mvc;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Services;
using Poodle_E_Learning_Platform.Web.Models;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Repositories;
using Poodle_E_Learning_Platform.Repositories.Contracts;
using Poodle_E_Learning_Platform.Services.Contracts;
using System;
using Poodle_E_Learning_Platform.Web.Helpers;
using System.Collections.Generic;

namespace Poodle_E_Learning_Platform.Web.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ISectionService sectionService;
        private readonly ModelMapper modelMapper;
        public SectionsController(ISectionService sectionService, ModelMapper modelMapper)
        {
            this.sectionService = sectionService;
            this.modelMapper = modelMapper;
        }

        public IActionResult Create(int courseId)
        {
            var viewModel = new SectionCreateViewModel
            {
                courseId = courseId
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(SectionCreateViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            Section section = new Section
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                Order = viewModel.Order,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate

            };
            try
            {
                this.sectionService.CreateSection(section, viewModel.courseId);
            }
            catch (DuplicateEntityException)
            {
                this.ModelState.AddModelError("Title", "This title is already in use.");
                return this.View(model: viewModel);
            }
            return Redirect($"http://localhost:5555/courses/details/{viewModel.courseId}");

        }

        [HttpGet]
        public IActionResult Edit(int courseId, int sectionId)
        {
            var LastEdit = DateTime.Now;
            var section = this.sectionService.GetById(sectionId);
            var viewModel = new SectionEditViewModel
            {
                LastEdit = LastEdit,
                courseId = courseId,
                Title = section.Title,
                Content = section.Content,
                Order = section.Order,
                StartDate = section.StartDate,
                EndDate = section.EndDate
            };
            return View(model: viewModel);
        }
        [HttpPost]
        public IActionResult Edit(SectionEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            try
            {
                Section section = this.modelMapper.Convert(viewModel);
                this.sectionService.UpdateSection(viewModel.sectionId, section);
                return Redirect($"http://localhost:5555/courses/details/{viewModel.courseId}");
            }
            catch (DuplicateEntityException)
            {
                this.ModelState.AddModelError("Title", "Title is already in use.");
                return this.View(model: viewModel);
            }
        }
        public IActionResult Delete(int sectionId, int courseId)
        {
            this.sectionService.Delete(sectionId);
            return Redirect($"http://localhost:5555/courses/details/{courseId}");
        }
    }
}