using System.Collections.Generic;

namespace Forum1.Models
{
    public class PostQueryParameters
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}
