using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace EF_Core.ViewModels
{
    public class OrderDetailCreateAndEditViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [DisplayName("Product")]
        public int ProductId { get; set; }
        public float Quantity { get; set; }
    }
}
