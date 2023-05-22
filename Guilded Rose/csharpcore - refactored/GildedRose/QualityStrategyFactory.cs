using System;
using System.Collections.Generic;
namespace GildedRoseKata
{
    internal class QualityStrategyFactory
    {
        private static IDictionary<string, IQualityStrategy> _strategies;

        public QualityStrategyFactory()
        {
            _strategies = new Dictionary<string, IQualityStrategy>
            {
                { "Aged Brie", new IncreasingQualityStrategy() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassesQualityStrategy() },
                { "Sulfuras, Hand of Ragnaros", new LegendaryQualityStrategy() },
                { "Conjured Mana Cake", new DegradedQualityStrategy(2) }
            };

        }

        public IQualityStrategy GetStrategy(string itemName)
        {
            var found = _strategies.TryGetValue(itemName, out var strategy);
            return found ? strategy : new DegradedQualityStrategy();
        }
    }
}
