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
        public double PizzaPrice { 
            get {
                return PizzaPrice + 5.00;
            }
        }
        public List<string> PizzaToppings{get;set;}
        protected APizzaModel()
        {

            AddToppings();
            
        }


        protected virtual void AddToppings()
        {
           
        }


    }
}