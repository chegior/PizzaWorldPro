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
           // var user = new User();
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
                                System.Console.WriteLine(" having "+o.Pizzas[i].PizzaToppings.Count+" Toppings as follow: ");
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
                    Console.WriteLine("Lets Order you Pizza....\n Note: Loading our fine Pizzerias Negozios!");
                    
                    PrintAllStores();
                    Console.Write("Please choose from above: ");
                    user.SelectedStore = _sql.SelectStore();
                    user.SelectedStore.CreateOrder();
                    user.Orders.Add(user.SelectedStore.Orders.LastOrDefault());
                    Console.WriteLine("You have selected THE STORE "+user.SelectedStore.Name.ToUpper());
                    Console.WriteLine("+++SELECT A PIZZA+++");

                     
                    var optPizza ="";
                    do{
                        SelectAPizza(user.SelectedStore.Name);
                        optPizza = System.Console.ReadLine();
                        switch (optPizza)
                        {
                            case "1":
                            { 
                                user.Orders.Last().MakeAPizzaaHawaiian();
                                AssemblePizzaHawaiian(user.Orders.Last().Pizzas.Last()); 
                                ChooseACrust(user.Orders.Last().Pizzas.Last());
                                ChooseASize(user.Orders.Last().Pizzas.Last()); 
                                user.Orders.Last().OrderPrice = user.Orders.Last().Pizzas.Last().PizzaPrice;
                                _sql.Update();
                                break;
                            }
                            case "2": 
                            {
                                user.Orders.Last().MakeAPizzaMeat(); 
                                AssemblePizzaMeat(user.Orders.Last().Pizzas.Last());
                                ChooseACrust(user.Orders.Last().Pizzas.Last());
                                ChooseASize(user.Orders.Last().Pizzas.Last()); 
                                user.Orders.Last().OrderPrice = user.Orders.Last().Pizzas.Last().PizzaPrice;
                                _sql.Update();
                                break;
                            }
                            case "3":
                            {
                                user.Orders.Last().MakeAPizzaSupreme();
                                AssembleSupreme(user.Orders.Last().Pizzas.Last());
                                ChooseACrust(user.Orders.Last().Pizzas.Last());
                                ChooseASize(user.Orders.Last().Pizzas.Last()); 
                                user.Orders.Last().OrderPrice = user.Orders.Last().Pizzas.Last().PizzaPrice;
                                _sql.Update();
                                break;
                            }
                            case "4":
                            {
                                user.Orders.Last().MakeAPizzaVeggie();
                                AssemblePizzaVeggie(user.Orders.Last().Pizzas.Last());
                                ChooseACrust(user.Orders.Last().Pizzas.Last());
                                ChooseASize(user.Orders.Last().Pizzas.Last()); 
                                user.Orders.Last().OrderPrice = user.Orders.Last().Pizzas.Last().PizzaPrice;
                                _sql.Update();
                                break;
                            }
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
            var store = new Store();
            
            var opt = new String("");
            ShowStoreMenu();
            opt = Console.ReadLine();
            Console.Clear();
            
            switch(opt)
            {
                case "1": 
                {
                    Console.Clear();Console.WriteLine("These are the Store Orders");
                    PrintAllStores();
                    store = _sql.SelectStore();
                    GetOrdersFromStore(store);
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

        private static void GetOrdersFromStore(Store s)
        {
            double TotalSales = 0;
           s.Orders = _sql.getOrdersByStore(s.Name);
           System.Console.WriteLine("The store {0} have a total of {1}",s.Name,s.Orders.Count);
           s.Orders.ForEach( (o) => 
           {
               TotalSales += o.OrderPrice; 
               System.Console.WriteLine("Order Price: {0}",o.OrderPrice.ToString("c"));
            });
            Console.WriteLine("The Store {0} TOTAL: {1}",s.Name,TotalSales.ToString("c"));
            Console.Write("Press a Key to Continue.....");
            Console.ReadKey();
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

        public static void SelectAPizza(string Name )
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

       

        private static void AssemblePizzaVeggie(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Basil"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Baby Spinach"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Black Olives"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Cheese-feta"));
            
        }

        private static void AssembleSupreme(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Bacon"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Green Peppers"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Mozarella"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Onions"));
            

        }

        private static void AssemblePizzaMeat(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Tomatoes"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Pepperoni"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Mushrooms"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Onions"));
            
        }
        private static void AssemblePizzaHawaiian(APizzaModel Pizza)
        {
            Pizza.PizzaToppings.Add(_sql.getToppings("Pineapple"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Ham"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Mozarella"));
            Pizza.PizzaToppings.Add(_sql.getToppings("Green Olives"));
            
        }
        private static void ChooseASize(APizzaModel p)
        {
            string SizeSel="";
            double PriceSel=0;

            
            System.Console.WriteLine("Choose a Size");
            System.Console.WriteLine("1 Picola - Small size");
            System.Console.WriteLine("2 Medio - Medium size");
            System.Console.WriteLine("3 Familiare - Large size");
            var opt0 = new String("");
            opt0 = Console.ReadLine();
            switch(opt0)
            {
                case "1": SizeSel = "Picola";PriceSel=0.00;break; 
                case "2": SizeSel = "Medio";PriceSel=2.99;break; 
                case "3": SizeSel = "Familiare";PriceSel=5.00;break; 
               
            };

            p.Size = SizeSel;
            p.PizzaPrice += PriceSel;
        }
         private static void ChooseACrust(APizzaModel p)
        {
            string CrustSel="";
            double PriceSel=0;

            System.Console.WriteLine("Choose a Crust");
            System.Console.WriteLine("1 Regular");
            System.Console.WriteLine("2 Thin-Flat");
            System.Console.WriteLine("3 Stuffed");
            var opt1 = new String("");
            opt1 = Console.ReadLine();
            switch (opt1)
            {
                case "1": CrustSel = "Regular";PriceSel=0.00;break; 
                case "2": CrustSel = "Thin-Flat";PriceSel=2.50;break; 
                case "3": CrustSel = "Stuffed";PriceSel=5.00;break; 
                
            };
           
            p.Crust = CrustSel;
            p.PizzaPrice += PriceSel;
        }

        private static void CalculatePrice(List<Order> p)
        {
            p.ForEach((o)=>{
                for ( var i=0; i < o.Pizzas.Count; i++ )
                {
                  o.Pizzas[i].PizzaPrice += GetToppingsInfo(o.Pizzas[i]);
                }
                Console.ReadKey();
            });
            
        }

    }
}
