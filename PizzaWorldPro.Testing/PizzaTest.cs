using PizzaWorldPro.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
  public class PizzaTests
  {
    [Fact]
    private void Test_Meat_PizzaExists()
    {

      var sut = new PizzaMeat();
      var actual = sut;
      Assert.IsType<PizzaMeat>(actual);
      Assert.NotNull(actual);
    }
    private void Test_Hawaiian_PizzaExists()
    {

      var sut = new PizzaHawaiian();
      var actual = sut;
      Assert.IsType<PizzaHawaiian>(actual);
      Assert.NotNull(actual);
    }
    private void Test_Suprerme_PizzaExists()
    {

      var sut = new PizzaSupreme();
      var actual = sut;
      Assert.IsType<PizzaSupreme>(actual);
      Assert.NotNull(actual);
    }
    private void Test_veggie_PizzaExists()
    {

      var sut = new PizzaVeggie();
      var actual = sut;
      Assert.IsType<PizzaVeggie>(actual);
      Assert.NotNull(actual);
    }
  }
}