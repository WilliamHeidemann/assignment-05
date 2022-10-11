namespace GildedRose;
public class Program
{
    public IList<Item> Items = null!;
    public delegate void UpdateItemQuality(Item item);
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
        if(IsLegendaryItem(item.Name)) return; 
        var updateQualityOfItem = GetUpdateMethod(item.Name);
        updateQualityOfItem(item);
        CheckBoundsOfItemQuality(item);
        item.SellIn--;
    }

    private bool IsLegendaryItem(string itemName) => ItemNameDatabase.LEGENDARIES.Contains(itemName);

    private void UpdateGeneric(Item item)
    {
        item.Quality--;
        if (item.SellIn <= 0) item.Quality--;
    }

    private void UpdateCheese(Item item)
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

    public void CheckBoundsOfItemQuality(Item item) 
    {
        if (item.Quality < 0) item.Quality = 0;
        else if (item.Quality > 50) item.Quality = 50;
    }

    private UpdateItemQuality GetUpdateMethod(string itemName)
    {
        if (ItemNameDatabase.CHEESES.Contains(itemName)) return new UpdateItemQuality(UpdateCheese);
        if (ItemNameDatabase.CONJURED.Contains(itemName)) return new UpdateItemQuality(UpdateConjured);
        if (ItemNameDatabase.BACKSTAGEPASSES.Contains(itemName)) return new UpdateItemQuality(UpdateBackStagePass);
        return new UpdateItemQuality(UpdateGeneric);
    }
}