using CheeseMongers.Model;

namespace Cheesemongers.Application.Strategies;

public class CaciocavalloPodolicoStrategy : IUpdateStrategy
{
    public void Update(CheeseMongersItem item)
    {
        // This cheese never decreases in quality or in valid days
        // So... no changes needed.
    }
}
