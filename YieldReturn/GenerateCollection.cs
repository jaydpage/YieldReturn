using System.Collections.Generic;
using System.Linq;

namespace YieldReturn
{
  public class GenerateCollection
  {
    private readonly IDoSomethingUseful _doSomethingUseful;

    public GenerateCollection(IDoSomethingUseful doSomethingUseful)
    {
      _doSomethingUseful = doSomethingUseful;
    }

    public void Execute(int give, int take)
    {
      foreach (var total in CreateList(give).Take(take))
      {
        _doSomethingUseful.Execute(total);
      }
    }

    public void ExecuteWithYield(int give, int take)
    {
      foreach (var number in Yield(give).Take(take))
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
