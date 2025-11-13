using CheeseMongers.Model;

namespace Cheesemongers.Application;

public class ParmigianoRegianoStrategy : IUpdateStrategy
{
    public void Update(CheeseMongersItem item)
    {
        item.IncreaseQuality(1);
        item.ValidByDays--;
        // After expiration, Parmigiano keeps improving — no extra logic needed.
    }
}
