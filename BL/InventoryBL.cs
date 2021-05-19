using Models = models;
using Entities = DL.Entities;
using DL;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace BL
{
    public class InventoryBL
    {
        private IRepository _repo;
        public InventoryBL(IRepository repo){
            _repo = repo;
        }
        public void Replenish(Models.Location loc){
            _repo.RestockInventory(loc);
        }
        public void TakeFrom(Models.Location loc, Models.Products prod){
            int locId = _repo.GetLocationID(loc);
            int prodId = _repo.GetProductID(prod);
           _repo.ReduceInventory(locId, prodId); 
        }
        public string ShowInventory(Models.Location location){
            
            
            
            List<Entities.Inventory> InventoryList = _repo.ShowInventory(location);
            
            string list = "Inventory: ";
            
            foreach (Entities.Inventory p in InventoryList)
            {
                p.Product = _repo.GetProduct(p.ProductId);
                
                list = list + $"\n{p.Product.ToString()}";
            }
            return list;
        }
    }
}