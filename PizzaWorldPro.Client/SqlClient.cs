using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorldPro.Domain.Models;
using PizzaWorldPro.Storing;

namespace PizzaWorldPro.Client
{
    public class SqlClient
    {
        private readonly PizzaWorldProContext _context = new PizzaWorldProContext();

        public IEnumerable<Store> ReadStores()
        {
            return _context.Stores;
        }

        public Store ReadOneStore(string name)
        {
            var s = _context.Stores.FirstOrDefault(s => s.Name == name);
            return s;
        }

        public IEnumerable<Order> ReadOrders(Store store)
        {
            var s = ReadOneStore(store.Name);
            return s.Orders;
        }
        
        public void Save(Store store)
        {
            _context.Add(store);
            _context.SaveChanges();
        }
        public void Update()
        {
            _context.SaveChanges();
        }
        public Store SelectStore()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":input="The Vaticano Pizzas";break;
                case "2":input="The Corner Pizzas";break;
                case "3":input="The Negozio Pizzas";break;
                default:System.Console.WriteLine("Please Select a Valid Store");break;
            };
            return ReadOneStore(input);
        }
        public void UserOrderHistory(User user)
        {
            var u = _context.Users
                .Include(u=> u.Orders)
                .ThenInclude(o=> o.Pizzas)
                .FirstOrDefault(u => u.EntityId == user.EntityId);

            // var o = u.Orders.Pizzas;
            // var p = _context.Pizzas.Select(s => s.EntityId == u.Pizzas);
        }

        public Toppings getToppings(string name)
        {
            var t = _context.Toppings.FirstOrDefault(t => t.ItemName == name);
            return t;
        }
    }
}