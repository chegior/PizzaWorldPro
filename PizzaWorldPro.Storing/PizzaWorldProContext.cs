using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorldPro.Domain.Abstracts;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Storing
{
    public class PizzaWorldProContext : DbContext 
    {
        public DbSet<Store> Stores { get; set;} 
        public DbSet<User> Users {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Toppings> Toppings {get; set;}
        public DbSet<Crust> Crusts {get; set;}
        public DbSet<Size> Sizes {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=chepizzaworld.database.windows.net; Initial Catalog=PizzaWorldProDB;User Id=sqladmin;Password=123QWEasd");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.EntityId);
            builder.Entity<User>().HasKey(u => u.EntityId);
            builder.Entity<Order>().HasKey(o => o.EntityId);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityId);

            builder.Entity<Toppings>().HasKey(t => t.EntityId);
            builder.Entity<Crust>().HasKey(c => c.EntityId);
            builder.Entity<Size>().HasKey(z => z.EntityId);
        

            builder.Entity<Store>().Property(s => s.EntityId).ValueGeneratedNever();
            builder.Entity<Toppings>().Property(t => t.EntityId).ValueGeneratedNever();
            builder.Entity<Crust>().Property(c => c.EntityId).ValueGeneratedNever();
            builder.Entity<Size>().Property(z => z.EntityId).ValueGeneratedNever();

            SeedData(builder);

        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>
            {
                new Store() { EntityId = 1, Name = "The Vaticano Pizzas" },
                new Store() { EntityId = 2, Name = "The Corner Pizzas" },
                new Store() { EntityId = 3, Name = "The Negozio Pizzas" }
            });
            builder.Entity<Toppings>().HasData(new List<Toppings>
            {
                new Toppings() { EntityId = 1, ItemName = "Pineapple", ItemPrice=1.50 },
                new Toppings() { EntityId = 2, ItemName = "Ham", ItemPrice=0.80 },
                new Toppings() { EntityId = 3, ItemName = "Mozarella", ItemPrice=0.99 },
                new Toppings() { EntityId = 4, ItemName = "Green Olives", ItemPrice=.75 },
                new Toppings() { EntityId = 5, ItemName = "Tomatoes", ItemPrice=1.00 },
                new Toppings() { EntityId = 6, ItemName = "Pepperoni", ItemPrice= 1.25},
                new Toppings() { EntityId = 7, ItemName = "Mushrooms", ItemPrice= 1.10},
                new Toppings() { EntityId = 8, ItemName = "Onions", ItemPrice=0.55 },
                new Toppings() { EntityId = 9, ItemName = "Bacon", ItemPrice=1.25 },
                new Toppings() { EntityId = 10, ItemName = "Green Peppers", ItemPrice=0.78 },
                new Toppings() { EntityId = 12, ItemName = "Red Peppers", ItemPrice= 0.65},
                new Toppings() { EntityId = 13, ItemName = "Basil", ItemPrice=3.00 },
                new Toppings() { EntityId = 14, ItemName = "Baby Spinach", ItemPrice=2.00 },
                new Toppings() { EntityId = 15, ItemName = "Black Olives", ItemPrice=1.00 },
                new Toppings() { EntityId = 16, ItemName = "Cheese-feta", ItemPrice=2.00 },
                

            });

            builder.Entity<Crust>().HasData(new List<Crust>
            {
                new Crust() { EntityId = 1, ItemName = "Regular", ItemPrice = 1.00 },
                new Crust() { EntityId = 2, ItemName = "Thin-Flat", ItemPrice = 1.25 },
                new Crust() { EntityId = 3, ItemName = "Stuffed", ItemPrice = 1.50 }
            });

            builder.Entity<Size>().HasData(new List<Size>
            {
                new Size() { EntityId = 1, ItemName = "Piccola", ItemPrice = 1.00 },
                new Size() { EntityId = 2, ItemName = "Medio", ItemPrice = 1.25 },
                new Size() { EntityId = 3, ItemName = "Familiare", ItemPrice = 1.50 }
            });

        }


    }
}