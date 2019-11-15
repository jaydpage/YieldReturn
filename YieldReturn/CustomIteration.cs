using System.Linq;

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

    public void Execute(int give, int take)
    {
      foreach (var total in _generate.CreateList(give).Take(take))
      {
        _doSomethingUseful.Execute(total);
      }
    }

    public void ExecuteWithYield(int give, int take)
    {
      foreach (var number in _generate.Yield(give).Take(take))
      {
        _doSomethingUseful.Execute(number);
      }
    }
  }
}
