using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace YieldReturn
{
  [TestFixture]
  public class GenerateCollectionTests
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

    [TestFixture]
    public class CreateList
    {
      [Test]
      public void ShouldReturnListWithNumbers1Through10()
      {
        // Arrange
        var sut = CreateSut();
        // Act
        var result = sut.CreateList(10);
        // Assert
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        result.Should().BeEquivalentTo(expected);
      }
    }

    [TestFixture]
    public class Yield
    {
      [Test]
      public void ShouldReturnListWithNumbers1Through10()
      {
        // Arrange
        var sut = CreateSut();
        // Act
        var result = sut.Yield(10);
        // Assert
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        result.Should().BeEquivalentTo(expected);
      }
    }

    private static GenerateCollection CreateSut(IDoSomethingUseful doSomethingUseful = null)
    {
      doSomethingUseful ??= new DoSomethingUsefulDataBuilder().Build();
      return new GenerateCollection(doSomethingUseful);
    }
  }
}
