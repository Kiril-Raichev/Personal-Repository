using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Poodle_E_Learning_Platform.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }

        //TODO restricted by date or specific users/section
        //TODO configure to be opened as a new page or be embedded on the main course page


    }
}
