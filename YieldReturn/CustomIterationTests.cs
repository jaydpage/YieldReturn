using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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
    public class ExecuteWithYield
    {
      [TestCase(10, new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
      [TestCase(7, new [] { 1, 2, 3, 4, 5, 6, 7 })]
      [TestCase(5, new [] { 1, 2, 3, 4, 5 })]
      [TestCase(1, new [] { 1 })]
      public void ShouldDoSomethingUsefulBasedOnNumberOfRequestedItems(int count, int [] expected)
      {
        // Arrange
        var doSomethingUseful = new DoSomethingUsefulDataBuilder().Build();
        var give = 10;
        var sut = CreateSut(doSomethingUseful);
        // Act
        var result = sut.ExecuteWithYield(give).Take(count);
        // Assert
        result.Should().BeEquivalentTo(expected);
        doSomethingUseful.Received(count).Execute(Arg.Any<int>());
      }
    }

    private static CustomIteration CreateSut(IDoSomethingUseful doSomethingUseful = null)
    {
      doSomethingUseful ??= new DoSomethingUsefulDataBuilder().Build();
      return new CustomIteration(doSomethingUseful);
    }
  }
}
