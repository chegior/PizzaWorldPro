using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Models
{
    public class User : AEntity
    {
        public int NameUser { get; set; }
        public bool IsAnEmployee { get; set; }
        public List<Order> Orders { get; set; }
        public Store SelectedStore { get; set; }
        

        public User()
        {
            Orders = new List<Order>();
            
        }

        public List<Order> ViewUserOrders()
        {
            return Orders;
        }
        
    }
}