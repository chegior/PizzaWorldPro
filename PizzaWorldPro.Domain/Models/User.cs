using System.Collections.Generic;
namespace PizzaWorldPro.Domain.Models
{
    public class User
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