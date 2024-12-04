using System.Collections.Generic;
using csharp;
using NUnit.Framework;

namespace csharp.tests;

public class QualityTests {
    [Theory]
    [TestCase(10, 1, 9)]
    [TestCase(10, 7, 3)]
    [TestCase(3, 6, -3)]
    public void SellInPositive_DecreaseByOneEachDay(int startQuality, int days, int expectedQuality)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = startQuality } };
        GildedRose app = new GildedRose(Items);

        for(int i = 0;  i < days; i++){
            app.UpdateQuality();
        }

        Assert.AreEqual(expectedQuality, Items[0].Quality);
    }

    [Theory]
    [TestCase(1, 10, 1, 9)]
    [TestCase(0, 10, 7, 3)]
    [TestCase(-1, 0, 6, -12)]
    [TestCase(-10, 1, 6, -10)]
    public void SellInNegative_DecreaseByTwoEachDay(int sellIn, int startQuality, int days, int expectedQuality)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellIn, Quality = startQuality } };
        GildedRose app = new GildedRose(Items);

        for(int i = 0;  i < days; i++){
            app.UpdateQuality();
        }

        Assert.AreEqual(expectedQuality, Items[0].Quality);
    }
}