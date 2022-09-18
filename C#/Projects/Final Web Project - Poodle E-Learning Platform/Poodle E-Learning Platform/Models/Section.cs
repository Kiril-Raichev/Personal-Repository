using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poodle_E_Learning_Platform.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }

        public DateTime LastEdit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<Section> sectionList { get; set; } = new List<Section>();
        public int CourseId { get; set; }
        public Course Course { get; set; }



    }
}
