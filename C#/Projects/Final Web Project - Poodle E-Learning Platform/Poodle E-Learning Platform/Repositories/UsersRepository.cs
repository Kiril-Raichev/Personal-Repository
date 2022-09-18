using Microsoft.EntityFrameworkCore;
using Poodle_E_Learning_Platform.Data;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Models.DTOs.Mapper;
using Poodle_E_Learning_Platform.Models.Requests;
using Poodle_E_Learning_Platform.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poodle_E_Learning_Platform.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext context;
        public UsersRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<User> GetAll()
        {
            var users = this.context.Users.Include(u => u.UserCourses)
                .ThenInclude(x => x.Course)
                .ToList();
            return users;
        }

        public User GetBydID(int id)
        {
            var student = this.context.Users.Include(x => x.UserCourses)
                .ThenInclude(x => x.Course)
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (student == null)
            {
                throw new EntityNotFoundException($"Entity not found");
            }
            return student;

        }

        public bool IsUserExisting(string email)
        {
            return this.context.Users.Any(x => x.Email == email);
        }

        public User GetByEmail(string email)
        {
            var student = this.context.Users.Include(x => x.UserCourses).ThenInclude(x => x.Course).Where(u => u.Email == email).FirstOrDefault();
            return student;
        }

        public List<User> GetUsersFiltered(UserQueryParameters parameters)
        {
            string firstName = !string.IsNullOrEmpty(parameters.FirstName) ? parameters.FirstName.ToLowerInvariant() : string.Empty;
            string lastName = !string.IsNullOrEmpty(parameters.LastTime) ? parameters.LastTime.ToLowerInvariant() : string.Empty;
            string email = !string.IsNullOrEmpty(parameters.Email) ? parameters.Email.ToLowerInvariant() : string.Empty;


            IQueryable<User> result = context.Users;
            result = FilterByFirstName(result, firstName);
            result = FilterByLastName(result, lastName);
            result = FilterByEmail(result, email);
            return result.ToList();

        }
        private static IQueryable<User> FilterByFirstName(IQueryable<User> result, string firstName)
        {
            return result.Where(u => u.FirstName.Contains(firstName, StringComparison.InvariantCultureIgnoreCase));
        }

        private static IQueryable<User> FilterByLastName(IQueryable<User> result, string lastName)
        {
            return result.Where(u => u.LastName.Contains(lastName, StringComparison.InvariantCultureIgnoreCase));
        }

        private static IQueryable<User> FilterByEmail(IQueryable<User> result, string email)
        {
            return result.Where(u => u.Email.Contains(email, StringComparison.InvariantCultureIgnoreCase));
        }

        public User CreateUser(User user)
        {
            this.context.Add(user);
            context.SaveChanges();
            return user;
        }

        public UserResponse UpdateUser(int id, UserRequest userRequest)
        {
            var userToUpdate = this.GetBydID(id);
            if (userToUpdate == null)
            {
                return new UserResponse
                {
                    ErrorMessage = $"User with id {id} was not found"
                };
            }
            if (userRequest.Email != userToUpdate.Email)
            {
                if (IsUserExisting(userRequest.Email))
                {
                    return new UserResponse
                    {
                        ErrorMessage = $"User with email {userRequest.Email} already exist"
                    };
                }
            }
            userToUpdate.FirstName = userRequest.FirstName;
            userToUpdate.LastName = userRequest.LastName;
            userToUpdate.Email = userRequest.Email;
            userToUpdate.Password = userRequest.Password;
            context.SaveChanges();

            return userToUpdate.GetResponse();
        }

        public User UpdateUser(int id, User userChanges)
        {
            var userToUpdate = this.GetBydID(id);
           
            userToUpdate.FirstName = userChanges.FirstName;
            userToUpdate.LastName = userChanges.LastName;
            userToUpdate.Password = userChanges.Password;
            userToUpdate.Photo = userChanges.Photo;
            context.SaveChanges();

            return userToUpdate;
        }
        public User Delete(int id, string email)
        {
            var userToDelete = GetByEmail(email);
            if (userToDelete == null)
            {
                throw new ArgumentException();
            }
            this.context.Remove(userToDelete);
            context.SaveChanges();
            return userToDelete;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
