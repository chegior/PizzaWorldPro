using System.Collections.Generic;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Domain.Abstracts

{
    public class APizzaModel
    {
        public string Crust {get;set;}
        public string Size {get;set;}
        public double PizzaPriceBase { get; set; }
        public double PizzaTotalPrice { get; set; }
        public List<Toppings> PizzaToppings{get;set;}
        public Crust PizzaCrust;
        public Size PizzaSize;
        protected APizzaModel()
        {
            PizzaCrust = new Crust();
            PizzaSize = new Size();
            PizzaPriceBase = 5.55;
            AddCrust();
            AddSize();
            AddToppings();
            
        }

        protected virtual void AddCrust()
        {
            Crust = PizzaCrust.ChooseACrust();
        }
        protected virtual void AddSize()
        {
            Size = PizzaSize.ChooseASize();
        }
        protected virtual void AddToppings()
        {
            PizzaToppings = new List<Toppings> {};
        }
        protected virtual void CalculatePizzaTotalPrice()
        {

        }
    }
}