using Forum1.Models;
using Forum1.Repositories;
using System.Collections.Generic;
using Forum1.Exceptions;

namespace Forum1.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> Get()
        {
            return this.userRepository.Get();
        }
        public User GetByEmail(string email)
        {
            return this.userRepository.GetByEmail(email);

        }



        public List<User> Get(User userCheck, UserQueryParameters queryParameters)
        {
            if (userCheck.Role != Roles.Admin)
            {
                throw new UnauthorizedOperationException("Only Admin is authorised!");
            }
            return this.userRepository.Get(queryParameters);
        }
        public User CheckBlockedUser(string blockedUser)
        {
            return this.userRepository.CheckBlockedUser(blockedUser);
        }
        public void CheckExistingUsername(string username)
        {
            if (this.userRepository.CheckExistingUsername(username) != null)
            {
                throw new DuplicateEntityException($"User name {username} already exists!");
            }
        }

        public User CheckUsername(string username)
        {
            return this.userRepository.CheckUsername(username);
        }
        public User GetByUsername(User userCheck, string username)
        {
            if (userCheck.Role != Roles.Admin)
            {
                throw new UnauthorizedOperationException("Only Admin is authorised!");
            }
            return this.userRepository.GetByUsername(username);
        }
        public User GetByFirstName(User userCheck, string username)
        {
            if (userCheck.Role != Roles.Admin)
            {
                throw new UnauthorizedOperationException("Only Admin is authorised!");
            }
            return this.userRepository.GetByFirstName(username);
        }

        public User GetByEmail(User userCheck, string username)
        {
            if (userCheck.Role != Roles.Admin)
            {
                throw new UnauthorizedOperationException("Only Admin is authorised!");
            }
            return this.userRepository.GetByEmail(username);
        }

        public User BlockUser(User userCheck, string username)
        {
            if (userCheck.Role != Roles.Admin)
            {
                throw new UnauthorizedOperationException("Only Admin is authorised!");
            }
            return this.userRepository.BlockUser(username);
        }
        public User UnblockUser(User userCheck, string username)
        {
            return this.userRepository.UnblockUser(username);
        }
        public void CheckIfUserBlocked(string email)
        {
            this.userRepository.CheckIfUserBlocked(email);
        }
        public int GetUsersCount()
        {
            return this.userRepository.GetUsersCount();
        }

        public void RegisterUser(User user)
        {
            this.CheckIfUserBlocked(user.Email);
            this.userRepository.RegisterUser(user);
        }
        public User UpdateUser(string username, UserDto userDto)
        {
            var user = this.userRepository.GetByUsername(username);
            if (userDto.Username != username)
            {
                throw new UnauthorizedOperationException("Users can update only their personal profile!");
            }
            return this.userRepository.UpdateUser(user, userDto);
        }



    }
}
