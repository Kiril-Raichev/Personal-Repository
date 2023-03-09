using BAL.Interfaces;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ShoppingContext db;
        public CustomerService(ShoppingContext db) 
        {
            this.db = db;
        }

        public async Task<ICollection<Customer>> GetAll()
        {
            return await this.db.Customers.ToListAsync();
        }
        public async Task<Customer> GetById(int id)
        {
            return await this.db.Customers.Where(c=>c.Id==id).FirstOrDefaultAsync();
        }
        public async Task Create(Customer customerToCreate)
        {
            this.db.Customers.Add(customerToCreate);
            await this.db.SaveChangesAsync();
        }
        public async Task Edit(Customer editedCustomer)
        {
            var customerToEdit = await this.GetById(editedCustomer.Id);
           
            if (customerToEdit == null)
            {
                throw new Exception();
            }

            customerToEdit.FName= editedCustomer.FName;
            customerToEdit.LName= editedCustomer.LName;
            customerToEdit.Address= editedCustomer.Address;
            customerToEdit.Discount= editedCustomer.Discount;

            await db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var customerToDelete = await this.GetById(id);

            if(customerToDelete == null)
            {
                throw new Exception();
            }

            db.Remove(customerToDelete);
            await db.SaveChangesAsync();
        }


    }
}
