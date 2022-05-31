using Forum1.Models;
using System.Collections.Generic;

namespace Forum1.Repositories
{
    public interface IUserRepository
    {
        public List<User> Get();
        public List<User> Get(UserQueryParameters queryParameters);
        public User CheckBlockedUser(string blockedUser);
        public User CheckExistingUsername(string username);

        public User CheckUsername(string username);
        public User GetByUsername(string username);
        public User GetByEmail(string email);
        public User GetByFirstName(string firstName);
        public User BlockUser(string username);
        public User UnblockUser(string username);
        public void CheckIfUserBlocked(string email);
        public int GetUsersCount();
        public void RegisterUser(User user);
        public User UpdateUser(User userToUpdate, UserDto userDto);




    }
}
