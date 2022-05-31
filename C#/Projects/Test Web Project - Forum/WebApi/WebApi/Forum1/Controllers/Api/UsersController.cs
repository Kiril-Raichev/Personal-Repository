using Forum1.Exceptions;
using Forum1.Hellper;
using Forum1.Models;
using Forum1.Models.Mappers;
using Forum1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AuthorisationHelper authorisationHelper;
        private readonly UserMapper userMapper;

        //A new instance of the controller is created at every request
        public UsersController(IUserService userService, AuthorisationHelper authorisationHellper, UserMapper userMapper)
        {
            this.userService = userService;
            this.authorisationHelper = authorisationHellper;
            this.userMapper = userMapper;
        }


        //Search for user by FirstName, Username or E-mail
        [HttpGet("admin/search")]
        public IActionResult Get([FromHeader] string authorisation, [FromQuery] UserQueryParameters userQueryParameters)
        {

            try
            {
                var userCheck = this.authorisationHelper.TryGetUser(authorisation);

                var users = this.userService.Get(userCheck, userQueryParameters);

                List<UserResponseDto> usersResponse = users.Select(user => new UserResponseDto(user)).ToList();
                return this.StatusCode(StatusCodes.Status200OK, usersResponse);
            }

            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }

        }


        //This method gives any (anonymous as well) user the number of registered users
        [HttpGet("")]
        public IActionResult GetUsersCount()
        {
            var count = this.userService.GetUsersCount();
            return this.StatusCode(StatusCodes.Status200OK, count);
        }

        //This methods allows users to get registered (new user's email is checked if previously blocked)
        [HttpPost("register")]

        public IActionResult RegisterUser([FromBody] UserDto dto)
        {
            try
            {
                User user = this.userMapper.ConvertToModel(dto);

                // this.userService.CheckIfUserBlocked(user.Email);//Check if user is blocked by email
                this.userService.CheckExistingUsername(dto.Username);
                this.userService.RegisterUser(user);
                return this.StatusCode(StatusCodes.Status201Created, user);
            }
            catch (DuplicateEntityException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }

            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }

        }
        //Update user's profile
        [HttpPut("updateuser")]
        public IActionResult UpdateUser([FromHeader] string username, [FromBody] UserDto userDto)
        {
            try
            {
                var user = this.userService.UpdateUser(username, userDto);
                var response = new UserResponseDto(user);
                return this.StatusCode(StatusCodes.Status202Accepted, response);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }

        }

        //Get user by username - admin authorisation implemented
        [HttpGet("username")]
        public IActionResult GetByUsername([FromHeader] string authorisation, [FromQuery] string username)
        {
            try
            {
                var userCheck = authorisationHelper.TryGetUser(authorisation);//is ?admin "authorisation" registered user in the first place?
                authorisationHelper.TryGetUser(username); // is there a user with this "username"?
                var user = this.userService.GetByUsername(userCheck, username);//sending over to Services for admin verification and user retrieval
                var userResponse = new UserResponseDto(user);
                return StatusCode(StatusCodes.Status200OK, userResponse);
            }
            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }

        }

        //Block user - admin authorisation implemented
        [HttpDelete("block")]
        public IActionResult BlockUser([FromHeader] string authorisation, [FromQuery] string username)
        {
            try
            {
                var userCheck = this.authorisationHelper.TryGetUser(authorisation);

                var user = authorisationHelper.TryGetUser(username);

                user = this.userService.BlockUser(userCheck, username);
                return this.StatusCode(StatusCodes.Status200OK, user);

            }
            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
        //Unblocks a user - admin authorisation implemented
        [HttpPost("unblock")]
        public IActionResult Unblock([FromHeader] string authorisation, [FromQuery] string username)
        {
            try
            {
                User userCheck = this.authorisationHelper.TryGetUser(authorisation);
                authorisationHelper.TryGetBlockedUser(username);
                var user = this.userService.UnblockUser(userCheck, username);
                return this.StatusCode(StatusCodes.Status201Created, user);
            }
            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

    }
}
