using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Models
{
    public class Store : AEntity
    {
        public string Name {get;set;}
        public List<Order> Orders { get; set; }

        public void CreateOrder()
        {
            Orders.Add(new Order());
        }

        bool DeleteOrder(Order order)
        {
            Orders.Remove(order);
            return true;
        }   
        public Store(){
            Orders = new List<Order>();
        }
        
    }
}