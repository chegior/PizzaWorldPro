using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;



namespace PizzaWorldPro.Domain.Models{
    public class PizzaMeat :APizzaModel
    {   
        
        protected override void AddToppings()
        {
            
            PizzaToppings = new List<Toppings>{};
        }
        protected override void AddName()
        {
            PizzaName="MeatPizza";
        }
        protected override void AddPizzaPrice()
        {
             PizzaPrice = 15.00;
        }

    }
}