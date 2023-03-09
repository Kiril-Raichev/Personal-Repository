using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization.Controllers
{
    public class UserController : Controller
    {
        private ShoppingContext db;
        public UserController(ShoppingContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //Blank fields check
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Email duplication check
            var user = await db.Users.Where(u => u.Email == model.Email).FirstOrDefaultAsync();
            if (user == null)
            {
                var newUser = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                };
                await db.Users.AddAsync(newUser);
                await db.SaveChangesAsync();
                await Authenticate(newUser);

            }
            else
            {
                ModelState.AddModelError("Email", "Email is already in use");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await db.Users.Where(u => u.Email == model.Email).FirstOrDefaultAsync();
            //Email check
            if (user == null)
            {
                ModelState.AddModelError("Email", "User with this email does not exist");
                return View(model);
            }
            else
            {
                await Authenticate(user);
            }

            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim("Type",user.Type.ToString())
        };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
        [Authorize(Policy = "Type")]
        public async Task<IActionResult> Discount()
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            return View(user.Discount);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            var users = await db.Users.ToListAsync();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {

            var user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(User user)
        {
            var userToEdit = await db.Users.FindAsync(user.Id);

            userToEdit.Role = user.Role;
            userToEdit.Type = user.Type;
            userToEdit.Discount = user.Discount;

            await db.SaveChangesAsync();
            var users = await db.Users.ToListAsync();
            return View(nameof(Admin), users);
        }

    }
}
