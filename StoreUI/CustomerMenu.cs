using System;
using models;
using BL;
using System.Collections.Generic;
namespace StoreUI
{
    public class CustomerMenu : IMenu
    { 
        private CustomerBL _custBL;
        public CustomerMenu( CustomerBL custBL){
        
            _custBL = custBL;
        
        }

        public void Start()
        {
            string custName;
            string custPhone;
            string custAddress;
                        Console.WriteLine("Please enter your info");
                        Console.WriteLine("Name:");
                        custName = Console.ReadLine();
                        Console.WriteLine("Phone Number:");
                        custPhone = Console.ReadLine();
                        Console.WriteLine("Address:");
                        custAddress = Console.ReadLine();
            if(!(_custBL.CheckForUser(custName, custPhone, custAddress))){
                _custBL.CreateUser(custName, custPhone, custAddress);
            }else{
                AppUser user1 = new AppUser(custName, custAddress, custPhone);
            }
            
        }
    }
}