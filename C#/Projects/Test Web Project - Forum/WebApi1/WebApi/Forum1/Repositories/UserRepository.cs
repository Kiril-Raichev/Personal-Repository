

using Forum1.Models;
using Forum1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Forum1.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum1.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private readonly List<User> blockedUsers;
        private readonly ApplicationContext context;
        public UserRepository(ApplicationContext context)
        {
            //     this.blockedUsers = new List<User>();
            this.context = context;

        }
        private IQueryable<User> UserQuery
        {
            get
            {
                return this.context.Users
                    .Include(u => u.Posts)
                    .Include(u => u.Comments);
            }
        }
        public List<User> Get()
        {
            return this.UserQuery.ToList();
        }

        public List<User> Get(UserQueryParameters queryParameters)
        {
            string username = !string.IsNullOrEmpty(queryParameters.Username) ? queryParameters.Username.ToLowerInvariant() : string.Empty;
            string email = !string.IsNullOrEmpty(queryParameters.Email) ? queryParameters.Email.ToLowerInvariant() : string.Empty;
            string firstName = !string.IsNullOrEmpty(queryParameters.FirstName) ? queryParameters.FirstName.ToLowerInvariant() : string.Empty;

            IQueryable<User> result = this.context.Users;

            result = FilterByUsername(result, username);
            result = FilterByEmail(result, email);
            result = FilterByFirstName(result, firstName);

            return result.ToList();
        }
        private static IQueryable<User> FilterByUsername(IQueryable<User> result, string username)
        {
            return result
                .Include(user => user.Posts)
                .Include(user => user.Comments)
                .Where(user => user.Username.Contains(username));
        }
        private static IQueryable<User> FilterByEmail(IQueryable<User> result, string email)
        {
            return result
                .Include(user => user.Posts)
                .Include(user => user.Comments)
                .Where(user => user.Email.Contains(email));
        }
        private static IQueryable<User> FilterByFirstName(IQueryable<User> result, string firstName)
        {
            return result.Where(user => user.FirstName.Contains(firstName));

        }

        public User CheckBlockedUser(string username)
        {
            var blockedUserQuery = this.context.BlockedUsers.Where(u => u.Username == username);
            var blockedUser = blockedUserQuery.FirstOrDefault();
            return blockedUser ?? throw new EntityNotFoundException("User is blocked");
        }
        public User CheckExistingUsername(string username)
        {
            var user = this.context.Users.Where(u => u.Username == username).FirstOrDefault();
            return user;
        }
        public User CheckUsername(string username)
        {
            var user = this.context.Users.Where(u => u.Username == username).FirstOrDefault();
            return user ?? throw new EntityNotFoundException($"No user registered under username {username}. ");
        }
        public User GetByEmail(string email)
        {
            var user = this.context.Users.Where(u => u.Email == email).FirstOrDefault();
            return user ?? throw new EntityNotFoundException($"No user registered with email{email}.");
        }
        public User GetByFirstName(string firstName)
        {
            var user = this.context.Users.Where(u => u.FirstName == firstName).FirstOrDefault();
            return user ?? throw new EntityNotFoundException($"No user registered under first name {firstName}.");
        }

        public User GetByUsername(string username)
        {
            var user = this.context.Users
                .Include(user => user.Posts)
                .Include(user => user.Comments)
                .Where(u => u.Username == username).FirstOrDefault();
            return user ?? throw new EntityNotFoundException($"No user registered under user name {username}.");
        }
        public User BlockUser(string username)
        {
            var user = this.context.Users.Where(u => u.Username == username).FirstOrDefault();
            //this.context.BlockedUsers.Add(user);
            this.context.Users.Remove(user);
            this.context.SaveChanges();

            return user ?? throw new EntityNotFoundException($"No user registered with user name {username}.");
        }
        public User UnblockUser(string username)
        {
            var user = this.context.BlockedUsers.Where(u => u.Username == username).FirstOrDefault();
            this.context.Users.Add(user);
            this.context.BlockedUsers.Remove(user);
            this.context.SaveChanges();
            return user ?? throw new EntityNotFoundException($"No blocked user registered with user name {username}.");
        }
        public void CheckIfUserBlocked(string email)
        {
            var user = this.context.BlockedUsers.Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                throw new UnauthorizedOperationException("User is blocked");
            }
        }
        public int GetUsersCount()
        {
            return this.context.Users.Count();
        }

        public void RegisterUser(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public User UpdateUser(User userToUpdate, UserDto userDto)
        {
            if (userDto.FirstName != "string") { userToUpdate.FirstName = userDto.FirstName; }
            if (userDto.LastName != "string") { userToUpdate.LastName = userDto.LastName; }
            if (userDto.Email != "string") { userToUpdate.Email = userDto.Email; }
            if (userDto.Password != "string") { userToUpdate.Password = userDto.Password; }
            this.context.SaveChanges();
            return userToUpdate;
        }


    }
}
