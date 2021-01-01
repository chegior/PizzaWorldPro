using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaWorldPro.Domain.Models{
    public class PizzaSupreme :APizzaModel

    {
        protected override void AddToppings()
        {
            PizzaToppings = new List<string>{"Bacon", "Onions", "Green Peppers", "Mozarella"};          
        }
        protected override void AddName()
        {
            PizzaName = "Supreme Pizza";
        }

        
    }
}