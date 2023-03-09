using System.ComponentModel.DataAnnotations;

namespace Poodle_E_Learning_Platform.Web.Models
{
    public class LoginViewModel
    {
        
        [Required]
        [Display(Name = "E-mail")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
