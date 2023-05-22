using System;

namespace GildedRoseKata
{
    internal class LegendaryQualityStrategy : IQualityStrategy
    {
        private const int LegendaryStaticQuality = 80;

        public LegendaryQualityStrategy() { }

        public void UpdateItemQuality(Item item)
        {
            item.Quality = LegendaryStaticQuality;
        }
    }
}
