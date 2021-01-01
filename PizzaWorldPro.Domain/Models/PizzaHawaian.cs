using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;


namespace PizzaWorldPro.Domain.Models{
    public class PizzaHawaiian :APizzaModel
    {
        protected override void AddToppings()
        {
             PizzaToppings = new List<string>{"Pineapple", "Ham", "Mozarella", "Green Olives"};
        }
                protected override void AddName()
        {
            PizzaName = "Hawaiian Pizza";
        }

    }
}