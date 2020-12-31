using System;
using System.Linq;
using System.Collections.Generic;


using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Domain.Singleton
{
    public class ClientSingleton
    {
        public List<Store> Stores {get;set;}

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
           Stores = new List<Store>{
               new Store("The Xanders Corner"),
               new Store("Industrial Main")
           };
        }

        public void MakeAnStore()
        {
            
        }
        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(), out int input);
            // Console.WriteLine(input.GetType()+"The Value"+Stores.ElementAtOrDefault(input).Name);
            // Console.ReadLine();
            return Stores.ElementAtOrDefault(input);
        }
    }
}