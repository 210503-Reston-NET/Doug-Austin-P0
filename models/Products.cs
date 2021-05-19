namespace models
{
    /// <summary>
    /// An abstract class that establishes the hierarchy for products.
    /// Is used to allow a single order to have both pet and supplies objects
    /// </summary>
    public class Products
    {
        public Products(decimal p, string n){
            Price = p;
            ItemName = n;
        }
        public decimal Price{get; set;}
        public string ItemName{ get; set;}

        public override string ToString()
        {
            return $"{ItemName}              ${Price}";
        }
    }
}