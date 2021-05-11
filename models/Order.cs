using System.Collections.Generic;
namespace models
{
    public class Order
    {
        public List<Products> ProductList {get; set;}
        public float Total {
            get{
                return Total;
            }

            set{
                float t = 0;

                foreach (var p in ProductList)
                {
                    t += p.Price;
                }
            }

        }
        public User Customer{get; set;}
        
    }
}