using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Models.Requests;
using Poodle_E_Learning_Platform.Models.Responses;
using System.Collections.Generic;

namespace Poodle_E_Learning_Platform.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetAll();

        User GetBydID(int id);

        User GetByEmail(string email);

        List<User> GetUsersFiltered(UserQueryParameters parameters);
        User CreateUser(User user);
        UserResponse UpdateUser(int id, UserRequest user);
        User UpdateUser(int id, User userChanges);
        User Delete(int id, string email);
        bool IsUserExisting(string email);
        void SaveChanges();
    }
}