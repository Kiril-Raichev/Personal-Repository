using Poodle_E_Learning_Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle_E_Learning_Platform.Web.Models
{
    public class SectionEditViewModel
    {

        public string DuplicateTitleError = "Title is already in use by another course";
        public int courseId { get; set; }
        public int sectionId { get; set; }
        public DateTime LastEdit { get; set; }
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        public string Content { get; set; }
        [Display(Name = "Start of restrictiondate(optional)")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End of restriction date(optional)")]
        public DateTime? EndDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [Display(Name = "List Placement Order Number")]
        public int Order { get; set; }
    }
}
