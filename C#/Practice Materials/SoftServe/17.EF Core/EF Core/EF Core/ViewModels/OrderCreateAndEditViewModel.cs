using System.ComponentModel.DataAnnotations;

namespace EF_Core.ViewModels
{
    public class OrderCreateAndEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int SuperMarketId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
