using CheeseMongers.Model;

namespace Cheesemongers.Application;

public interface IUpdateStrategy
{
    void Update(CheeseMongersItem item);
}
