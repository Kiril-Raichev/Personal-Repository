using Microsoft.AspNetCore.Mvc;
using DI.Web.Services.Interfaces;
using System.Threading;

namespace DI.Web.Controllers
{
    public class CookController: Controller
    {
        private readonly ICookService cookService;
        private readonly ICookService cookService2;

        public CookController(ICookService cookService, ICookService cookService2)
        {
            this.cookService = cookService;
            this.cookService2 = cookService2;
        }
        [HttpGet]
        public IActionResult Cooking()
        {
            ViewData["Message"] = this.cookService.Cooking() + this.cookService2.Cooking();
            this.cookService.Cooking();
            return View();
            //return Ok();
        }
    }
}
