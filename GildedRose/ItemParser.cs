public class ItemParser 
{
    private static readonly IEnumerable<string> LEGENDARIES = new HashSet<string>
    {
        "Sulfuras, Hand of Ragnaros",
    };

    private static readonly IEnumerable<string> CHEESES = new HashSet<string>
    {
        "Aged Brie",
    };

    private static readonly IEnumerable<string> CONJURED = new HashSet<string>
    {
        "Conjured Mana Cake",
    };
    
    private static readonly IEnumerable<string> BACKSTAGEPASSES = new HashSet<string>
    {
        "Backstage passes to a TAFKAL80ETC concert",
    };


    public static IEnumerable<UpdateableItem> ParseItems(IList<Item> items)
    {
        foreach(var item in items) 
        {
            if(LEGENDARIES.Contains(item.Name))
            {
                yield return new LegendaryItem 
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }
            else if(CHEESES.Contains(item.Name))
            {
                yield return new Cheese 
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }
            else if(CONJURED.Contains(item.Name))
            {
                yield return new ConjuredItem 
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }
            else if(BACKSTAGEPASSES.Contains(item.Name))
            {
                yield return new BackstagePass 
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };
            }
            else 
            {
                yield return new UpdateableItem
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                };   
            }
        }
    }

    public static IEnumerable<Item> ParseUpdateables(IEnumerable<UpdateableItem> updateables)
    {
        foreach(var updateable in updateables) 
        {
            yield return new Item 
            {
                Name = updateable.Name,
                Quality = updateable.Quality,
                SellIn = updateable.SellIn
            };
        }
    }
}