using Microsoft.AspNetCore.Mvc;
using MoqProject.Services;

namespace MoqProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebsiteController
    {
        private readonly IWebsiteService websiteService;
        private readonly IPostEditService postEditService;
        private readonly IAllowEditService allowEditService;

        public WebsiteController(
          IWebsiteService websiteService,
          IPostEditService postEditService,
          IAllowEditService allowEditService
        )
        {
            this.websiteService = websiteService;
            this.postEditService = postEditService;
            this.allowEditService = allowEditService;
        }

        [HttpPost]
        public string EditPosts(ILoginInfo user)
        {
            var result = allowEditService.CanUserEdit(user.Role);
            if (result)
            {
                postEditService.Edit(websiteService.Posts());
                return "edit success";
            }
            else
            {
                return "edit fail";
            }
        }
    }
}
