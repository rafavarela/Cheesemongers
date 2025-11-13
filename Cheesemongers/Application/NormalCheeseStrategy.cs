using CheeseMongers.Model;

namespace Cheesemongers.Application;

public class NormalCheeseStrategy : IUpdateStrategy
{
    public void Update(CheeseMongersItem item)
    {
        item.DecreaseQuality(1);
        item.ValidByDays--;

        if (item.ValidByDays < 0)
            item.DecreaseQuality(4);
    }
}
