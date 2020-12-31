

using PizzaWorldPro.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Models
{
    public class Crust : AItemModel
    {
        public Crust()
        {
        }
        public string ChooseACrust(){

            return "This is a CRUST";
        }
    }
}