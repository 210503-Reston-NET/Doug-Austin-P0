using System;
using models;
using BL;
using System.Collections.Generic;
using System.Linq;
namespace StoreUI
{
    public class OrderMenu : IMenu
    {
        private OrderBL _orderBL;
        private CustomerBL _custBL;
        private InventoryBL _invBL;
        public OrderMenu(OrderBL orderBl, CustomerBL custBL, InventoryBL invBL){
            _orderBL = orderBl;
            _custBL = custBL;
            _invBL = invBL;
        }

        public void Start()
        {
            bool firstrepeat = true;
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
            }
                AppUser user1 = new AppUser(custName, custAddress, custPhone);
            Console.WriteLine("Welcome!  which location would you like to order from?");
                Console.WriteLine("[0] Downtown");
                Console.WriteLine("[1] Suburbs");
                Console.WriteLine("[2] Exit to main menu");
                List<Products> selectedProducts = new List<Products>();
                while(firstrepeat == true){
                    string input = Console.ReadLine();
                       if(input == "0"){
                        bool repeat = true;
                        firstrepeat = false;
                        Location downtown = new Location();
                        downtown.Address = "77 Market Street, St. Louis, MO, 63118";
                        
                        Console.WriteLine("Welcome to our Downtown location.  Please select from the following inventory by typing in the name of the product. Type exit when you wish to check out.");
                                do
                                {
                                    
                                   Console.WriteLine(_invBL.ShowInventory(downtown));
                                   List<Products> fullprods = _orderBL.PrepProducts();
                                   Products ChosenProduct;
                                   Console.WriteLine("Welcome to our Downtown location.  Please select from the following inventory by typing in the name of the product. Type exit when you wish to check out.");
                                   string Search = Console.ReadLine();
                                   bool listCheck = true;
                                   if(Search == "Exit"){
                                       Order userOrder = _orderBL.CreateOrder(selectedProducts, user1, downtown);
                                       repeat = false;
                                       firstrepeat = false;
                                       Console.WriteLine("Here is the reciept for your order. Thank you for shopping with us!");
                                       Console.WriteLine(userOrder.ToString());
                                       Console.ReadLine();
                                       break;
                                   }else{
                                       foreach (Products p in fullprods)
                                        {
                                            listCheck = fullprods.Any(p => p.ItemName == Search);
                                        }if(listCheck){
                                            ChosenProduct = fullprods.FirstOrDefault(p => p.ItemName == Search);
                                           selectedProducts.Add(ChosenProduct);
                                           _invBL.TakeFrom(downtown, ChosenProduct);
                                        }else{
                                            Console.WriteLine("Please select an item that is listed");
                                        }                                      
                                            foreach (Products p in selectedProducts){
                                            Console.WriteLine($"Current Order {p.ItemName}");
                                       }
                                   } 
                                }while (repeat);
                            }else if(input == "1"){
                        bool repeat = true;
                        firstrepeat = false;
                        Location suburbs = new Location();
                        suburbs.Address = "1 Lockwood Ave, Webster Groves, MO 63119";
                        
                        Console.WriteLine("Welcome to our Downtown location.  Please select from the following inventory by typing in the name of the product. Type exit when you wish to check out.");
                                do
                                {
                                    
                                   Console.WriteLine(_invBL.ShowInventory(suburbs));
                                   List<Products> fullprods = _orderBL.PrepProducts();
                                   Products ChosenProduct;
                                   Console.WriteLine("Welcome to our Downtown location.  Please select from the following inventory by typing in the name of the product. Type exit when you wish to check out.");
                                   string Search = Console.ReadLine();
                                   bool listCheck = true;
                                   if(Search == "Exit"){
                                       Order userOrder = _orderBL.CreateOrder(selectedProducts, user1, suburbs);
                                       repeat = false;
                                       firstrepeat = false;
                                       Console.WriteLine("Here is the reciept for your order. Thank you for shopping with us!");
                                       Console.WriteLine(userOrder.ToString());
                                       Console.ReadLine();
                                       break;
                                   }else{
                                       foreach (Products p in fullprods)
                                        {
                                            listCheck = fullprods.Any(p => p.ItemName == Search);
                                        }if(listCheck){
                                            ChosenProduct = fullprods.FirstOrDefault(p => p.ItemName == Search);
                                           selectedProducts.Add(ChosenProduct);
                                           _invBL.TakeFrom(suburbs, ChosenProduct);
                                        }else{
                                            Console.WriteLine("Please select an item that is listed");
                                        }                                      
                                            foreach (Products p in selectedProducts){
                                            Console.WriteLine($"Current Order {p.ItemName}");
                                       }
                                   } 
                                }while (repeat);
                            }
                            else{
                                Console.WriteLine("Please select a valid option");
                            }
                }
                
                    
                            /*case "1":
                            bool repeat2 = true;
                         Location suburbs = new Location();
                        suburbs.Address = "1 Lockwood Ave, Webster Groves, MO 63119";
                         Console.WriteLine("Welcome to our suburbia location.  Please select from the following inventory by typing in the name of the product. Type exit when you wish to check out.");
                                do
                                {
                                    
                                   Console.WriteLine(_invBL.ShowInventory(suburbs));
                                   List<Products> fullprods = _orderBL.PrepProducts();
                                   Console.WriteLine("Welcome to our Suburbia location.  Please select from the following inventory by typing in the name of the product. Type exit when you wish to check out.");
                                   string Search = Console.ReadLine();
                                   if(Search == "Exit" || Search == "exit"){
                                       Order userOrder = _orderBL.CreateOrder(selectedProducts, user1, suburbs);
                                       repeat2 = false;
                                   }
                                       Products ChosenProduct =  fullprods.First(p => p.ItemName == Search);
                                    if(ChosenProduct != null) {selectedProducts.Add(ChosenProduct);
                                    foreach (Products p in selectedProducts){
                                        Console.WriteLine(p.ItemName);
                                    }
                                    {
                                        
                                    }
                                   }else{
                                       Console.WriteLine("Please select an item that is listed");
                                   }
                                    
                                   
                                   
                                   _invBL.TakeFrom(suburbs, ChosenProduct);

                                } while (repeat2);
                        break;
                    case "2":
                        Console.WriteLine("Have a nice day!");
                        break;*/
                    Console.WriteLine();
                }
        }
    }
