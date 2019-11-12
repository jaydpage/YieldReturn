using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace YieldReturn
{
    [TestFixture]
    public class NumbersTests
    {
        [TestFixture]
        public class Get1To10
        {
            [Test]
            public void ShouldReturnListWithNumbers1Through10()
            {
                // Arrange
                var sut = CreateSut();
                // Act
                var result = sut.Get1To10();
                // Assert
                var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                result.Should().BeEquivalentTo(expected);
            }
            
            [TestCase(10)]
            [TestCase(7)]
            [TestCase(5)]
            [TestCase(1)]
            public void Looping_ShouldAlwaysDoSomethingUsefulTenTimes(int thisMany)
            {
                // Arrange
                var doSomethingUseful = new DoSomethingUsefulDataBuilder().Build(); 
                var sut = CreateSut(doSomethingUseful);
                // Act
                foreach (var value in sut.Get1To10().Take(thisMany)){}
                // Assert
                doSomethingUseful.Received().Execute(10);
            }
        }

        [TestFixture]
        public class Yield1To10
        {
            [Test]
            public void ShouldReturnListWithNumbers1Through10()
            {
                // Arrange
                var sut = CreateSut();
                // Act
                var result = sut.Yield1To10();
                // Assert
                var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                result.Should().BeEquivalentTo(expected);
            }

            [TestCase(10)]
            [TestCase(7)]
            [TestCase(5)]
            [TestCase(1)]
            public void Looping_ShouldDoSomethingUsefulBasedOnNumberOfRequestedItems (int thisMany)
            {
                // Arrange
                var doSomethingUseful = new DoSomethingUsefulDataBuilder().Build();
                var sut = CreateSut(doSomethingUseful);
                // Act
                foreach (var value in sut.Get1To10().Take(thisMany)) { }
                // Assert
                doSomethingUseful.Received().Execute(thisMany);
            }
        }

        private static Numbers CreateSut(IDoSomethingUseful doSomethingUseful = null)
        {
            doSomethingUseful ??= new DoSomethingUsefulDataBuilder().Build();
            return new Numbers(doSomethingUseful);
        }
    }
}