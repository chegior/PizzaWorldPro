using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;


namespace PizzaWorldPro.Domain.Models{
    public class PizzaHawaiian :APizzaModel
    {
        protected override void AddToppings()
        {
            PizzaToppings = new List<Toppings>{};
        }
        protected override void AddName()
        {
            PizzaName = "Hawaiian Pizza";
        }
        protected override void AddPizzaPrice()
        {
            PizzaPrice = 10.00;
        }

    }
}