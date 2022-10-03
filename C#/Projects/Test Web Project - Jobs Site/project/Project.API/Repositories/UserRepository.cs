using Project.API.Data;
using Project.API.Models;
using Project.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<User> GetAll()
        {
            var users = this.context.Users
                .ToList();
            return users;
        }

        public User GetById(int id)
        {
            var user = this.context.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            return user;

        }

        public bool IsUserExisting(string email)
        {
            return this.context.Users.Any(x => x.Email == email);
        }

        public User GetByEmail(string email)
        {
            return this.context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User CreateUser(User user)
        {
            this.context.Add(user);
            context.SaveChanges();
            return user;
        }
        public User UpdateUser(int id, User userChanges)
        {
            var userToUpdate = this.GetById(id);

            userToUpdate.Username = userChanges.Username;
            userToUpdate.Email = userChanges.Email;
            userToUpdate.Password = userChanges.Password;
            userToUpdate.Job = userChanges.Job;
            userToUpdate.Position = userChanges.Position;
            context.SaveChanges();

            return userToUpdate;
        }
        public User Delete(int id)
        {
            var userToDelete = GetById(id);
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
