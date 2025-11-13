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

        if (!isParmigiano && !isTastingWithMassimo)
        {
            if (!isCaciocavallo)
            {
                DecreaseQuality(1);
            }
        }
        else
        {
            if (Quality < 100)
            {
                Quality = Quality + 1;

                if (isTastingWithMassimo)
                {
                    if (ValidByDays < 15)
                    {
                        IncreaseQuality(2);
                    }

                    if (ValidByDays < 8)
                    {
                        IncreaseQuality(2);
                    }
                }
            }
        }

        if (!isCaciocavallo)
        {
            ValidByDays = ValidByDays - 1;
        }

        if (ValidByDays < 0)
        {
            if (!isParmigiano)
            {
                if (!isTastingWithMassimo)
                {
                    if (Quality > 0)
                    {
                        if (!isCaciocavallo)
                        {
                            DecreaseQuality(4);
                        }
                    }
                }
                else
                {
                    Quality = 0;
                }
            }
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
}
