using System.ComponentModel.DataAnnotations;

namespace Poodle_E_Learning_Platform.Models.Requests
{
    public class UserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
