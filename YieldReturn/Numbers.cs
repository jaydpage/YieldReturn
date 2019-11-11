using System.Collections.Generic;

namespace YieldReturn
{
    public class Numbers
    {
        private readonly IDoSomethingUseful _doSomethingUseful;

        public Numbers(IDoSomethingUseful doSomethingUseful)
        {
            _doSomethingUseful = doSomethingUseful;
        }

        public IEnumerable<int> Get1To10()
        {
            var i = 0;
            var items = new List<int>();
            while (i < 10)
            {
                items.Add(++i);
                _doSomethingUseful.Execute(i);
            }

            return items;
        }

        public IEnumerable<int> Yield1To10()
        {
            var i = 0;
            while (i < 10)
            {
                yield return ++i;
                _doSomethingUseful.Execute(i);
            }
        }
    }
}