using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IOrderService
    {
        Task<ICollection<Order>> GetAll();
        Task<Order> GetById(int id);
        Task Create(Order order);
        Task Edit(Order orderToEdit);
        Task Delete(int id);
    }
}
