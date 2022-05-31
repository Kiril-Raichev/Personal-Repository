using Forum1.Data;
using Forum1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum1.Repositories
{
    public class PostRepository : IPostRepository
    {
        // private readonly List<Post> posts;
        private readonly ApplicationContext context;

        public PostRepository(ApplicationContext context)
        {
            this.context = context;
        }
        private IQueryable<Post> PostsQuery
        {
            get
            {
                return this.context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Comments)
                    .Include(p => p.PostReactions);
            }

        }
        public List<Post> Get()
        {

            var query = this.PostsQuery.ToList();
            var list = query
                 .OrderBy(post => post.Comments.Count)
                 .TakeLast(10)
                 .ToList();
            list.Reverse();
            return list;

        }
        public Post GetByTitle(string title)
        {
            var post = this.context.Posts.Where(b => b.Title == title)
                .Include(post => post.User)
                .Include(post => post.Comments)
                .Include(post => post.PostReactions)
                .FirstOrDefault();
            return post;
        }
        public Post GetById(int id)
        {
            var post = this.context.Posts.Where(b => b.Id == id).FirstOrDefault();
            return post;
        }

        public List<Post> Get(PostQueryParameters queryParameters)
        {
            string title = !string.IsNullOrEmpty(queryParameters.Title) ? queryParameters.Title : string.Empty;
            string username = !string.IsNullOrEmpty(queryParameters.Username) ? queryParameters.Username : string.Empty;

            IQueryable<Post> result = this.context.Posts;

            result = FilterByUsername(result, username);
            result = FilterByTitle(result, title);
            result = result.OrderBy(post => post.Title);
            // result = result.OrderBy(post=>post.User.Username);  
            return result.ToList();
        }
        public IQueryable<Post> FilterByUsername(IQueryable<Post> result, string username)
        {
            return result
                .Include(post => post.User)
                .Include(post => post.Comments)
                .Include(post => post.PostReactions)
                .Where(post => post.User.Username.Contains(username));
        }

        public IQueryable<Post> FilterByTitle(IQueryable<Post> result, string title)
        {
            return result
                .Where(post => post.Title.Contains(title));
        }

        public Post CreatePost(Post post)
        {
            this.context.Posts.Add(post);
            this.context.SaveChanges();
            return post;
        }
        public Comment CommentPost(Post post, Comment comment)
        {
            var createdComment = this.context.Comments.Add(comment);
            this.context.SaveChanges();
            return createdComment.Entity;
        }
        public void PostReaction(Post post, Reaction reaction)
        {
            this.context.PostReactions.Add(reaction);
            this.context.SaveChanges();
        }
        public List<Post> GetLastTenPosts()
        {
            List<Post> lastTenPosts = new List<Post>();
            int j = this.context.Posts.Count() - 1;
            var postlist = this.context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ToList();
            int count = 0;
            while (j >= 0 && count < 11)
            {
                lastTenPosts.Add(postlist[j]);
                j--;
                count++;
            }

            return lastTenPosts;

        }

        public Post Update(Post postUpdate, PostDto postDto)
        {
            postUpdate.Title = postDto.Title;
            postUpdate.Content = postDto.Content;
            this.context.SaveChanges();
            return postUpdate;
        }

        public string DeletePost(Post postDelete)
        {
            var post = this.context.Posts.Where(p => p.Id == postDelete.Id).FirstOrDefault();
            this.context.Posts.Remove(post);
            this.context.SaveChanges();
            return postDelete.Title;
        }


    }
}