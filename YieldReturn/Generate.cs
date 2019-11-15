using System.Collections.Generic;

namespace YieldReturn
{
  public class Generate
  {
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
