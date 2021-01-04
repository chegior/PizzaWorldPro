using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Abstracts
{
    public class AItemModel : AEntity
    {

        public string ItemName { get; set;}
        public double ItemPrice { get; set;}
        public List<APizzaModel> Pizza{get;set;}

    }
}
