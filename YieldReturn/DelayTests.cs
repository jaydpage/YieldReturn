using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace YieldReturn
{
  [TestFixture]
  public class DelayTests
  {
    [TestFixture]
    public class GetStuff
    {
      [Test]
      public void ShouldReturnAllResultsOfIterationAtTheEnd()
      {
        // Arrange
        var sut = CreateSut();
        var sw = new Stopwatch();
        // Act
        sw.Start();

        foreach (var r in sut.GetStuff())
        {
          sw.Stop();
          // Assert
          sw.Elapsed.Seconds.Should().BeGreaterOrEqualTo(10);
        }
      }
    }

    [TestFixture]
    public class YieldStuff
    {
      [Test]
      public void ShouldReturnResultsOfIterationOneAtATime()
      {
        // Arrange
        var sut = CreateSut();
        var sw = new Stopwatch();
        // Act
        sw.Start();

        foreach (var r in sut.YieldStuff())
        {
          // Assert
          sw.Elapsed.Seconds.Should().BeLessOrEqualTo(r + 1);
        }
        sw.Stop();
      }
    }

    private static Delay CreateSut()
    {
      return new Delay();
    }
  }
}
