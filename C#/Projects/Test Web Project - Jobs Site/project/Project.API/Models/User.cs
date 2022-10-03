using Project.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Models
{

    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }

        public UserRole Role { get; set; } = UserRole.User;

    }
}
