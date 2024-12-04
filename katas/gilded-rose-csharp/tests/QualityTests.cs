using System.Collections.Generic;
using csharp;
using NUnit.Framework;

namespace csharp.tests;

public class QualityTests {
    [Test]
    [TestCase(10, 1, 9)]
    [TestCase(10, 7, 3)]
    [TestCase(3, 3, 0)]
    public void SellInPositive_DecreaseByOneEachDay(int startQuality, int days, int expectedQuality)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = startQuality } };
        GildedRose app = new GildedRose(Items);

        for(int i = 0;  i < days; i++){
            app.UpdateQuality();
        }

        Assert.AreEqual(expectedQuality, Items[0].Quality);
    }

    [Test]
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

    [Test]
    public void ZeroQuality_QualityDoesNotGoNegative()
    {
        var items = new List<Item>
        { 
            new Item 
            { 
                Name = "foo", 
                SellIn = 10, 
                Quality = 0 
            } 
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.AreEqual(0, items[0].Quality);
    }

    [Test]
    public void AgedBrie_IncreasesInQuality()
    {
        var items = new List<Item>
        { 
            new Item 
            { 
                Name = "Aged Brie", 
                SellIn = 10, 
                Quality = 10 
            } 
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.AreEqual(11, items[0].Quality);
    }

    [Test]
    public void QualityIsFifty_QualityNeverExceedsFifty()
    {
        var items = new List<Item>
        { 
            new Item 
            { 
                Name = "Aged Brie", 
                SellIn = 10, 
                Quality = 50 
            } 
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.AreEqual(50, items[0].Quality);
    }
    
    [Test]
    public void Sulfuras_QualityAlwaysEighty()
    {
        var items = new List<Item>
        { 
            new Item 
            { 
                Name = "Sulfuras, Hand of Ragnaros", 
                SellIn = 10, 
                Quality = 80 
            } 
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.AreEqual(80, items[0].Quality);
    }
}