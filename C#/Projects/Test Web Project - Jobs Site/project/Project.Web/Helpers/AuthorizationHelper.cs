using Microsoft.AspNetCore.Http;
using Project.API.Models;
using Project.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Helpers
{
    public class AuthorizationHelper
    {
        private readonly IUserRepository userRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AuthorizationHelper(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public User TryGetUser(string email)
        {
            try
            {
                return this.userRepository.GetByEmail(email);
            }
            catch (Exception)
            {
                throw new Exception("Invalid Email!");
            }
        }
        public User TryGetUser(string email, string password)
        {
            var user = this.TryGetUser(email);
            if (user.Password != password)
            {
                throw new Exception("Invalid Password!");
            }
            return user;
        }
        public string CurrentUser
        {
            get
            {
                return this.httpContextAccessor.HttpContext.Session.GetString("CurrentUser");
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.httpContextAccessor.HttpContext.Session.SetString("CurrentUser", value);
                }

                if (value == null)
                {
                    this.httpContextAccessor.HttpContext.Session.Remove("CurrentUser");
                }
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.httpContextAccessor.HttpContext.Session.Keys.Contains("CurrentUser");
            }
        }
    }
}
