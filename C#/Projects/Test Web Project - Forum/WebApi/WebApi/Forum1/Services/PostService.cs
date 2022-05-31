using Forum1.Exceptions;
using Forum1.Models;
using Forum1.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Forum1.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public List<Post> Get()
        {
            return this.postRepository.Get();

        }

        public List<Post> Get(PostQueryParameters queryParameters)
        {
            return this.postRepository.Get(queryParameters);
        }

        public Post CreatePost(Post post)
        {
            postRepository.CreatePost(post);
            return post;
        }

        public Post GetByTitle(string title)
        {
            return postRepository.GetByTitle(title);
        }
        public Post GetPostById(int id)
        {
            var post = postRepository.GetPostById(id);
            return post;
        }

        public Comment CommentPost(string title, Comment comment)
        {
            var post = this.GetByTitle(title);
            comment.PostId = post.Id;
            this.postRepository.CommentPost(post, comment);
            return comment;
        }

        public void PostReaction(int postId, Reaction reaction)
        {
            var post = this.postRepository.GetById(postId);
            reaction.PostId = post.Id;
            this.postRepository.PostReaction(post, reaction);
        }
        public List<Post> GetLastTenPosts()
        {
            return this.postRepository.GetLastTenPosts();
        }

        public Post Update(int userId, string title, PostDto postDto)
        {
            var postUpdate = this.GetByTitle(title);

            if (postUpdate.UserId != userId)
            {
                throw new UnauthorizedOperationException("Users can update only their own posts!");
            }

            return this.postRepository.UpdatePost(postUpdate, postDto);

        }
        public string DeletePost(int userId, string title)
        {
            var postDelete = this.GetByTitle(title);
            if (postDelete.UserId != userId)
            {
                throw new UnauthorizedOperationException("Users can delete only their personal posts!");
            }
            return this.postRepository.DeletePost(postDelete);
        }

        public void DeletePost(int id, User user)
        {
            if (user.Role.Equals(1))
            {
                throw new UnauthorizedOperationException("You can onley delete post that you created");
            }
            this.postRepository.DeletePost(id);
        }

        
    }
}
