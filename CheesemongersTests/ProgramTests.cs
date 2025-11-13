using Cheesemongers;
using CheeseMongers.Model;

namespace CheesemongersTests;

public class ProgramTests
{
    private CheeseMongersItem CreateItem(string name, int validByDays, int quality)
    {
        return new CheeseMongersItem
        {
            Name = name,
            ValidByDays = validByDays,
            Quality = quality
        };
    }

    private Program CreateProgram(params CheeseMongersItem[] items)
    {
        return new Program(new List<CheeseMongersItem>(items));
    }


    [Fact]
    public void NormalCheese_DecreasesQualityAndValidByDays()
    {
        var item = CreateItem("Provolone", 5, 10);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(4, item.ValidByDays);
        Assert.Equal(9, item.Quality);
    }

    [Fact]
    public void NormalCheese_QualityNeverNegative()
    {
        var item = CreateItem("Provolone", 5, 0);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void ParmigianoRegiano_IncreasesQualityOverTime()
    {
        var item = CreateItem("Parmigiano Regiano", 5, 10);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(4, item.ValidByDays);
        Assert.Equal(11, item.Quality);
    }

    [Fact]
    public void ParmigianoRegiano_QualityNeverExceeds100()
    {
        var item = CreateItem("Parmigiano Regiano", 5, 100);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(100, item.Quality);
    }

    [Fact]
    public void CaciocavalloPodolico_DoesNotChange()
    {
        var item = CreateItem("Caciocavallo Podolico", 10, 80);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(10, item.ValidByDays);
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void TastingWithChefMassimo_IncreasesQualityNormally()
    {
        var item = CreateItem("Tasting with Chef Massimo", 20, 10);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(19, item.ValidByDays);
        Assert.Equal(11, item.Quality); // +1
    }

    [Fact]
    public void TastingWithChefMassimo_IncreasesFasterWhen14DaysOrLess()
    {
        var item = CreateItem("Tasting with Chef Massimo", 14, 10);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(13, item.ValidByDays);
        Assert.Equal(13, item.Quality); // +3 total
    }

    [Fact]
    public void TastingWithChefMassimo_IncreasesEvenFasterWhen7DaysOrLess()
    {
        var item = CreateItem("Tasting with Chef Massimo", 7, 10);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(6, item.ValidByDays);
        Assert.Equal(15, item.Quality); // +5 total
    }

    [Fact]
    public void TastingWithChefMassimo_QualityDropsToZeroAfterEvent()
    {
        var item = CreateItem("Tasting with Chef Massimo", 0, 40);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(-1, item.ValidByDays);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void NormalCheese_QualityDecreasesFiveTimesFasterAfterExpiration()
    {
        var item = CreateItem("Provolone", 0, 10);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(-1, item.ValidByDays);
        Assert.Equal(5, item.Quality); // -4 (five times faster than -1 per day)
    }

    [Fact]
    public void ExpiredCheese_QualityNeverNegative()
    {
        var item = CreateItem("Provolone", -1, 3);
        var program = CreateProgram(item);

        program.UpdateQuality();

        Assert.Equal(0, item.Quality);
    }
}