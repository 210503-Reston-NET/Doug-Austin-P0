using Models = models;
using Entities = DL.Entities;
using System.Collections.Generic;
namespace DL
{
    public interface IRepository
    {
         public Models.Order AddOrder(Models.Order order, Models.AppUser user, Models.Location location);
         public Models.AppUser AddUser(Models.AppUser user);

         public int GetUserID (Models.AppUser user);

         public int GetLocationID (Models.Location location);

         public Models.Products AddLineItem (Models.Products product, int orderId);

        public void ReduceInventory(int locId, int prodId);

        public List<Entities.User> GetAllUsers();

        public void RestockInventory(Models.Location loc);

        public List<Entities.Inventory> ShowInventory(Models.Location loc);

        public Entities.Product GetProduct(int pid);

        public int GetProductID(Models.Products p);
        public List<Models.Products> GetAllProducts();

        }
}