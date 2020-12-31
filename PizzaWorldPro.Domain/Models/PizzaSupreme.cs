using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaWorldPro.Domain.Models{
    public class PizzaSupreme :APizzaModel
    {
      
        protected override void AddCrust()
        {
            Crust = "regular";
        }
        protected override void AddSize()
        {
            Size = "small";
        }
        protected override void AddToppings()
        {
            PizzaToppings = new List<Toppings> {
             new Toppings("Tomatoes",0.25),
             new Toppings("Red Onions",0.25),
             new Toppings("Basil",0.3),
             new Toppings("Peperoni",0.15)
            };
        }
    }
}