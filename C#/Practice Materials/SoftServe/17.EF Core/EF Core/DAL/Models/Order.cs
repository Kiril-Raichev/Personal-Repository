using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("SuperMarket")]
        [DisplayName("SuperMarket")]
        public int SuperMarketId { get; set; }
        public DateTime OrderDate { get; set; }
     }
}
