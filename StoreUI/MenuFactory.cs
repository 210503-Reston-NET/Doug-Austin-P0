using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BL;
using DL;
using DL.Entities;
namespace StoreUI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType)
        {
            //getting configurations from a config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

           
            string connectionString = configuration.GetConnectionString("PetStoreDB");
           
            DbContextOptions<DougsExoticPetStoreContext> options = new DbContextOptionsBuilder<DougsExoticPetStoreContext>()
            .UseSqlServer(connectionString)
            .Options;
            
            var context = new DougsExoticPetStoreContext(options);

            switch (menuType.ToLower())
            {
                case "m":
                    return new MainMenu();
                case "customer":
                    return new OrderMenu(new OrderBL(new RepoDB(context)), new CustomerBL(new RepoDB(context)), new InventoryBL(new RepoDB(context)));
                case "admin":
                    return new AdminMenu(new InventoryBL(new RepoDB(context)));
                default:
                    return null;
            }
        } 
    }
}