using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Models.Requests;
using Poodle_E_Learning_Platform.Services;

namespace Poodle_E_Learning_Platform.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService service;
        public UsersController(IUsersService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var result = this.service.GetAll();
            return this.StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromHeader] string email)
        {
            try
            {
                var result = this.service.GetById(id, email);
                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (EntityNotFoundException)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                var userr = this.service.CreateUser(user);
                return this.StatusCode(StatusCodes.Status200OK, userr);
            }
            catch (DuplicateEntityException)
            {
                return this.StatusCode(StatusCodes.Status409Conflict);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromHeader]string email, [FromBody] UserRequest userRequest)
        {
            var user = this.service.GetByEmail(email);
            try
            {
                var userr = this.service.UpdateUser(id,user.Email,userRequest);
                return this.StatusCode(StatusCodes.Status200OK, userr);
            }
            catch (DuplicateEntityException)
            {
                return this.StatusCode(StatusCodes.Status409Conflict);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromHeader]string email)
        {
            var user = this.service.GetByEmail(email);
            if(user.Id != id)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized);
            }
            try
            {
                var userToDelete = this.service.Delete(id, user.Email);
                return this.StatusCode(StatusCodes.Status200OK, userToDelete);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status404NotFound);

            }
        }
    }
}
