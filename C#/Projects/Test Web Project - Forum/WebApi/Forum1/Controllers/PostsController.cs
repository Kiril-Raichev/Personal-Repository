using Forum1.Hellper;
using Forum1.Models;
using Forum1.Models.Mappers;
using Forum1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Forum1.Exceptions;



namespace Forum1.Controllers
{
    public class PostsController : Controller
    {
        private readonly AuthorisationHelper authorisationHelper;
        private readonly PostMapper postMapper;
        private readonly CommentMapper commentMapper;
        private readonly ReactionMapper reactionMapper;
        private readonly IPostService postService;


        //A new instance of the controller is created at every request
        public PostsController(AuthorisationHelper authorisationHellper, ReactionMapper reactionMapper, PostMapper postMapper, CommentMapper commentMapper, IPostService postService)
        {
            this.authorisationHelper = authorisationHellper;
            this.reactionMapper = reactionMapper;
            this.postMapper = postMapper;
            this.commentMapper = commentMapper;
            this.postService = postService;
        }
        public IActionResult Index()
        {
            List<PostResponseDto> responsePosts = this.postService.Get()
                  .Select(p => new PostResponseDto(p))
                  .ToList();
            return View(model: responsePosts);
        }
        public IActionResult Create ()
        {
            var postDto = new PostDto();
            return this.View(postDto);
        }
       [HttpPost]
        public IActionResult Create (PostDto postDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(postDto);
            }

            Post post = this.postMapper.ConvertToModel(postDto);
            string username = TempData["username"].ToString();
            var user = this.authorisationHelper.TryGetUser(username);
            post.User = user;
            post.UserId = user.Id;

            this.postService.CreatePost(post);
            return this.RedirectToAction(actionName: "Index", controllerName: "Posts");
        }
        public IActionResult Edit(string title)
        {
            Post post = this.postService.GetByTitle(title);
            return this.View(model: post);
        }
        [HttpPost]
        public IActionResult Edit(PostDto postDto)
		{
            Post post = postMapper.ConvertToModel(postDto);
            Post dataPost = this.postService.GetByTitle(post.Title);
            string username = TempData["username"].ToString();


            if (dataPost.User.Username!=username)
			{
                this.ModelState.AddModelError("Username", "Only post author can edit it.");
                return this.View(model: postDto);
             }
            int userId = dataPost.User.Id;
            string title = dataPost.Title;  

            this.postService.Update(userId, title, postDto);
            return this.RedirectToAction(actionName: "Index", controllerName: "Posts");

        }

        public IActionResult Comment ()
		{
            var commentDto = new CommentDto();
            return this.View(commentDto);
		}
        [HttpPost]
        public IActionResult Comment (CommentDto commentDto)
		{
            if (!this.ModelState.IsValid)
            {
                return this.View(commentDto);
            }
            Comment comment = this.commentMapper.ConvertToComment(commentDto);
            string username = TempData["username"].ToString();
            var user = this.authorisationHelper.TryGetUser(username);
            comment.User = user;    
            comment.UserId = user.Id;
            string postTitle = commentDto.PostTitle;
            this.postService.CommentPost(postTitle, comment);
            return this.RedirectToAction(actionName: "Index", controllerName: "Posts");

        }

        

    }
}
