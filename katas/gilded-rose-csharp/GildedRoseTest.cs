using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void SingleDay_SellInDecreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(9, Items[0].SellIn);
        }


        [Test]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(20)]
        public void MultipleDays_SellInDecreasesByNumberOfDays(int numberOfDays)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 30, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            for (var i = 0; i < numberOfDays; i++)
            {
                app.UpdateQuality();
            }

            var expectedSellIn = 30 - numberOfDays;
            Assert.AreEqual(expectedSellIn, Items[0].SellIn);
        }

        [Test]
        public void SellInStartsAtZero_SellInGoesNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(-1, Items[0].SellIn);
        }

        [Test]
        [TestCase(-5)]
        [TestCase(-15)]
        [TestCase(-29)]
        public void SellInStartsNegative_SellInContinuesToGoDown(int initialSellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = initialSellIn, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(initialSellIn - 1, Items[0].SellIn);
        }
    }
}
