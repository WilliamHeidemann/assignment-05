using GildedRose;

public class ConjuredItemTests 
{
    [Fact]
    public void ConjuredItemDecrementsTwiceAsFastGivenPostiveSellIn() {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        program.Items.Add(new Item { Name = "Conjured Mana Cake", SellIn = 4, Quality = 10 });

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Conjured Mana Cake");
        program.Items[0].SellIn.Should().Be(3);
        program.Items[0].Quality.Should().Be(8);
    }

    [Fact]
    public void ConjuredItemDecrementsTwiceAsFastGivenNegativeSellIn() {
        // Arrange
        var program = new Program();
        program.Items = new List<Item>();
        program.Items.Add(new Item { Name = "Conjured Mana Cake", SellIn = -4, Quality = 10 });

        // Act
        program.UpdateQuality();

        // Assert
        program.Items[0].Name.Should().Be("Conjured Mana Cake");
        program.Items[0].SellIn.Should().Be(-5);
        program.Items[0].Quality.Should().Be(6);
    }
}