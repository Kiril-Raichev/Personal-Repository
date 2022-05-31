using System.Collections.Generic;

namespace Forum1.Models
{
    public class PostResponseDto
    {
        public PostResponseDto(Post post)
        {
            this.Title = post.Title;
            this.Content = post.Content;
            foreach (var comment in post.Comments)
            {
                this.CommentsDto.Add(comment.Content);
                this.CommentsDto.Add(comment.User.Username);
            }
            foreach (var reaction in post.PostReactions)
            {
                this.ReactionsDto.Add(reaction.Value);
            }
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> CommentsDto { get; set; } = new List<string>();
        public List<Reactions> ReactionsDto { get; set; } = new List<Reactions>();
    }
}
