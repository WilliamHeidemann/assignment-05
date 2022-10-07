using System.Reflection;
using GildedRose;
namespace GildedRose.Tests;



public class ProgramTests
{
    [Fact]
    public void UpdateQualityDecrementsNormalItem()
    {
        // Arrange
        var program = new Program();

        var item = new Item { Name = "Sword of Stormwind", SellIn = 10, Quality = 1 };
        program.Items = new List<Item>() { item };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Sword of Stormwind");
        program.Items[0].SellIn.Should().Be(9);
        program.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void UpdateQualityLeavesLegendaryItemsUntouched()
    {
        // Arrange
        var program = new Program();

        var legendaryItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

        program.Items = new List<Item>() { legendaryItem };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Sulfuras, Hand of Ragnaros");
        program.Items[0].SellIn.Should().Be(0);
        program.Items[0].Quality.Should().Be(80);
    }

    [Fact]
    public void UpdateQualityLeavesLegendaryItemWithNegativeQualityUntouched()
    {
        // Arrange
        var program = new Program();

        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = -80 };
        program.Items = new List<Item>() { item };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Sulfuras, Hand of Ragnaros");
        program.Items[0].SellIn.Should().Be(0);
        program.Items[0].Quality.Should().Be(-80);
    }

    [Fact]
    public void UpdateQualityLeavesLegendaryItemWithNegativeSellIn()
    {
        // Arrange
        var program = new Program();

        var legendaryItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 };

        program.Items = new List<Item>() { legendaryItem };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Sulfuras, Hand of Ragnaros");
        program.Items[0].SellIn.Should().Be(-1);
        program.Items[0].Quality.Should().Be(80);
    }

    [Fact]
    public void UpdateQualityLeavesLegendaryItemWithPositiveSellIn()
    {
        // Arrange
        var program = new Program();

        var legendaryItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 };

        program.Items = new List<Item>() { legendaryItem };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Sulfuras, Hand of Ragnaros");
        program.Items[0].SellIn.Should().Be(1);
        program.Items[0].Quality.Should().Be(80);
    }

    [Fact]
    public void UpdateQualityBackstagePassIncreaseQualityBy1WithSellInOver10()
    {
        // Arrange
        var program = new Program();

        var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 };

        program.Items = new List<Item>() { backstagePassItem };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        program.Items[0].SellIn.Should().Be(19);
        program.Items[0].Quality.Should().Be(11);
    }
    [Fact]
    public void UpdateQualityBackstagePassIncreaseQualityBy2WithSellInOver5()
    {
        // Arrange
        var program = new Program();

        var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };

        program.Items = new List<Item>() { backstagePassItem };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        program.Items[0].SellIn.Should().Be(9);
        program.Items[0].Quality.Should().Be(12);
    }

    [Fact]
    public void UpdateQualityBackstagePassIncreaseQuality13WithSellIn1()
    {
        // Arrange
        var program = new Program();

        var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 };

        program.Items = new List<Item>() { backstagePassItem };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        program.Items[0].SellIn.Should().Be(0);
        program.Items[0].Quality.Should().Be(13);
    }

    [Fact]
    public void UpdateQualityBackstagePassIncreaseQuality0WithSellIn0()
    {
        // Arrange
        var program = new Program();

        var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };

        program.Items = new List<Item>() { backstagePassItem };

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        program.Items[0].SellIn.Should().Be(-1);
        program.Items[0].Quality.Should().Be(0);

 [Fact]      
    public void QualityCanNotBeLessThan0()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        var item = new Item { Name = "Rusty Axe", SellIn = 5, Quality = 0 };
        program.Items.Add(item);
        
        program.UpdateQuality();
        
        program.Items[0].Name.Should().Be("Rusty Axe");
        program.Items[0].SellIn.Should().Be(4);
        program.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void WhenSellInHasPassedQualityDegradesTwiceAsFast()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        var item = new Item { Name = "Blades of Destiny", SellIn = 0, Quality = 4 };
        program.Items.Add(item);
        
        program.UpdateQuality();
        
        program.Items[0].Name.Should().Be("Blades of Destiny");
        program.Items[0].SellIn.Should().Be(-1);
        program.Items[0].Quality.Should().Be(2);
    }

    /*
    [Fact]
    public void Main_when_run_prints_Hello_World()
    {
        // Arrange
        using var writer = new StringWriter();
        Console.SetOut(writer);
        var outputFile = File.OpenText("../../../../output.txt").ReadToEnd().TrimEnd();

         // Act
        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        // Assert
        var output = writer.GetStringBuilder().ToString().TrimEnd();
        output.Should().Be(outputFile);
    }
    */
}