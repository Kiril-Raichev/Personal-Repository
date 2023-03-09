using DAL.Data;
using DAL.Models;
using BAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services
{
    public class SupermarketService : ISupermarketService
    {
        private readonly ShoppingContext db;
        public SupermarketService(ShoppingContext db)
        {
            this.db = db;
        }

        public IQueryable<SuperMarket> GetPages()
        {
            return this.db.SuperMarkets;
        }
        public async Task<ICollection<SuperMarket>> GetAll()
        {
            return await this.db.SuperMarkets.ToListAsync();
        }
        public async Task<SuperMarket> GetById(int id)
        {
            return await this.db.SuperMarkets.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(SuperMarket supermarketToCreate)
        {
            this.db.SuperMarkets.Add(supermarketToCreate);
            await this.db.SaveChangesAsync();
        }
        public async Task Edit(SuperMarket editedSupermarket)
        {
            var supermarketToEdit = await this.GetById(editedSupermarket.Id);
            
            if(supermarketToEdit == null)
            {
                throw new Exception();
            }
            
            supermarketToEdit.Name = editedSupermarket.Name;
            supermarketToEdit.Address = editedSupermarket.Address;

            await db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var supermarketToDelete = await this.GetById(id);
            
            if (supermarketToDelete == null)
            {
                throw new Exception();
            }
            
            db.Remove(supermarketToDelete);
            await db.SaveChangesAsync();
        }
    }
}
