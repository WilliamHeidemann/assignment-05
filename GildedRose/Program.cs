namespace GildedRose;
public class Program
{
    public IList<Item> Items = null!;
    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program()
        {
            Items = new List<Item>
                                        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            }

        };

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < app.Items.Count; j++)
            {
                Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }

    }

    public void UpdateQuality()
    {
        Parallel.ForEach(Items, Update);
    }

    private void Update(Item item)
    {
        var updateQualityOfItem = GetItemType(item.Name);
        updateQualityOfItem(item);
        CheckBoundsOfItemQuality(item);
        item.SellIn--;
    }

    private void UpdateGeneric(Item item)
    {
        item.Quality--;
        if (item.SellIn <= 0) item.Quality--;
    }

    private void UpdateBrie(Item item)
    {
        item.Quality++;
        if (item.SellIn <= 0) item.Quality++;
    }

    private void UpdateConjured(Item item)
    {
        item.Quality -= 2;
        if (item.SellIn <= 0) item.Quality -= 2;
    }

    private void UpdateBackStagePass(Item item)
    {
        item.Quality++;
        if (item.SellIn <= 10) item.Quality++;
        if (item.SellIn <= 5) item.Quality++;
        if (item.SellIn <= 0) item.Quality = 0;
    }

    private void UpdateLegendary(Item item) 
    {

    }

    public void CheckBoundsOfItemQuality(Item item) 
    {
        if (item.Quality < 0) item.Quality = 0;
        else if (item.Quality > 50) item.Quality = 50;
    }

    private UpdateItemQuality GetItemType(string itemName)
    {
        if (ItemNameDatabase.CHEESES.Contains(itemName)) return new UpdateItemQuality(UpdateBrie);
        if (ItemNameDatabase.CONJURED.Contains(itemName)) return new UpdateItemQuality(UpdateConjured);
        if (ItemNameDatabase.BACKSTAGEPASSES.Contains(itemName)) return new UpdateItemQuality(UpdateBackStagePass);
        if (ItemNameDatabase.LEGENDARIES.Contains(itemName)) return new UpdateItemQuality(UpdateLegendary);
        return new UpdateItemQuality(UpdateGeneric);
    }

    public delegate void UpdateItemQuality(Item item);
}