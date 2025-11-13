namespace CheeseMongers.Model;

public class CheeseMongersItem
{
    public string Name { get; set; }
    public int ValidByDays { get; set; }
    public int Quality { get; set; }

    public void IncreaseQuality(int amount)
    {
        if (Quality + amount > 100)
            Quality = 100;
        else
            Quality += amount;
    }

    public void DecreaseQuality(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Amount must be non-negative.");
        }

        Quality -= amount;

        if (Quality < 0)
            Quality = 0;
        
    }
}
