using Forum1.Models;
using System.Collections.Generic;

namespace Forum1.Services
{
    public interface IPostService
    {
        public List<Post> Get();
        public List<Post> Get(PostQueryParameters queryParameters);
        public Post GetByTitle(string title);
        public Post GetPostById(int id);
        public Post CreatePost(Post post);
        public Comment CommentPost(string title, Comment comment);
        public List<Post> GetLastTenPosts();
        public Post Update(int userId, string title, PostDto postDto);
        public void PostReaction(int postId, Reaction reaction);
        public string DeletePost(int userId, string title);



    }
}
