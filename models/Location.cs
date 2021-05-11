using System.Collections.Generic;
namespace models
{
    public class Location
    {
        public List<Supplies> SuppliesInventory {get; set;}
        public List<Pet> PetInventory {get; set;}

        public string Address{get; set;}
        public string Phone{get; set;}
    }
}