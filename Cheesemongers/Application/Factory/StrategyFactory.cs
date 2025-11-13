using Cheesemongers.Application.Strategies;

namespace Cheesemongers.Application.Factory;

public static class StrategyFactory
{
    public static IUpdateStrategy GetStrategyFor(string name)
    {
        return name switch
        {
            "Parmigiano Regiano" => new ParmigianoRegianoStrategy(),
            "Tasting with Chef Massimo" => new TastingWithMassimoStrategy(),
            "Caciocavallo Podolico" => new CaciocavalloPodolicoStrategy(),
            _ => new NormalCheeseStrategy()
        };
    }
}
