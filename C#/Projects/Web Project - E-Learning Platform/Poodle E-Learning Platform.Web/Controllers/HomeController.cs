using Microsoft.AspNetCore.Mvc;

namespace Poodle_E_Learning_Platform.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Testimonials()
        {
            return View();
        }

        public IActionResult Team()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Copyright()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}