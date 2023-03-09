using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IOrderDetailsService
    {
        Task<OrderDetail> GetById(int id);
        Task<ICollection<OrderDetail>> GetByOrderId(int id);
        Task Create(OrderDetail orderDetails);
        Task Edit(OrderDetail orderDetailToEdit);
        Task<OrderDetail> Delete(int id);
    }
}
