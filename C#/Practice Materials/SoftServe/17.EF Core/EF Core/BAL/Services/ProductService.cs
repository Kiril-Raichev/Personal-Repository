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
    public class ProductService : IProductService
    {
        private readonly ShoppingContext db;

        public ProductService(ShoppingContext db) 
        {
            this.db = db;
        }

        public async Task Create(Product product)
        {
            this.db.Products.Add(product);
            await this.db.SaveChangesAsync();
        }
        public async Task Edit(Product editedProduct)
        {
            var productToEdit = await this.GetById(editedProduct.Id);
            
            if(productToEdit == null)
            {
                throw new Exception();
            }
           
            productToEdit.Name = editedProduct.Name;
            productToEdit.Price = editedProduct.Price;

            await db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {

            var productToDelete = await this.GetById(id);
            
            if (productToDelete == null)
            {
                throw new Exception();
            }
            
            db.Remove(productToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await this.db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await this.db.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
