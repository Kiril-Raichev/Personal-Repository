using Forum1.Exceptions;
using Forum1.Hellper;
using Forum1.Models;
using Forum1.Models.Mappers;
using Forum1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum1.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
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
        //Get ten most commented Posts - open for anonymous users as well
        [HttpGet("")]
        public IActionResult Get()
        {
            List<PostResponseDto> responsePosts = this.postService.Get()
                .Select(p => new PostResponseDto(p))
                .ToList();
            return this.StatusCode(StatusCodes.Status200OK, responsePosts);
        }
        //Get a Post by its Title
        [HttpGet("title")]
        public IActionResult GetByTitle([FromHeader] string login, [FromQuery] string title)
        {
            try
            {
                this.authorisationHelper.TryGetUser(login);
                var post = this.postService.GetByTitle(title);
                var postResponse = new PostResponseDto(post);   
                return this.StatusCode(StatusCodes.Status200OK, postResponse);
            }
           catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        

        //Get last ten Posts
        [HttpGet("lasttenposts")]
        public IActionResult GetLastTenPosts()
        {
            var lastten = this.postService.GetLastTenPosts();

            List<PostResponseDto> responsePosts = lastten
               .Select(p => new PostResponseDto(p))
               .ToList();

            return this.StatusCode(StatusCodes.Status200OK, responsePosts);
        }

        //filter and sort posts
        [HttpGet("filterposts")] 
        public IActionResult FilterPosts([FromQuery] PostQueryParameters queryParameters)
        {
            var response = this.postService.Get(queryParameters);
            List<PostResponseDto> postResponse = response.Select(p => new PostResponseDto(p)).ToList();
            return this.StatusCode(StatusCodes.Status200OK, postResponse);
        }


        //Create a Post - check if User is logged (registered User)
        [HttpPost("createPost")]
        public IActionResult CreatePost([FromHeader] string authorisation, [FromBody] PostDto postDto)
        {
            try
            {
                var user = this.authorisationHelper.TryGetUser(authorisation); //Is user with username "authorisation" a registered user?
                var post = this.postMapper.ConvertToModel(postDto);
                post.User = user;
                post.UserId = user.Id;
                this.postService.CreatePost(post);
                return this.StatusCode(StatusCodes.Status201Created, post);
            }
            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }

        }
        //Add Comment to a Post - check if the commenting User is a registered User
        [HttpPost("comment")]
        public IActionResult CommentPost([FromHeader] string authorisation, [FromQuery] string title, [FromBody] CommentDto commentDto)
        {
            try
            {
                var user = this.authorisationHelper.TryGetUser(authorisation);
                var comment = this.commentMapper.ConvertToComment(commentDto);  
                comment.UserId = user.Id;
                this.postService.CommentPost(title, comment);
                return this.StatusCode(StatusCodes.Status201Created, commentDto);
            }
            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }


        }

        //React to a post
        [HttpPost("{postId}/reaction")]
        public IActionResult PostReaction([FromHeader] string authorisation, [FromQuery] int postId, [FromBody] ReactionDto reactionDto)
        {
            try
            {
                var user = this.authorisationHelper.TryGetUser(authorisation);
                var reaction = this.reactionMapper.ConvertToModel(reactionDto);
                reaction.UserId = user.Id;
                this.postService.PostReaction(postId, reaction);
                return this.StatusCode(StatusCodes.Status201Created);
            }
            
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }



        // Update a Post - only the post's author can update it - authorisation in PostServices
        [HttpPut("updatepost")]

        public IActionResult UpdatePost([FromHeader] string authorisation, [FromQuery] string title, [FromBody] PostDto postDto)
        {
            try
            {
                var user = this.authorisationHelper.TryGetUser(authorisation);
                this.postService.Update(user.Id, title, postDto);
                return this.StatusCode(StatusCodes.Status201Created);
            }
            catch (UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }

        }

        //Delete a Post

        [HttpDelete("delete")]
        public IActionResult DeletePost ([FromHeader] string authorisation, [FromQuery] string title)
        {
            try
            {
               var user = this.authorisationHelper.TryGetUser(authorisation);
                this.postService.DeletePost(user.Id, title);
                return this.StatusCode(StatusCodes.Status200OK, title);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e);
            }
            catch(UnauthorizedOperationException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e);
            }
        }


    }
}
