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
            if (item.Name != "Parmigiano Regiano" && item.Name != "Tasting with Chef Massimo")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Caciocavallo Podolico")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 100)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Tasting with Chef Massimo")
                    {
                        if (item.ValidByDays < 15)
                        {
                            if (item.Quality < 100)
                            {
                                if (item.Quality + 2 <= 100)
                                {
                                    item.Quality = item.Quality + 2;
                                }
                                else
                                {
                                    item.Quality = 100;
                                }
                            }
                        }

                        if (item.ValidByDays < 8)
                        {
                            if (item.Quality < 100)
                            {
                                if (item.Quality + 2 <= 100)
                                {
                                    item.Quality = item.Quality + 2;
                                }
                                else
                                {
                                    item.Quality = 100;
                                }
                            }
                        }
                    }
                }
            }

            if (item.Name != "Caciocavallo Podolico")
            {
                item.ValidByDays = item.ValidByDays - 1;
            }

            if (item.ValidByDays < 0)
            {
                if (item.Name != "Parmigiano Regiano")
                {
                    if (item.Name != "Tasting with Chef Massimo")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Caciocavallo Podolico")
                            {
                                if (item.Quality - 4 > 0)
                                {
                                    item.Quality = item.Quality - 4;
                                }
                                else
                                {
                                    item.Quality = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
            }
        }
    }

    static void Main(string[] args)
    {

        Console.WriteLine("Hello, CheeseMongers!");
    }
}

