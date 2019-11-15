using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace YieldReturn
{
  [TestFixture]
  public class CustomIterationTests
  {
    [TestFixture]
    public class Execute
    {
      [TestCase(10)]
      [TestCase(7)]
      [TestCase(5)]
      [TestCase(1)]
      public void ShouldAlwaysDoSomethingUsefulBasedOnTheNumberOfGivenItems(int count)
      {
        // Arrange
        var doSomethingUseful = new DoSomethingUsefulDataBuilder().Build();
        var give = 10;
        var sut = CreateSut(doSomethingUseful);
        // Act
        var result = sut.Execute(give).Take(count);
        // Assert
        doSomethingUseful.Received(give).Execute(Arg.Any<int>());
      }
    }

    [TestFixture]
    [Ignore("Figure out how this works")]
    public class ExecuteWithYield
    {
      [TestCase(10)]
      [TestCase(7)]
      [TestCase(5)]
      [TestCase(1)]
      public void ShouldDoSomethingUsefulBasedOnNumberOfRequestedItems(int count)
      {
        // Arrange
        var doSomethingUseful = new DoSomethingUsefulDataBuilder().Build();
        var give = 10;
        var sut = CreateSut(doSomethingUseful);
        // Act
        var result = sut.Execute(give).Take(count);
        // Assert
        doSomethingUseful.Received(count).Execute(Arg.Any<int>());
      }
    }

    private static CustomIteration CreateSut(IDoSomethingUseful doSomethingUseful = null)
    {
      doSomethingUseful ??= new DoSomethingUsefulDataBuilder().Build();
      return new CustomIteration(doSomethingUseful, new Generate());
    }
  }
}
