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
    public class OrderService : IOrderService
    {
        private readonly ShoppingContext db;
        private readonly ICustomerService customerService;
        private readonly ISupermarketService supermarketService;
        public OrderService(ShoppingContext db, ICustomerService customerService, ISupermarketService supermarketService)
        {
            this.db = db;
            this.customerService = customerService;
            this.supermarketService = supermarketService;
        }

        public async Task<ICollection<Order>> GetAll()
        {
            return await this.db.Orders.ToListAsync();
        }
        public async Task<Order> GetById(int id)
        {
            return await this.db.Orders.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(Order orderToCreate)
        {
            var customer = await this.customerService.GetById(orderToCreate.CustomerId);
            var supermarket = await this.supermarketService.GetById(orderToCreate.SuperMarketId);

            if(customer == null || supermarket == null)
            {
                throw new Exception();
            }
            this.db.Orders.Add(orderToCreate);
            await this.db.SaveChangesAsync();
        }
        public async Task Edit(Order editedOrder)
        {
            var customer = await this.customerService.GetById(editedOrder.CustomerId);
            var supermarket = await this.supermarketService.GetById(editedOrder.SuperMarketId);
            if(customer == null || supermarket == null)
            {
                throw new Exception();
            }

            var orderToEdit = await this.GetById(editedOrder.Id);
            
            if(orderToEdit == null)
            {
                throw new Exception();
            
            }
            orderToEdit.OrderDate = editedOrder.OrderDate;
            orderToEdit.CustomerId = editedOrder.CustomerId;
            orderToEdit.SuperMarketId = editedOrder.SuperMarketId;

            await db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var orderToDelete = await this.GetById(id);
            
            if(orderToDelete == null)
            {
                throw new Exception();
            }
           
            db.Remove(orderToDelete);
            await db.SaveChangesAsync();
        }
    }
}
