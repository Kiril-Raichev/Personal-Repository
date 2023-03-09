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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly ShoppingContext db;
        private readonly IProductService productService;
        public OrderDetailsService(ShoppingContext db, IProductService productService)
        {
            this.db = db;
            this.productService = productService;
        }
        public async Task<OrderDetail> GetById(int id)
        {
            return await this.db.OrdersDetails.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ICollection<OrderDetail>> GetByOrderId(int id)
        {
            return await this.db.OrdersDetails.Where(c => c.OrderId == id).ToListAsync();
        }
        public async Task Create(OrderDetail orderDetails)
        {
            var product = productService.GetById(orderDetails.ProductId);
            
            if(product == null)
            {
                throw new Exception();
            }
            
            this.db.OrdersDetails.Add(orderDetails);
            await this.db.SaveChangesAsync();
        }
        public async Task Edit(OrderDetail editedOrderDetails)
        {
            var orderDetailsToEdit = await this.GetById(editedOrderDetails.Id);
            
            if(orderDetailsToEdit == null) 
            {
                throw new Exception();
            
            }
            orderDetailsToEdit.ProductId = editedOrderDetails.ProductId;
            orderDetailsToEdit.Quantity = editedOrderDetails.Quantity;

            await db.SaveChangesAsync();
        }
        public async Task<OrderDetail> Delete(int id)
        {
            
            var orderDetailToDelete = await this.GetById(id);
            
            if(orderDetailToDelete == null)
            {
                throw new Exception();          
            }

            db.Remove(orderDetailToDelete);
            await db.SaveChangesAsync();
            return orderDetailToDelete;
        }


    }
}
