public class Item
{
    public string Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}

public class LegendaryItem : UpdateableItem
{
    public override void UpdateQuality()
    {
        return;
    }
}

public class Cheese : UpdateableItem
{
    public override void UpdateQuality()
    {
        if(Quality < 50)
        {
            if(SellIn > 0)
            {
                Quality++;
            }
            else 
            {
                Quality += 2;
            }
        }
        if (Quality > 50) Quality = 50;
        SellIn--;
    }
}

public class ConjuredItem : UpdateableItem
{
    public override void UpdateQuality()
    {
        if(SellIn > 0)
        {
            Quality -= 2;
        }
        else 
        {
            Quality -= 4;
        }
        if (Quality < 0) Quality = 0;
        SellIn--;
        
    }
}

public class BackstagePass : UpdateableItem
{
    public override void UpdateQuality()
    {
        if(SellIn > 10)
        {
            Quality++;
        }
        else if(SellIn > 5) 
        {
            Quality += 2;
        }
        else if(SellIn > 0)
        {
            Quality += 3;
        }
        else 
        {
            Quality = 0;
        }
        if(Quality > 50) Quality = 50;
        else if (Quality < 0) Quality = 0;
        SellIn--;
    }
}