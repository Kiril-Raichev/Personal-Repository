using Forum1.Models;
using System.Collections.Generic;

namespace Forum1.Services
{
    public interface IUserService
    {

        public List<User> Get(User userCheck, UserQueryParameters userQueryParameters);
        public void CheckExistingUsername(string username);

        public User CheckUsername(string username);
        public User GetByUsername(User adminCheck, string username);
        public User GetByFirstName(User adminCheck, string username);

        public User GetByEmail(User adminCheck, string email);
        public User BlockUser(User checkUser, string username);
        public User UnblockUser(User userCheck, string username);
        public User CheckBlockedUser(string email);
        public void CheckIfUserBlocked(string email);
        public int GetUsersCount();
        public void RegisterUser(User user);
        public User UpdateUser(string username, UserDto userDto);



    }
}
