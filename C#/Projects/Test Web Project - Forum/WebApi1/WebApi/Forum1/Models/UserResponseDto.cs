using System.Collections.Generic;

namespace Forum1.Models
{
    public class UserResponseDto
    {
        public UserResponseDto(User user)
        {
            this.Firstname = user.FirstName;
            this.Lastname = user.LastName;
            this.Email = user.Email;
            this.Password = user.Password;
            foreach (var post in user.Posts)
            {
                this.PostsResponse.Add(post.Content);
            }
            foreach (var comment in user.Comments)
            {
                this.CommentsReponse.Add(comment.Content);
            }
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> PostsResponse { get; set; } = new List<string>();
        public List<string> CommentsReponse { get; set; } = new List<string>();
    }
}
