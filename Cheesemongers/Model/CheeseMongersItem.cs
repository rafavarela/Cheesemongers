namespace CheeseMongers.Model;

public class CheeseMongersItem
{
    public string Name { get; set; }
    public int ValidByDays { get; set; }
    public int Quality { get; set; }

    public void UpdateItem()
    {
        if (Name != "Parmigiano Regiano" && Name != "Tasting with Chef Massimo")
        {
            if (Quality > 0)
            {
                if (Name != "Caciocavallo Podolico")
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

                if (Name == "Tasting with Chef Massimo")
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

        if (Name != "Caciocavallo Podolico")
        {
            ValidByDays = ValidByDays - 1;
        }

        if (ValidByDays < 0)
        {
            if (Name != "Parmigiano Regiano")
            {
                if (Name != "Tasting with Chef Massimo")
                {
                    if (Quality > 0)
                    {
                        if (Name != "Caciocavallo Podolico")
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
