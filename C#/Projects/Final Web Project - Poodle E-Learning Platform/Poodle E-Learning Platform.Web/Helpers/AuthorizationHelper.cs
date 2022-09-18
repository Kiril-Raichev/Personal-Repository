using System.Linq;

using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Services;


using Microsoft.AspNetCore.Http;
using System;

namespace Poodle_E_Learning_Platform.Helpers
{
	public class AuthorizationHelper
	{
		private readonly IUsersService usersService;
		private readonly IHttpContextAccessor httpContextAccessor;
		public AuthorizationHelper(IUsersService usersService, IHttpContextAccessor httpContextAccessor)
		{
			this.usersService = usersService;
			this.httpContextAccessor = httpContextAccessor;
		}

		public User TryGetUser(string username)
		{
			try
			{
				return this.usersService.GetByEmail(username);
			}
			catch (Exception )
			{
				throw new EntityNotFoundException("Invalid Email!");
			}
		}
		public User TryGetUser(string username, string password)
		{
			//TODO show in page if password is wrong
			var user = this.TryGetUser(username);
			if (user.Password != password)
			{
				throw new AuthenticationException("Invalid Password!");
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
