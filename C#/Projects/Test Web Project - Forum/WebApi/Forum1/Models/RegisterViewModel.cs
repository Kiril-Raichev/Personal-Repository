using System.ComponentModel.DataAnnotations;

namespace Forum1.Models
{
    public class RegisterViewModel: LoginViewModel
    {
       [Required]
        public string ConfirmPassword { get; set; }  
    }
}
