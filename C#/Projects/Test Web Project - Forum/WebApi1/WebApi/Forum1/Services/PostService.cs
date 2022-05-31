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
                throw new UnauthorizedOperationException("Users can update only their personal posts!");
            }

            return this.postRepository.Update(postUpdate, postDto);

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




    }



}
