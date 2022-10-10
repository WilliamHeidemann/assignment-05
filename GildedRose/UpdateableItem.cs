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
        if (Quality < 0) Quality = 0;
        SellIn--;
    }
}