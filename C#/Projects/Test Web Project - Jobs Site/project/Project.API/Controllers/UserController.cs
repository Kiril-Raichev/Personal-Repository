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
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;
        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var result = this.repository.GetAll();
            return this.StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromHeader] string email)
        {
            try
            {
                var result = this.repository.GetById(id);
                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                var userr = this.repository.CreateUser(user);
                return this.StatusCode(StatusCodes.Status200OK, userr);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status409Conflict);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userToDelete = this.repository.Delete(id);
                return this.StatusCode(StatusCodes.Status200OK, userToDelete);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status404NotFound);

            }
        }
    }
}
