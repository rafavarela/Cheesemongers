using Cheesemongers.Application;
using Cheesemongers.Application.Factory;
using CheeseMongers.Model;

namespace Cheesemongers;

public class Program
{
    private IList<CheeseMongersItem> Items;

    public Program(IList<CheeseMongersItem> items)
    {
        Items = items;
    }

    public void UpdateQuality()
    {
        foreach (CheeseMongersItem item in Items)
        {
            IUpdateStrategy strategy = StrategyFactory.GetStrategyFor(item.Name);
            strategy.Update(item);
        }
    }
       
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, CheeseMongers!");
    }
}
