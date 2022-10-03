using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models;
using Project.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    public class ArticleController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CourseController : ControllerBase
        {
            private readonly IArticleRepository repository;

            public CourseController(IArticleRepository repository)
            {
                this.repository = repository;
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                try
                {
                    var result = this.repository.GetById(id);
                    return this.StatusCode(StatusCodes.Status200OK, result);
                }
                catch (Exception e)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
                }
            }
            [HttpPost]
            public IActionResult Create(Article article)
            {
                try
                {
                    var courseToCreate = this.repository.CreateArticle(article);
                    return this.StatusCode(StatusCodes.Status200OK, courseToCreate);
                }
                catch (Exception e)
                {
                    return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
                }
            }


            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    var courseToDelete = this.repository.Delete(id);
                    return this.StatusCode(StatusCodes.Status200OK, courseToDelete);
                }
                catch (Exception e)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
                }
            }
        }
    }
}
