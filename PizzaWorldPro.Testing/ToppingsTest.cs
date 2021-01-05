using Xunit;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Testing
{
    public class ToppingsTest
    {
        [Fact]

        private void Test_ToppingsExists()
        {
            var sut = new Toppings();
            var actual = sut;
            var result = sut.ItemName;

            Assert.IsType<Toppings>(actual);
            Assert.NotNull(actual);
            // Assert.Collection(result, item => Assert.IsType(String));
        }
    }
}