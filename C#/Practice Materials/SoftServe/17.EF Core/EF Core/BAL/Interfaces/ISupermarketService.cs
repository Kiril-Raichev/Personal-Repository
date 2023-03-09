using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface ISupermarketService
    {
        IQueryable<SuperMarket> GetPages();
        Task<ICollection<SuperMarket>> GetAll();
        Task<SuperMarket> GetById(int id);
        Task Create(SuperMarket supermarket);
        Task Edit(SuperMarket supermarketToEdit);
        Task Delete(int id);
    }
}
