using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;
using PizzaWorldPro.Domain.Abstracts;
using PizzaWorldPro.Domain.Factories;


namespace PizzaWorldPro.Domain.Models
{
    public class Order : AEntity
    {
        public DateTime OrderTime {get; set;}
        public double OrderPrice { get; set; }
        
        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();
        public List<APizzaModel> Pizzas { get; set; }
        public Order()
        {
            Pizzas = new List<APizzaModel>(){};
            OrderTime = DateTime.Now;
        }
        public void MakeAPizzaMeat()
        {
            Pizzas.Add(_pizzaFactory.Make<PizzaMeat>());
        }
        public void MakeAPizzaVeggie()
        {
            Pizzas.Add(_pizzaFactory.Make<PizzaVeggie>());
        }
        public void MakeAPizzaaHawaiian()
        {
            Pizzas.Add(_pizzaFactory.Make<PizzaHawaiian>());
        }
        public void MakeAPizzaSupreme()
        {
            Pizzas.Add(_pizzaFactory.Make<PizzaSupreme>());
        }

    }
}