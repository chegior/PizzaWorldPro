using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Domain.Abstracts

{
    public class APizzaModel : AEntity
    {
        public string PizzaName{get;set;}
        public string Crust {get;set;}
        public string Size {get;set;}
        public double PizzaPrice { get; set; }
        public List<Toppings> PizzaToppings{get; set;}
        protected APizzaModel()
        {

            AddToppings();
            AddName();
            AddPizzaPrice();
            
        }

        protected virtual void AddPizzaPrice()
        {
            
        }

        protected virtual void AddName()
        {
            
        }

        protected virtual void AddToppings()
        {
           
        }


    }
}