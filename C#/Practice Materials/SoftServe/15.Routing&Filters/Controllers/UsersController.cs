using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWithRouting.Models;
using System.Diagnostics;
using ProductsWithRouting.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ProductsWithRouting.Controllers
{
    public class UsersController : Controller
    {
        private List<User> myUsers;

        public UsersController(Data data)
        {
            myUsers = data.Users;
        }
        [Route("/Users/Index")]
        [HttpPost]
        public IActionResult Index([FromBody] string Id)
        {
            if (Id != "df2323eoT")
            {
                return RedirectToAction("Error", "Home");
            }
            return View(myUsers);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
