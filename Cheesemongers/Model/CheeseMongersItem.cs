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
            if (Quality > 0)
            {
                if (!isCaciocavallo)
                {
                    Quality = Quality - 1;
                }
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
                        if (Quality < 100)
                        {
                            if (Quality + 2 <= 100)
                            {
                                Quality = Quality + 2;
                            }
                            else
                            {
                                Quality = 100;
                            }
                        }
                    }

                    if (ValidByDays < 8)
                    {
                        if (Quality < 100)
                        {
                            if (Quality + 2 <= 100)
                            {
                                Quality = Quality + 2;
                            }
                            else
                            {
                                Quality = 100;
                            }
                        }
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
                            if (Quality - 4 > 0)
                            {
                                Quality = Quality - 4;
                            }
                            else
                            {
                                Quality = 0;
                            }
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
}
