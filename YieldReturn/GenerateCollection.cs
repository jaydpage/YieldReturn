using System.Collections.Generic;

namespace YieldReturn
{
    public class GenerateCollection
    {
        private readonly IDoSomethingUseful _doSomethingUseful;

        public GenerateCollection(IDoSomethingUseful doSomethingUseful)
        {
            _doSomethingUseful = doSomethingUseful;
        }

        public void Execute(int times)
        {
            foreach (var total in CreateList(times))
            {
                _doSomethingUseful.Execute(total);
            }
        }

        public void ExecuteWithYield(int times)
        {
            foreach (var number in Yield(times))
            {
                _doSomethingUseful.Execute(number);
            }
        }

        public IEnumerable<int> CreateList(int count)
        {
            var i = 0;
            var items = new List<int>();
            while (i < count)
            {
                items.Add(++i);
            }

            return items;
        }

        public IEnumerable<int> Yield(int count)
        {
            var i = 0;
            while (i < count)
            {
                yield return ++i;
            }
        }
    }
}