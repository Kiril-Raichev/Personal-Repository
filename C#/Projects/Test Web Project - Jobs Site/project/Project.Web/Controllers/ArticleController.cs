using Microsoft.AspNetCore.Mvc;
using Project.API.Models;
using Project.API.Repositories.Interfaces;
using Project.Web.Helpers;
using Project.Web.Models;
using System;

namespace Project.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly ModelMapper modelMapper;

        public ArticleController(IArticleRepository articleRepository, ModelMapper modelMapper)
        {
            this.articleRepository = articleRepository;
            this.modelMapper = modelMapper;
        }

        public IActionResult Details(int id)
        {
            try
            {
                var article = this.articleRepository.GetById(id);
                return View(article);
            }
            catch (System.Exception)
            {
                return View("Error");
            }

        }

        public IActionResult Create(string createdBy)
        {
            var viewModel = new ArticleCreateViewModel
            {
                CreatedBy = createdBy
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            Article article = new Article
            {
                Title = viewModel.Title,
                Body = viewModel.Body,
                Job = viewModel.Job,
                Position = viewModel.Position,
                Visibility = viewModel.Visibility,
                CreatedBy = viewModel.CreatedBy,
                
            };
            try
            {
                this.articleRepository.CreateArticle(article);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("Title", e.Message);
                return this.View(model: viewModel);
            }
            return this.RedirectToAction(actionName: "Catalog", controllerName: "Home");
        }

        [HttpGet]
        public IActionResult Edit(int articleId)
        {
        
            try
            {
                Article article = this.articleRepository.GetById(articleId);
                var viewModel = this.modelMapper.Convert(article);
                return this.View(viewName: "Edit", viewModel);
            }
            catch (Exception)
            {
                return this.View(viewName: "Error");
            }
        }
        
        [HttpPost]
        public IActionResult Edit(ArticleEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }
        
            try
            {
                Article article = this.modelMapper.Convert(viewModel);
                this.articleRepository.UpdateArticle(viewModel.articleId, article);
                return this.RedirectToAction(actionName: "Catalog", controllerName: "Home");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("Title", "Title is already in use.");
                return this.View(model: viewModel);
            }
        
        }
       
        public IActionResult Delete(int Id)
        {
            this.articleRepository.Delete(Id);
            return this.RedirectToAction(actionName: "Catalog", controllerName: "Home");
        }


    }
}
