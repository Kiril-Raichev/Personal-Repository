using Forum1.Models;
using Forum1.Exceptions;
using Forum1.Services;

namespace Forum1.Hellper
{
    public class AuthorisationHelper
    {
        private const string AuthorisationMessage = "Only admins are authorised!";
        private const string AuthenticationMessage = "Authentication failed - check credentials!";
        
        private IUserService userService;

        public AuthorisationHelper(IUserService userService)
        {
            this.userService = userService;
        }

        public User TryGetUser (string username)
        {
            try
            {
                return this.userService.CheckUsername(username);
            } catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException(AuthenticationMessage);
            }
        }

        public User TryGetUser(string username, string password)
        {
            var user = this.userService.CheckUsername(username);
            if (user.Password!=password)
            {
                throw new AuthenticationException(AuthenticationMessage);
            }
            return user;
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
