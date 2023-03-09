using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetById(int id);
        Task<ICollection<Product>> GetAll();
        Task Create(Product product);
        Task Edit(Product productToEdit);
        Task Delete(int id);
    }
}
