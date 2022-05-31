using Forum1.Models;
using Forum1.Exceptions;
using Forum1.Services;

namespace Forum1.Hellper
{
    public class AuthorisationHelper
    {
        private IUserService userService;

        public AuthorisationHelper(IUserService userService)
        {
            this.userService = userService;
        }

        public User TryGetUser(string username)
        {
            try
            {
                return this.userService.CheckUsername(username);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid username");
            }
        }

        public User TryGetBlockedUser(string username)
        {
            try
            {
                return this.userService.CheckBlockedUser(username);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("No such blocked user");
            }
        }


    }
}
