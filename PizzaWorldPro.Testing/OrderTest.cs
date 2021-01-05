using PizzaWorldPro.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
  public class OrderTests
  {
    [Fact]
    private void Test_OrderExists()
    {
      
      var sut = new Order();
      Order sut1 = new Order(); 
      var actual = sut;
      Assert.IsType<Order>(actual);
      Assert.NotNull(actual);
    }
  }
}