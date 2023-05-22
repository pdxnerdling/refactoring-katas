using System;

namespace GildedRoseKata.QualityStrategies
{
    internal class DegradedQualityStrategy : IQualityStrategy
    {
        private static int _increaseFactor;

        public DegradedQualityStrategy(int increaseFactor = 1)
        {
            _increaseFactor = increaseFactor;
        }

        public void UpdateItemQuality(Item item)
        {
            if (item.Quality == 0) return;
            var reduceAmount = IsExpired(item) ? 2 : 1;
            reduceAmount *= _increaseFactor;
            item.Quality = Math.Max(0, item.Quality - reduceAmount);
        }

        private static bool IsExpired(Item item) => item.SellIn <= 0;
    }
}
