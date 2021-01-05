using PizzaWorldPro.Domain.Models;
using Xunit;

namespace PizzaWorldPro.Testing
{
    class StoreTest
    {
        [Fact]
        private void Test_StoreExists()
        {
            var sut = new Store();
            var actual = sut;

            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }
    }
}