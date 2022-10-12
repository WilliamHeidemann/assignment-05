namespace GildedRose;

public class EntryPoint
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");
        
        var app = new Program()
        {
            Items = new List<Item>
            {
                new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
                new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } 
            }
        };
        // for (int i = 0; i < 1000000; i++)
        // {
        //     app.Items.Add(new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
        // }
        
        // Stopwatch stopwatch = new Stopwatch();
        
        // stopwatch.Start();
        
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
        // stopwatch.Stop();
        // Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

    }
}