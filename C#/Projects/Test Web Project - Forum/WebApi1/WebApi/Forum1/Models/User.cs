using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Forum1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Reaction> PostReactions { get; set; } = new List<Reaction>();


        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return this.Username == other.Username;
            }
            return false;
        }

        public override string ToString() => JsonSerializer.Serialize<User>(this);
        public override int GetHashCode()
        {
            return this.Username.GetHashCode();
        }

    }
}
