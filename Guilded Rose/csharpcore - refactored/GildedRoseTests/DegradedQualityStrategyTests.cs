using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.QualityStrategies;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace GildedRoseTests
{
    public class DegradedQualityStrategyTests
    {
        private IQualityStrategy _degradedQualityStrategy;

        public DegradedQualityStrategyTests()
        {
            _degradedQualityStrategy = new DegradedQualityStrategy();
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        public void UpdateItemStrategy_ItemQuality_DegradesByOne_BeforeOrEqualToSellIn(int sellIn)
        {
            var quality = 5;
            var item = new Item { Name = "Standard", SellIn = sellIn, Quality = quality };
            _degradedQualityStrategy.UpdateItemQuality(item);
            item.Quality.Should().Be(quality - 1);
        }

        [Fact]
        public void UpdateItemStrategy_ItemQuality_DegradesByTwo_AfterSellIn()
        {
            var quality = 5;
            var item = new Item { Name = "standard", SellIn = -1, Quality = quality };
            _degradedQualityStrategy.UpdateItemQuality(item);
            item.Quality.Should().Be(quality - 2);

        }

        [Fact]
        public void UpdateItemStrategy_ItemQuality_IsNeverLessThanZero()
        {
            var item = new Item { Name = "Item Name", SellIn = 50, Quality = 0 };
            _degradedQualityStrategy.UpdateItemQuality(item);
            item.Quality.Should().Be(0);
        }
    }
}
