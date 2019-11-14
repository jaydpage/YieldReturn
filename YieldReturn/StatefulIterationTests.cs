using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace YieldReturn
{
    [TestFixture]
    public class StatefulIterationTests
    {
        [TestFixture]
        public class Execute
        {
            [Test]
            public void ShouldMaintainStateCorrectlWhileLooping()
            {
                // Arrange
                var numbers = new List<int> {1, 2, 3, 4, 5};
                var doSomethingUseful = new DoSomethingUsefulDataBuilder().Build();
                var sut = CreateSut(doSomethingUseful);
                // Act
                sut.Execute(numbers);
                // Assert
                doSomethingUseful.Received().Execute(1);
                doSomethingUseful.Received().Execute(3);
                doSomethingUseful.Received().Execute(6);
                doSomethingUseful.Received().Execute(10);
                doSomethingUseful.Received().Execute(15);
            }
        }

        private static StatefulIteration CreateSut(IDoSomethingUseful doSomethingUseful = null)
        {
            doSomethingUseful ??= new DoSomethingUsefulDataBuilder().Build();
            return new StatefulIteration(doSomethingUseful);
        }
    }
}