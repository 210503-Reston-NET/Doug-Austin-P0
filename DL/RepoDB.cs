using Models = models;
using Entities = DL.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace DL
{
    public class RepoDB : IRepository
    {
        private Entities.DougsExoticPetStoreContext _context;
        public RepoDB(Entities.DougsExoticPetStoreContext context)
        {
            _context = context;
        }
        public int GetUserID (Models.AppUser user)
        {
           
            List<Entities.User> users = new List<Entities.User>();
            
             foreach (Entities.User r in _context.Users)
             {
                 users.Add(r);
             }
              int useId = (from Use in users
                                        where Use.Phone == user.Phone
                                        select Use.Id).FirstOrDefault();
            return useId;
        }
       
        public Models.Order AddOrder(Models.Order order, Models.AppUser user, Models.Location location)
        {
            _context.Orders.Add(
                new Entities.Order{
                    Total = order.Total,
                    LocationId = GetLocationID(location),
                    UserId = GetUserID(user),
                }              
            );
            _context.SaveChanges();
            //get the order that was just created
            List<Entities.Order> orders = new List<Entities.Order>();
            foreach(Entities.Order o in _context.Orders){
                orders.Add(o);
            }
            IEnumerable<Entities.Order> SortedOrders = from o in orders
                                          group o by o.Id into sorto
                                          select sorto.OrderByDescending(os => os.Id).First();
            int recentOrderId = SortedOrders.Max(x => x.Id);
            Entities.Order recentOrder = GetOrderById(recentOrderId);
            
            foreach (Models.Products prod in order.ProductList){
            int prodId = GetProductID(prod);
            AddLineItem(prod, recentOrderId);

            }
            _context.SaveChanges();
            return order;
        }

        public Models.AppUser AddUser(Models.AppUser user)
        {
            _context.Users.Add(
                new Entities.User{
                     UserName = user.UserName,
                     Phone = user.Phone,
                     UserAddress = user.Address,
                     UserType = user.userType
                }
            );
            _context.SaveChanges();
            return user;
        }
        public Models.Products AddLineItem (Models.Products product, int orderId)
        {
            
            List<Entities.Product> prods = new List<Entities.Product>();
            foreach(Entities.Product prod in _context.Products){
                    prods.Add(prod);
            }
            int prodId = (from Prod in prods
                                        where Prod.Description == product.ItemName
                                        select Prod.Id).FirstOrDefault();
            _context.LineItems.Add(
                new Entities.LineItem{
                    OrderId = orderId,
                    ProductId = prodId,
                    Quantity = 1
                }
            );
            _context.SaveChanges();
            return product;
        }
        public void ReduceInventory(int locId, int prodId)
        {
            List<Entities.Inventory> inv = new List<Entities.Inventory>();
             foreach (Entities.Inventory r in _context.Inventories)
             {
                 inv.Add(r);
             }
            var updatequery = from rec in _context.Inventories
                            where rec.LocationId == locId && rec.ProductId == prodId
                            select rec;
                foreach(Entities.Inventory rec in updatequery)
                {
                        rec.Quantity -= 1;
                }
                _context.SaveChanges();




        }
        public Entities.Order GetOrderById (int order)
        {
            List<Entities.Order> orders = new List<Entities.Order>();
             foreach (Entities.Order r in _context.Orders)
             {
                 orders.Add(r);
             }
              Entities.Order record = (from rec in orders
                                        where rec.Id == order
                                        select rec).FirstOrDefault();
            return record;

        }

         public int GetProductID (Models.Products prod)
        {
            List<Entities.Product> products = new List<Entities.Product>();
             foreach (Entities.Product r in _context.Products)
             {
                 products.Add(r);
             }
              int id = (from rec in products
                        where rec.Description == prod.ItemName
                        select rec.Id).FirstOrDefault();
            return id;

        }
        public List<Entities.User> GetAllUsers(){
            List<Entities.User> users = new List<Entities.User>();
             foreach (Entities.User r in _context.Users)
             {
                 users.Add(r);
             }
             return users;
        }
        public void RestockInventory(Models.Location loc){
            int locationId = GetLocationID(loc);
            List<Entities.Inventory> inv = new List<Entities.Inventory>();
             foreach (Entities.Inventory r in _context.Inventories)
             {
                 inv.Add(r);
             }
            var updatequery = from rec in _context.Inventories
                            where rec.LocationId == locationId && rec.Quantity < 10
                            select rec;
                    foreach (Entities.Inventory item in updatequery)
                    {
                        item.Quantity += 10;
                    }
                _context.SaveChanges();
        }
        public Models.Products GetProductsFromInventory(Entities.Inventory inv){
            List<Entities.Product> products = new List<Entities.Product>();
             foreach (Entities.Product r in _context.Products)
             {
                 products.Add(r);
             } 
             Entities.Product prod = (from p in products
                                        where p.Id == inv.ProductId
                                        select p).First();
            return new Models.Products(prod.Price, prod.Description);

            

        }
        public List<Entities.Inventory> ShowInventory(Models.Location loc){
            
            int locId = GetLocationID(loc);
            List<Entities.Inventory> invent = new List<Entities.Inventory>();
                foreach (Entities.Inventory i in _context.Inventories)
                {
                    if(i.LocationId == locId)
                        invent.Add(i);              
                }
                return invent;
             
        }
         public int GetLocationID (Models.Location location)
        {
           
            List<Entities.Location> locs = new List<Entities.Location>();

             foreach (Entities.Location r in _context.Locations)
             {
                 locs.Add(r);
             }
              int locId = (from Loca in locs
                                        where Loca.LocAddress == location.Address
                                        select Loca.Id).FirstOrDefault();
            return locId;
        }
        public Entities.Product GetProduct(int pid)
        {
            List<Entities.Product> prods = new List<Entities.Product>();
            foreach (Entities.Product p in _context.Products)
            {
                prods.Add(p);
            }
            Entities.Product produ = (from p in prods
                                        where p.Id == pid
                                        select p).FirstOrDefault();
            return produ;
        }
        public List<Models.Products> GetAllProducts(){
            
            List<Models.Products> prods = new List<Models.Products>();
             foreach (Entities.Product r in _context.Products)
             {
                 Models.Products p = new Models.Products(r.Price, r.Description);
                 prods.Add(p);
             }
             return prods;
        }
        
    }
}