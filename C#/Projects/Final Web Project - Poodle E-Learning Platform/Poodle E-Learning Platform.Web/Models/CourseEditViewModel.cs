using System;
using System.ComponentModel.DataAnnotations;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Web.Models;

namespace Poodle_E_Learning_Platform.Web.Models
{
    public class CourseEditViewModel
    {
        public int courseId { get; set; }
        public string DuplicateTitleError = "Title is already in use by another course";
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        public string Description { get; set; }
        public CourseVisibility Visibility { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [Range(1, 1440, ErrorMessage = "Value for {0} must be between {1} and {2} minutes!")]
        [Display(Name = "Duration(Minutes)")]
        public int Duration { get; set; }
        public string ImgSource { get; set; }



    }
}
