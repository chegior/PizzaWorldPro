using PizzaWorldPro.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Factories
{
    class GenericPizzaFactory
    {
        public T Make<T>() where T : APizzaModel,new() 
        {
            return new T();
        }
    }
}