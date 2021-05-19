
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BL;
using DL;
using DL.Entities;
namespace StoreUI
{
    public class MainMenu : IMenu
    {
        private IMenu menu;
        public void Start()
        {

            Console.WriteLine("Are you an new customer or returning customer?");

            bool repeat = true;
            do{
                Console.WriteLine("[0] New Customer");
                Console.WriteLine("[1] Returning Customer");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                    {
 
                        menu = MenuFactory.GetMenu("customer");
                        repeat = false;
                        break;
                    }
                    case "1":
                    {
                        menu = MenuFactory.GetMenu("customer");
                        repeat = false;
                        break;

                    }
                    case "927":
                        menu = MenuFactory.GetMenu("admin");
                        repeat = false;
                        break;

                    default:
                    {
                        Console.WriteLine("Invalid Entry");
                        break;
                    }
                }
            }while(repeat);
                menu.Start();
        }
        
    }
}