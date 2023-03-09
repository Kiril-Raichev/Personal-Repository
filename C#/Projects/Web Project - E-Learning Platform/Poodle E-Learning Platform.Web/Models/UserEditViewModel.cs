using Poodle_E_Learning_Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle_E_Learning_Platform.Web.Models
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        public string DuplicateEmailError = "Email is already in use by another user";
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }    

        public string Password { get; set; }
        [Display(Name ="Photo(Link)")]
        public string Photo { get; set; }
    }
}
