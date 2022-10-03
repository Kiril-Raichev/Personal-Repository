using Project.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Models
{
    public class Article
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [NotMapped]
        public ICollection<string> Tags { get; set; } = new List<string>();
        public int Order { get; set; }
        public string CreatedBy { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }
        public Visibility Visibility { get; set; }
    }
}
