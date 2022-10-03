using Project.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models
{
    public class ArticleEditViewModel
    {
        public int articleId { get; set; }
        public string DuplicateTitleError = "Title is already in use by another article";
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        public string Body { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }
        public string CreatedBy { get; set; }
        public Visibility Visibility { get; set; }

    }
}
