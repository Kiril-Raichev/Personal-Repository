using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface ICustomerService
    {
        Task<ICollection<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task Create(Customer customer);
        Task Edit(Customer customerToEdit);
        Task Delete(int id);
    }
}
