using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;


namespace PizzaWorldPro.Domain.Models{
    public class PizzaHawaian :APizzaModel
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
             new Toppings("Mozarella",0.25),
             new Toppings("Ham",0.3),
             new Toppings("Pineaple",0.15)
            };
        }
    }
}