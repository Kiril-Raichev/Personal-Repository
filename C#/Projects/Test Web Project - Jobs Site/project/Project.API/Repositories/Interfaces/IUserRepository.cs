using Project.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User GetById(int id);

        User GetByEmail(string email);

        User CreateUser(User user);
        User UpdateUser(int id, User userChanges);
        User Delete(int id);
        bool IsUserExisting(string email);
        void SaveChanges();
    }
}
