using Cheesemongers.Application;
using Cheesemongers.Application.Strategies;
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
            IUpdateStrategy strategy = item.Name switch
            {
                "Parmigiano Regiano" => new ParmigianoRegianoStrategy(),
                "Tasting with Chef Massimo" => new TastingWithMassimoStrategy(),
                "Caciocavallo Podolico" => new CaciocavalloPodolicoStrategy(),
                _ => new NormalCheeseStrategy()
            };

            strategy.Update(item);
        }
    }
       
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, CheeseMongers!");
    }
}
