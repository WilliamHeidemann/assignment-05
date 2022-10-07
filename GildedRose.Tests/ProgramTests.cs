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
        program.Items = new List<Item>();
        var item = new Item { Name = "Sword of Stormwind", SellIn = 10, Quality = 1 };
        program.Items.Add(item);

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Sword of Stormwind");
        program.Items[0].SellIn.Should().Be(9);
        program.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void QualityCanNotBeLessThan0()
    {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        var item = new Item { Name = "Rusty Axe", SellIn = 5, Quality = 0 };
        program.Items.Add(item);

        // Act
        program.UpdateQuality();

        // Assert
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

        // Act
        program.UpdateQuality();

        // Assert
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