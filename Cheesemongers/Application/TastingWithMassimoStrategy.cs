using CheeseMongers.Model;

namespace Cheesemongers.Application;

public class TastingWithMassimoStrategy : IUpdateStrategy
{
    public void Update(CheeseMongersItem item)
    {
        item.IncreaseQuality(1);

        if (item.ValidByDays < 15)
            item.IncreaseQuality(2);

        if (item.ValidByDays < 8)
            item.IncreaseQuality(2);

        item.ValidByDays--;

        if (item.ValidByDays < 0)
            item.Quality = 0;
    }
}
