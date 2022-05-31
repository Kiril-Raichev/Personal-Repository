using Forum1.Services;
using Forum1.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum1.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postServices;

        public PostController(IPostService postService)
        {
            this.postServices = postService;
        }

        public  IActionResult index();
        {
            var post = this.postServices.Get();
            
            
        }
    }
}
