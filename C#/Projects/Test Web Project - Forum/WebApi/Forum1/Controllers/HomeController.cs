using Forum1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Forum1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWebHostEnvironment hostingEnvironment;
        public HomeController(IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }


}
