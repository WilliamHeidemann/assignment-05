public class UpdateableItem : Item, IUpdateable
{
    public virtual void UpdateQuality()
    {
        if(SellIn > 0)
        {
            Quality--;
        }
        else 
        {
            Quality -= 2;
        }
        SellIn--;
        CheckBounds();
    }

    public void CheckBounds() 
    {
        if (Quality < 0) Quality = 0;
        else if (Quality > 50) Quality = 50;
    }
}