using System.Collections.Generic;
using System.Threading;

namespace YieldReturn
{
  public class Delay
  {
    public IEnumerable<int> GetStuff()
    {
      var result = new List<int>();

      for (var x = 0; x < 10; x++)
      {
        Thread.Sleep(1000);
        result.Add(x);
      }

      return result;
    }

    public IEnumerable<int> YieldStuff()
    {
      for (var x = 0; x < 10; x++)
      {
        Thread.Sleep(1000);
        yield return x;
      }
    }
  }
}
