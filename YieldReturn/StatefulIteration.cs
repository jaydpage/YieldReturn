using System.Collections.Generic;

namespace YieldReturn
{
    public class StatefulIteration
    {
        private readonly IDoSomethingUseful _doSomethingUseful;

        public StatefulIteration(IDoSomethingUseful doSomethingUseful)
        {
            _doSomethingUseful = doSomethingUseful;
        }

        public void Execute(IEnumerable<int> numbers)
        {
            foreach (var total in Calculate(numbers))
            {
                _doSomethingUseful.Execute(total);
            }
        }

        private IEnumerable<int> Calculate(IEnumerable<int> numbers)
        {
            var total = 0;
            foreach (var number in numbers)
            {
                total += number;
                yield return total;
            }
        }
    }
}