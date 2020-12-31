using PizzaWorldPro.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Models
{
     public class Toppings:AItemModel
    {
        
        Toppings()
        {}
        public Toppings(string Name, double Price)
        {
            ItemName = Name;
            ItemPrice = Price;
        }
    }
}