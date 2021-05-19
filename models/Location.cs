using System.Collections.Generic;
namespace models
{
    public class Location
    {
        public List<Products> SuppliesInventory {get; set;}  
        public string Address{get; set;}
        public string Phone{get; set;}
    }
}