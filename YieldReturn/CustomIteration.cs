using System.Collections.Generic;

namespace YieldReturn
{
  public class CustomIteration
  {
    private readonly IDoSomethingUseful _doSomethingUseful;
    private readonly Generate _generate;

    public CustomIteration(IDoSomethingUseful doSomethingUseful, Generate generate)
    {
      _doSomethingUseful = doSomethingUseful;
      _generate = generate;
    }

    public IEnumerable<int> Execute(int give)
    {
      var i = 0;
      var items = new List<int>();

      while (i < give)
      {
        _doSomethingUseful.Execute(i);
        items.Add(++i);
      }

      return items;
    }

    public IEnumerable<int> ExecuteWithYield(int give)
    {
      var i = 0;

      while (i < give)
      {
        _doSomethingUseful.Execute(i);

        yield return ++i;
      }
    }
  }
}
