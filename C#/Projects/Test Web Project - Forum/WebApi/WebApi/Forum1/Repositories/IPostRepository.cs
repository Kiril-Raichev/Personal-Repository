using Forum1.Models;
using System.Collections.Generic;

namespace Forum1.Repositories
{
    public interface IPostRepository
    {
        public List<Post> Get();
        public Post GetByTitle(string title);
        public Post GetById(int id);

        public Post CreatePost(Post post);
        public Post UpdatePost(Post postUpdate, PostDto postDto);
        public Post DeletePost(int id);
        public Comment CommentPost(Post post, Comment comment);
        public List<Post> GetLastTenPosts();
        //public Post Update(Post postUpdate, PostDto postDto);


    }
}
