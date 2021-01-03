using System;
using System.Collections.Generic;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Domain.Abstracts

{
    public class APizzaModel
    {
        public string PizzaName{get;set;}
        public string Crust {get;set;}
        public string Size {get;set;}
        public double PizzaPrice { get; set; }
        public List<string> PizzaToppings{get; set;}
        protected APizzaModel()
        {

            AddToppings();
            AddName();
            
        }

        protected virtual void AddName()
        {
            
        }

        protected virtual void AddToppings()
        {
           
        }


    }
}