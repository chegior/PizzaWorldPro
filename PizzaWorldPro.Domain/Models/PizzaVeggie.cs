using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;


namespace PizzaWorldPro.Domain.Models{
    public class PizzaVeggie :APizzaModel
    {
      
        protected override void AddToppings()
        {
            PizzaToppings = new List<string>{"Basil","Baby Spinach", "Black Olives", "Mushrooms", "Cheese-feta"};
        }

        protected override void AddName()
        {
            PizzaName = "Veggie Pizza";
        }

        
    }
}