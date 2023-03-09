using System.ComponentModel.DataAnnotations.Schema;

namespace Poodle_E_Learning_Platform.Models
{
    public class UserCourse
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Course")]
        [Column(Order = 2)]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}
