using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Poodle_E_Learning_Platform.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public UserRole Role { get; set; } = UserRole.Student;

        public virtual ICollection<UserCourse> UserCourses { get; set; } = new HashSet<UserCourse>();

        public override string ToString() => JsonSerializer.Serialize<User>(this);
    }
}
