using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle_E_Learning_Platform.Web.Models
{
    public class Enroll
    {
        [Required]
        public string Email { get; set; }

        public int CourseId { get; set; }
    }
}
