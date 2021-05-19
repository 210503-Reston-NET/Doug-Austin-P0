using Models = models;
using Entities = DL.Entities;
using DL;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace BL
{
    public class OrderBL
    {
        private IRepository _repo;

        public List<Models.Products> PrepProducts()
        {
            return _repo.GetAllProducts();
        }
        public OrderBL(IRepository repo){
            _repo = repo;
        }
        public Models.Order CreateOrder(List <Models.Products> items, Models.AppUser cust, Models.Location loc) {
            Models.Order newOrder = new Models.Order(items, cust, loc);
            return _repo.AddOrder(newOrder, newOrder.Customer, newOrder.Location);
        }   
    }
}