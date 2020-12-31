using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;



namespace PizzaWorldPro.Domain.Models{
    public class PizzaMeat :APizzaModel
    {
      
        // protected override void AddCrust()
        // {
            
        // }
        // protected override void AddSize()
        // {
            
        // }
        protected override void AddToppings()
        {
            PizzaToppings = new List<Toppings> {
             new Toppings("Tomatoes",0.25),
             new Toppings("Beef",0.25),
             new Toppings("Ham",0.3),
             new Toppings("Peperoni",0.15)
            };
        }
    }
}