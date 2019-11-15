using NSubstitute;
using NUnit.Framework;

namespace YieldReturn {
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
      public void ShouldAlwaysDoSomethingUsefulTenTimes(int count)
      {
        // Arrange
        var doSomethingUseful = new DoSomethingUsefulDataBuilder().Build();
        var sut = CreateSut(doSomethingUseful);
        // Act
        sut.Execute(10, count);
        // Assert
        doSomethingUseful.Received(count).Execute(Arg.Any<int>());
      }
    }

    [TestFixture]
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
        var sut = CreateSut(doSomethingUseful);
        // Act
        sut.ExecuteWithYield(10, count);
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