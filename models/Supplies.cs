namespace models
{
    public class Supplies : Products
    {
        public Supplies(string _name, string _category, float _price)
        {
            ItemName = _name;
            Category = _category;
            Price = _price;
        }
        public string Category { get; set;}
        public string ItemName{ get; set;}

public override string ToString(){
            return ItemName;
        }
    }
}