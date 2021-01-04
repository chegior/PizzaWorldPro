using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;


namespace PizzaWorldPro.Domain.Models{
    public class PizzaVeggie :APizzaModel
    {
      
        protected override void AddToppings()
        {
            PizzaToppings = new List<Toppings>{};
        }

        protected override void AddName()
        {
            PizzaName = "Veggie Pizza";
        }
        protected override void AddPizzaPrice()
        {
             PizzaPrice = 25.00;
        }

        
    }
}