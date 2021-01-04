using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorldPro.Domain.Abstracts;
using PizzaWorldPro.Domain.Models;
using PizzaWorldPro.Domain.Singleton;

namespace PizzaWorldPro.Client
{
    class Program
    {
        private readonly static ClientSingleton _client = ClientSingleton.Instance;
         private static readonly SqlClient _sql = new SqlClient();
        
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
            Console.Clear();
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
            while(opt != "3"){
                ShowUserMenu();
                opt = Console.ReadLine();
                Console.Clear();
            
            switch(opt)
            {
                case "1": 
                {
                    PrintAllStores();
                    user.SelectedStore = _sql.SelectStore();
                    Console.Clear();
                    Console.Clear();
                    Console.Write("These are you Orders at the Store: ");
                    Console.WriteLine(user.SelectedStore.Name.ToUpper());
                    Console.WriteLine("As of now, You have "+user.SelectedStore.Orders.Count+" Order(s) of Pizzas");
                    System.Console.WriteLine("Each Containing Pizzas as follow: \n");
                    user.SelectedStore.Orders.ForEach((o)=>{
                        System.Console.WriteLine("+++++++++++++RECEIPT FOR ORDER +++++++++++++");
                        double totalOrder = 0;
                        for ( var i=0; i < o.Pizzas.Count; i++ )
                            {
                                
                                System.Console.Write(o.Pizzas[i].PizzaName+" Order at : "+ o.OrderTime);
                                System.Console.WriteLine("having "+o.Pizzas[i].PizzaToppings.Count+" Toppings as follow: ");
                                totalOrder+=o.Pizzas[i].PizzaPrice += GetToppingsInfo(o.Pizzas[i]);
                                System.Console.WriteLine("Your Total Pizza Price is :"+o.Pizzas[i].PizzaPrice.ToString("c")+"\n");
                               
                            }
                            System.Console.WriteLine("TOTAL: "+ totalOrder.ToString("c"));
                            System.Console.WriteLine("\n");
                        });
                    
                    Console.ReadKey();
                    Console.WriteLine("Hit any key to go back to the Menu");
                    UserCustomerView();
                    break;
                }
                case "2": 
                {
                    Console.WriteLine("Lets Order you Pizza....\n Note: Type the Name of the Pizzeria");
                    
                    PrintAllStores();
                    user.SelectedStore = _sql.SelectStore();
                    System.Console.WriteLine("You have selected THE STORE "+user.SelectedStore.Name.ToUpper());
                    user.SelectedStore.CreateOrder();
                    System.Console.WriteLine(user.SelectedStore.Orders.Count);
                    Console.ReadKey();
                    user.Orders.Add(user.SelectedStore.Orders.LastOrDefault());
                    System.Console.WriteLine("+++SELECT A PIZZA+++");

                     
                    var optPizza ="";
                    do{
                        SelctAPizza(user.SelectedStore.Name);
                        optPizza = System.Console.ReadLine();
                        switch (optPizza)
                        {
                            case "1": user.Orders.Last().MakeAPizzaaHawaiian();AssemblePizzaHawaiian(user.Orders.Last().Pizzas.Last());break;
                            case "2": user.Orders.Last().MakeAPizzaMeat(); AssemblePizzaMeat(user.Orders.Last().Pizzas.Last());break;
                            case "3":user.Orders.Last().MakeAPizzaSupreme();AssembleSupreme(user.Orders.Last().Pizzas.Last());break;
                            case "4":user.Orders.Last().MakeAPizzaVeggie();AssemblePizzaVeggie(user.Orders.Last().Pizzas.Last());break;
                            default: Console.WriteLine("Thank you!...hit a Key to continue "); Console.ReadKey();break;
                        }
                    }while(optPizza!="0");

                   
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

        }

        private static double GetToppingsInfo(APizzaModel Pizza)
        {
            double ToppingsPrice = 0;
            Pizza.PizzaToppings.ForEach(t => {
                System.Console.WriteLine("\t"+t.ItemName+" this item its price is "+t.ItemPrice.ToString("c"));
                ToppingsPrice += t.ItemPrice;
                }
            );
            return ToppingsPrice;
           
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
            byte opt = 1;
            foreach (var store in _sql.ReadStores())
            {
                System.Console.WriteLine(opt+".- "+store.Name);
                opt++;
            }
        }

        public static void SelctAPizza(string Name )
        {
            Console.Clear();
            System.Console.WriteLine("++++++Order YOUR Pizza+++++\n",Name);
            System.Console.WriteLine("As of now at {0} this is our Selection...Bon Appetii...",Name);
            System.Console.WriteLine("1 Hawaiian Pizza");
            System.Console.WriteLine("2 Meat Pizza");
            System.Console.WriteLine("3 Pizza Supreme");
            System.Console.WriteLine("4 Veggie Pizza");
            System.Console.WriteLine("0 I dont want a Pizza or more Pizzas\n");
            System.Console.WriteLine("---------------------------------------");
            System.Console.Write("Type the Number of your Selection: ");
        }

       

        private static APizzaModel AssemblePizzaVeggie(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Basil"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Baby Spinach"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Black Olives"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Cheese-feta"));
            return Pizza;
        }

        private static APizzaModel AssembleSupreme(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Bacon"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Green Peppers"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Mozarella"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Onions"));
            return Pizza;

        }

        private static APizzaModel AssemblePizzaMeat(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Tomatoes"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Pepperoni"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Mushrooms"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Onions"));
            return Pizza;
        }

        private static APizzaModel AssemblePizzaHawaiian(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Pineapple"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Ham"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Mozarella"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Green Olives"));
            return Pizza;
        }
    }
}
