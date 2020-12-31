using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;


namespace PizzaWorldPro.Domain.Models{
    public class PizzaVeggie :APizzaModel
    {
      
        protected override void AddCrust()
        {
            Crust PizzaCrust = new Crust();
        }
        protected override void AddSize()
        {
            Size PizzaSize = new Size();
        }
        protected override void AddToppings()
        {
            PizzaToppings = new List<Toppings> {
             new Toppings("Tomatoes",0.25),
             new Toppings("Artichoke",0.25),
             new Toppings("Olives",0.3),
             new Toppings("Basil",0.15)
            };
        }
    }
}