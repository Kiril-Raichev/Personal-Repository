using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Poodle_E_Learning_Platform.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public CourseVisibility Visibility { get; set; }
        public List<Section> Sections { get; set; } = new List<Section>();

        //TODO for manually filtering courses
        //public int CourseID { get; set; }

    }
}
