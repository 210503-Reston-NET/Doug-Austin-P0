using models;
using System.Collections.Generic;
namespace BL
{
    public interface IOrder
    {
         Order CreateOrder(List <Products> items, AppUser cust, Location loc)
         {
            throw new System.NotImplementedException();
         }
         Order SearchOrder()
         {
            throw new System.NotImplementedException();
         }
    }
}