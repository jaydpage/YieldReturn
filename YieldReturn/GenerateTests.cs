using FluentAssertions;
using NUnit.Framework;

namespace YieldReturn
{
  [TestFixture]
  public class GenerateTests
  {
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

    private static Generate CreateSut()
    {
      return new Generate();
    }
  }
}
