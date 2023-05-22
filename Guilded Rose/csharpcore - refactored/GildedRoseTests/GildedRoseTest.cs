using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void NonLegendary_WithDecreasingQuality_IsNeverLessThanZero()
        {
            var item = new Item { Name = "standard", SellIn = 50, Quality = 0 };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(0);
        }

        [Theory]
        [InlineData("Aged Brie")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert")]
        public void NonLegendary_WithIncreasingQuality_IsNeverGreaterThan50(string itemName)
        {
            var item = new Item { Name = itemName, SellIn = 50, Quality = 50 };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(50);
        }

        [Fact]
        public void LegendaryQuality_IsAlways80()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 50, Quality = 80 };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(80);
        }

        [Fact]
        public void StandardItemsQuality_DegradeByOne_WhenNotExpired()
        {
            var quality = 5;
            var item = new Item { Name = "Standard", SellIn = 50, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality - 1);
        }

        [Fact]
        public void StandardItemsQuality_DegradeByTwo_WhenExpired()
        {
            var quality = 5;
            var item = new Item { Name = "standard", SellIn = 0, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality - 2);

        }

        [Fact]
        public void ConjuredItemsQuality_DegradeByTwo_WhenNotExpired()
        {
            var quality = 4;
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 30, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality - 2);
        }

        [Fact]
        public void ConjuredItemsQuality_DegradeByFour_WhenExpired()
        {
            var quality = 5;
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality - 4);

        }

        [Fact]
        public void AgedBrieQuality_IncreasesByOne()
        {
            var quality = 5;
            var item = new Item { Name = "Aged Brie", SellIn = 50, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality + 1);
        }

        [Fact]
        public void AgedBrieQuality_IncreasesByTwo_WhenExpired()
        {
            var quality = 5;
            var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality + 2);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        public void BackstagePassesQuality_IncreasesBy1_ForSellIn_GreaterThan10Days(int sellIn)
        {
            var quality = 15;
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality + 1);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void BackstagePassesQuality_IncreasesBy2_ForSellIn_Between6And10Days(int sellIn)
        {
            var quality = 10;
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality + 2);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void BackstagePassesQuality_IncreasesBy3_ForSellIn_Between5And0Days(int sellIn)
        {
            var quality = 5;
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(quality + 3);
        }

        [Fact]
        public void BackstagePassesQuality_IsZero_WhenAfterSellInDate()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 45 };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(0);
        }

        [Fact]
        public void NonLegendarySellIn_DecreasesBy1()
        {
            var sellIn = 15;
            var item = new Item { Name = "standard", SellIn = sellIn, Quality = 15 };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(sellIn - 1);
        }

        [Fact]
        public void LegendarySellIn_Always80()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 80, Quality = 80 };
            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();
            item.Quality.Should().Be(80);
        }
    }
}
