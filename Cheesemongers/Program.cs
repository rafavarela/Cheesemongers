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
            item.UpdateItem();
        }
    }
       
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, CheeseMongers!");
    }
}

