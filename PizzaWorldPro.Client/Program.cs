using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorldPro.Domain.Models;
using PizzaWorldPro.Domain.Singleton;

namespace PizzaWorldPro.Client
{
    class Program
    {
        private readonly static ClientSingleton _client = ClientSingleton.Instance;
        
        static void Main(string[] args)
        {
            var user = new User();
            MainMenuPizzaWorldPro();
        }
        public static void ShowUserMenu()
        {
            Console.Clear();
            Console.WriteLine("+++++++USER VIEW+++++++");
            Console.WriteLine("Please select a Number");
            Console.WriteLine("1.- View your history of Orders");
            Console.WriteLine("2.- Order a Pizza");
            Console.WriteLine("3.- Exit");
            Console.Write("Enter your Selection: ");
        }

        public static  void ShowStoreMenu()
        {
            Console.Clear();
            System.Console.WriteLine("*****STORE VIEW******");
            Console.WriteLine("Please select a Number");
            Console.WriteLine("1.- View Completed Orders");
            Console.WriteLine("2.- View Sales");
            Console.WriteLine("3.- Exit");
            Console.Write("Enter your Selection: ");

        }

        public static void MainMenuPizzaWorldPro()
        {
            var opt = new String("");
            Console.WriteLine("Welcome to Pizza World Pro \n\nMENU\n");
            Console.WriteLine("Are you a Customer? Y / N");
            opt = Console.ReadLine();
            if (opt.ToUpper().Equals("Y"))
            {
                UserCustomerView();
            }else if(opt.ToUpper().Equals("N"))
            {
                UserStoreView();
            } else
            {
                Console.Clear();
                Console.WriteLine("Please Enter a Valid Selection");

                MainMenuPizzaWorldPro();
            }   
        }

        public static void UserCustomerView()
        {
            var user = new User();
            var opt = new String("");
            ShowUserMenu();
            opt = Console.ReadLine();
            Console.Clear();
            switch(opt)
            {
                case "1": 
                {
                    Console.WriteLine("These are you Orders");
                    Console.WriteLine(user.ViewUserOrders().Count);
                    Console.ReadKey();
                    Console.WriteLine("Hit any key to go back to the Menu");
                    UserCustomerView();
                    break;
                }
                case "2": 
                {
                    Console.WriteLine("Lets Order you Pizza....\n");
                    
                    PrintAllStores();
                    user.SelectedStore = _client.SelectStore();
                    System.Console.WriteLine("You have selected THE STORE "+user.SelectedStore.Name.ToUpper());
                    user.SelectedStore.CreateOrder();
                    System.Console.WriteLine(user.SelectedStore.Orders.Count);
                    Console.ReadKey();
                    user.Orders.Add(user.SelectedStore.Orders.LastOrDefault());
                    System.Console.WriteLine("+++SELECT A PIZZA+++");
                    user.Orders.Last().MakeAPizzaSupreme();
                    user.Orders.Last().MakeAPizzaMeat();
                    user.Orders.Last().MakeAPizzaVeggie();
                    System.Console.WriteLine("Your Order have "+user.Orders.Last().Pizzas.Count+" Pizzas");
                    Console.ReadLine();
                    break;
                }
                case "3": 
                {
                    Console.Clear();
                    MainMenuPizzaWorldPro();
                    break;
                }
                default: Console.WriteLine("Please enter a valid selection");UserCustomerView();break;
                
            }

        }
        public static void UserStoreView()
        {
            
            
            var opt = new String("");
            ShowStoreMenu();
            opt = Console.ReadLine();
            Console.Clear();
            
            switch(opt)
            {
                case "1": 
                {
                    Console.Clear();Console.WriteLine("These are you Orders");
                    //
                    break;
                }
                case "2": 
                {
                    Console.Clear();Console.WriteLine("Proxy\n");
                    
                    break;
                }
                case "3": 
                {
                    Console.Clear();
                    MainMenuPizzaWorldPro();
                    break;
                }
                default: Console.WriteLine("Please enter a valid selection");UserStoreView();break;
                
            }


        }

        public static void PrintAllStores()
        {
            
           
            byte op = 0;
            foreach( var store in _client.Stores)
            {
                System.Console.WriteLine(op+"-"+store.Name);
                op++;
            }
        }

        
        
    }
}
