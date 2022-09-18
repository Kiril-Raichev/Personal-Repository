using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Models.Requests;
using Poodle_E_Learning_Platform.Models.Responses;
using Poodle_E_Learning_Platform.Repositories;
using System;
using System.Collections.Generic;

namespace Poodle_E_Learning_Platform.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository repository;
        public UsersService(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public List<User> GetAll()
        {
            var users = this.repository.GetAll();
            return users;
        }

        public User GetById(int id, string email)
        {
            try
            {
                this.repository.GetBydID(id);
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException($"User with id {id} was not found");
            }
            var username = this.repository.GetByEmail(email);
            if (username.Role != UserRole.Teacher)
            {
                throw new UnauthorizedOperationException("Only teachers are allowed to do this!");
            }
            return this.repository.GetBydID(id);
        }
        public User GetById(int id)
        {
            try
            {
                this.repository.GetBydID(id);
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException($"User with id {id} was not found");
            }
            return this.repository.GetBydID(id);
        }
        public User GetByEmail(string email)
        {
            var username = this.repository.GetByEmail(email);
            if (username == null)
            {
                throw new EntityNotFoundException($"User with email {email} was not found");
            }



            return this.repository.GetByEmail(email);
        }

        public List<User> GetUsersFiltered(UserQueryParameters parameters, User user)
        {
            if (user.Role != UserRole.Teacher)
            {
                throw new UnauthorizedOperationException($"You are not authorized to do this");
            }
            return this.repository.GetUsersFiltered(parameters);
        }



        public User CreateUser(User user)
        {
            //TODO Should be true
            bool UsernameExists = false;

            try
            {
                this.repository.GetByEmail(user.Email);
            }
            catch (Exception)
            {
                UsernameExists = false;
            }
            if (UsernameExists)
            {
                throw new DuplicateEntityException($"User with E-mail {user.Email} already exists!");
            }
            var userr = this.repository.CreateUser(user);
            return userr;
        }

        public UserResponse UpdateUser(int id, string email, UserRequest userChanges)
        {
            var loggedUser = this.repository.GetByEmail(email);
            if (loggedUser.Id != id)
            {
                throw new UnauthorizedOperationException($"You are not allowed to do this!");
            }
            var updatedUser = this.repository.UpdateUser(id, userChanges);

            return updatedUser;
        }
        public User UpdateUser(int id, User userChanges)
        {

            var updatedUser = this.repository.UpdateUser(id, userChanges);

            return updatedUser;
        }
        public User Delete(int id, string email)
        {
            var userToDelete = this.repository.GetByEmail(email);
            if (userToDelete.Id != id)
            {
                throw new UnauthorizedOperationException($"You are not allowed to do this!");
            }
            return this.repository.Delete(userToDelete.Id, email);
        }


        public bool IsUserExisting(string email)
        {
            var user = this.repository.GetByEmail(email);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
