using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Models.Requests;
using Poodle_E_Learning_Platform.Models.Responses;
using System.Collections.Generic;

namespace Poodle_E_Learning_Platform.Services
{
    public interface IUsersService
    {
         List<User> GetAll();
         User GetById(int id, string email);
         User GetById(int id);
         User GetByEmail(string email);
         List<User> GetUsersFiltered(UserQueryParameters parameters, User user);
         User CreateUser(User user);
         UserResponse UpdateUser(int id, string email, UserRequest userChanges);
         User UpdateUser(int id, User userChanges);
         User Delete(int id, string email);
         bool IsUserExisting(string email);

    }
}