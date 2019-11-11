using FluentAssertions;
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
        }

        private static Numbers CreateSut(IDoSomethingUseful doSomethingUseful = null)
        {
            doSomethingUseful ??= new DoSomethingUsefulDataBuilder().Build();
            return new Numbers(doSomethingUseful);
        }
    }
}