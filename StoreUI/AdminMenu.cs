using System;
using models;
using BL;
using System.Collections.Generic;
namespace StoreUI
{
    public class AdminMenu : IMenu
    {
        private InventoryBL _invBL;
        public AdminMenu(InventoryBL invBL){
            _invBL = invBL;
        }
        private IMenu menu;

        public void Start()
        {
                        bool repeat = true;
            Console.WriteLine("Welcome Admin!");
            do
            {
                Console.WriteLine("What location do you want to restock?");
                Console.WriteLine("[0] Downtown");
                Console.WriteLine("[1] Suburbs");
                Console.WriteLine("[2] Exit to main menu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Location downtown = new Location();
                        downtown.Address = "77 Market Street, St. Louis, MO, 63118";
                        _invBL.Replenish(downtown);
                        break;
                    case "1":
                         Location suburbs = new Location();
                        suburbs.Address = "1 Lockwood Ave, Webster Groves, MO 63119";
                        _invBL.Replenish(suburbs);
                        break;
                    case "2":
                        repeat = false;
                        Console.WriteLine("Have a nice day!");
                        menu = MenuFactory.GetMenu("main");
                        break;
                    default:
                        Console.WriteLine("Invalid Entry!");
                        break;
                }
            } while (repeat);
            

        }

    }
}