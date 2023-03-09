using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poodle_E_Learning_Platform.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string ImgSource { get; set; }
        public CourseVisibility Visibility { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Section> Sections { get; set; } = new HashSet<Section>();

        public virtual ICollection<UserCourse> Users { get; set; } = new HashSet<UserCourse>();

        
    }
}
