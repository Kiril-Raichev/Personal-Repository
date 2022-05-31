using Microsoft.AspNetCore.Http;

namespace Forum1.Models
{
    
        public class CreatePost
        {
            public string ImageCaption { set; get; }
            public string ImageDescription { set; get; }
            public IFormFile MyImage { set; get; }
        }
    
}
