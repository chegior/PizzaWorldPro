using System;
using System.Linq;
using System.Collections.Generic;
using PizzaWorldPro.Domain.Abstracts;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Domain.Singleton
{
    public class ClientSingleton
    {
        public List<Store> Stores {get;set;}
        public List<APizzaModel> Pizzas { get; set; }

        private static ClientSingleton _instance;

        public static ClientSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientSingleton();
                }
                return _instance;
            }
        }

        private ClientSingleton()
        {
           Read();
        }

        public void MakeAnStore(Store NewStore)
        {
            Stores.Add(NewStore);
        }
        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(), out int input);
            // Console.WriteLine(input.GetType()+"The Value"+Stores.ElementAtOrDefault(input).Name);
            return Stores.ElementAtOrDefault(input);
        }
        private void Read()
        {
            
        }
    }
}