using System.ComponentModel.DataAnnotations;
using Poodle_E_Learning_Platform.Models;

namespace Poodle_E_Learning_Platform.Web.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public bool IsChecked { get; set; } 

    }
}
