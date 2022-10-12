using System.Diagnostics;

namespace GildedRose;
using System.Collections.Generic;

public class Program
{
    public IList<Item> Items = null!;

    public void UpdateQuality()
    {
        Parallel.ForEach(Items, Update);
    }

    private void Update(Item item)
    {
        if(IsLegendaryItem(item.Name)) return;
        UpdateItem(item.Name)(item);
        CheckBoundsOfItemQuality(item);
        item.SellIn--;
    }
    private bool IsLegendaryItem(string itemName) => ItemNameDatabase.LEGENDARIES.Contains(itemName);
    private delegate void UpdateItemQuality(Item item);
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

    private void CheckBoundsOfItemQuality(Item item) 
    {
        if (item.Quality < 0) item.Quality = 0;
        else if (item.Quality > 50) item.Quality = 50;
    }

    private UpdateItemQuality UpdateItem(string itemName)
    {
        if (ItemNameDatabase.CHEESES.Contains(itemName)) return UpdateCheese;
        if (ItemNameDatabase.CONJURED.Contains(itemName)) return UpdateConjured;
        if (ItemNameDatabase.BACKSTAGEPASSES.Contains(itemName)) return UpdateBackStagePass;
        return UpdateGeneric;
    }
}