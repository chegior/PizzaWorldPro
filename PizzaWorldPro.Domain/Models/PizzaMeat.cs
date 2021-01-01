using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;



namespace PizzaWorldPro.Domain.Models{
    public class PizzaMeat :APizzaModel
    {   
        
        protected override void AddToppings()
        {
            
            PizzaToppings = new List<string>{"Tomatoes", "Pepperoni", "Mushrooms", "Onions"};
        }
        protected override void AddName()
        {
            PizzaName="MeatPizza";
        }
    }
}