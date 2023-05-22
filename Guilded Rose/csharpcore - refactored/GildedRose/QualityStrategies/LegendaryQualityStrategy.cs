using System;

namespace GildedRoseKata.QualityStrategies
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
