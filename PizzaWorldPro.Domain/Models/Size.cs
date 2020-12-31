using PizzaWorldPro.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Models
{
    public class Size : AItemModel
    {
        public Size()
        {
        }
        public string ChooseASize()
        {
            return "This is a SIZE";
        }
    }
}