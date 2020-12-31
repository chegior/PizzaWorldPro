using System.Collections.Generic;
using System.Linq;
using PizzaWorldPro.Domain.Abstracts;
using PizzaWorldPro.Domain.Factories;


namespace PizzaWorldPro.Domain.Models
{
    public class Order
    {
        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();
        public double CurrentOrderPrice { get; set; }
        public byte CurrentOrderQuantity { get; set; }
        public List<APizzaModel> Pizzas { get; set; }
        public Order()
        {
            Pizzas = new List<APizzaModel>(){};
        }
        public void MakeAPizza()
        {

            System.Console.WriteLine("Making Pizzas....");
            Pizzas.Add(_pizzaFactory.Make<PizzaMeat>());
            Pizzas.Add(_pizzaFactory.Make<PizzaHawaian>());
            Pizzas.Add(_pizzaFactory.Make<PizzaSupreme>());
            Pizzas.Add(_pizzaFactory.Make<PizzaVeggie>());
            System.Console.WriteLine($"Your {Pizzas.Count} Pizzas are Ready ");
            CalculateOrderPrice();
            System.Console.ReadLine();
            
        }
        public void CalculateOrderPrice()
        {
            foreach(var p in Pizzas)
            {
                
                foreach(var t in p.PizzaToppings)
                {
                    CurrentOrderPrice += t.ItemPrice;
                }
                CurrentOrderPrice += p.PizzaPriceBase;
            }
           

        }

    }
}