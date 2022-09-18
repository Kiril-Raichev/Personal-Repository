using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Services;

namespace Poodle_E_Learning_Platform.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService service;

        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public IActionResult Get([FromQuery] CourseQueryParameters filterParameters, [FromHeader]string email)
        {
            var result = this.service.GetAll(email);
            return this.StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromHeader] string email)
        {
            try
            {
                var result = this.service.GetById(id, email);
                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
        [HttpPost]
        public IActionResult Create (Course course, [FromHeader]string email)
        {
            try
            {
                var courseToCreate = this.service.CreateCourse(course, email);
                return this.StatusCode(StatusCodes.Status200OK, courseToCreate);
            }
            catch (DuplicateEntityException e)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromHeader] string email, [FromBody] Course changes)
        {
            
                var courseToUpdate = this.service.UpdateCourse(id,email,changes);
                return this.StatusCode(StatusCodes.Status200OK, courseToUpdate);
            
           
        }


        [HttpDelete("{id}")]
        public IActionResult Delete (int id, [FromHeader]string email)
        {
            try
            {
                var courseToDelete = this.service.Delete(id, email);
                return this.StatusCode(StatusCodes.Status200OK, courseToDelete);
            }
            catch(EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        
        [HttpGet("[action]/{title}")]
        public IActionResult GetByTitle(string title, [FromHeader] string email)
        {
            try
            {
                var result = this.service.GetByTitle(title, email);
                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}
