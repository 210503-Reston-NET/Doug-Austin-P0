using System.Collections.Generic;
namespace models
{
    public class Order
    {
        public Order(List<Products> products, AppUser c, Location l){
            ProductList = products;
            decimal t = 0;
            for (int i = 0; i < products.Count; i++)
                {
                Products p = products[i];
                t += p.Price;
                }
            Total = t;
            Customer = c;
            Location = l;
        }
        /// <summary>
        /// a list that holds all the products in
        /// </summary>
        /// <value></value>
        public List<Products> ProductList {get; set;}
        
        /// <summary>
        /// gets the total for all the items on the order by looping through the ProductList
        /// </summary>
        /// <value></value>
        /// <summary>
        public decimal Total {get; set;}
        /// The customer for the order
        /// </summary>
        /// <value></value>
        public AppUser Customer{get; set;}
        
        public Location Location{get; set;}
/// <summary>
/// Override the ToString Method to return a receipt for the order
/// </summary>
/// <returns></returns>
        public override string ToString()
        {
            string receipt = $"Order for {Customer}";
            string lineItem = "";
            string totalstring;
            foreach (var p in ProductList)
            {
                lineItem = $"     \n{p.ToString()}     ${p.Price}";
               lineItem += lineItem;
               
            }
             totalstring = $"                     \nTotal: ${this.Total}";
             receipt = receipt + lineItem + totalstring;
            return receipt;
        }
    }
}