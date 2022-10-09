using System;
using System.Collections.Generic;

namespace GildedRose;
public class Program
{
    public IList<Item> Items;
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

    private enum ItemType
    {
        Generic,
        Brie,
        Conjured,
        BackStagePass,
        Legendary,
    }
    
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            var type = GetItemType(item.Name);
            switch (type)
            {
                case ItemType.Generic:
                    UpdateGeneric(item);
                    break;
                
                case ItemType.Brie:
                    UpdateBrie(item);
                    break;
                
                case ItemType.Conjured:
                    UpdateConjured(item);
                    break;
                
                case ItemType.BackStagePass:
                    UpdateBackStagePass(item);
                    break;
                
                case ItemType.Legendary:
                    item.SellIn++;
                    break;
            }

            item.SellIn--;
        }
    }

    private static ItemType GetItemType(string itemName)
    {
        if (itemName.ToLower().Contains("brie")) return ItemType.Brie;
        if (itemName.ToLower().Contains("conjured")) return ItemType.Conjured;
        if (itemName.Contains("Backstage pass")) return ItemType.BackStagePass;
        if (itemName.Equals("Sulfuras, Hand of Ragnaros")) return ItemType.Legendary;
        return ItemType.Generic;
    }

    private static void UpdateGeneric(Item item)
    {
        if (item.Quality <= 0)
        {
            return;
        }
        item.Quality--;
        if (item.SellIn <= 0) item.Quality--;
    }

    private static void UpdateBrie(Item item)
    {
        item.Quality++;
        if (item.SellIn <= 0) item.Quality++;
        item.Quality = Math.Min(item.Quality, 50);
    }
    
    private static void UpdateConjured(Item item)
    {
        if(item.Quality <= 0) return;
        item.Quality -= 2;
        if (item.SellIn <= 0) item.Quality -= 2;
    }

    private static void UpdateBackStagePass(Item item)
    {
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
            return;
        }

        item.Quality++;
        if (item.SellIn <= 10) item.Quality++;
        if (item.SellIn <=  5) item.Quality++;
    }
}

public class Item
{
    public string Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}