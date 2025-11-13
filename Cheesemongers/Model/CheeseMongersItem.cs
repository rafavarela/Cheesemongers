namespace CheeseMongers.Model;

public class CheeseMongersItem
{
    public string Name { get; set; }
    public int ValidByDays { get; set; }
    public int Quality { get; set; }

    public void UpdateItem()
    {
        bool isParmigiano = Name == "Parmigiano Regiano";
        bool isTastingWithMassimo = Name == "Tasting with Chef Massimo";
        bool isCaciocavallo = Name == "Caciocavallo Podolico";
                
        if (isParmigiano)
        {
            IncreaseAgedCheeseQuality();
        }
        else if (isTastingWithMassimo)
        {
            IncreaseEventCheeseQuality();
        }
        else if (!isCaciocavallo)
        {
            // Normal cheese decreases in quality
            DecreaseQuality(1);
        }

        if (!isCaciocavallo)
        {
            ValidByDays = ValidByDays - 1;
        }
                
        if (ValidByDays >= 0) return;

        if (isParmigiano) return;

        if (isTastingWithMassimo)
        {
            Quality = 0;
            return;
        }

        if (!isCaciocavallo)
        {
            DecreaseQuality(4);
        }
    }

    private void IncreaseQuality(int amount)
    {
        if (Quality < 100)
        {
            if (Quality + amount <= 100)
            {
                Quality = Quality + amount;
            }
            else
            {
                Quality = 100;
            }
        }
    }

    private void DecreaseQuality(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Amount must be non-negative.");
        }

        Quality -= amount;

        if (Quality < 0)
        {
            Quality = 0;
        }
    }

    private void IncreaseAgedCheeseQuality()
    {
        if (Quality < 100)
        {
            Quality = Quality + 1;
        }
    }

    private void IncreaseEventCheeseQuality()
    {
        if (Quality < 100)
        {
            Quality = Quality + 1;

            if (ValidByDays < 15) IncreaseQuality(2);
            if (ValidByDays < 8) IncreaseQuality(2);
        }
    }
}
