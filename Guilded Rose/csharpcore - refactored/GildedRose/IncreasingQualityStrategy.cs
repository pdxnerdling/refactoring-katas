using System;

namespace GildedRoseKata
{
    internal class IncreasingQualityStrategy : IQualityStrategy
    {
        private const int MaxQuality = 50;

        public IncreasingQualityStrategy() { }

        public void UpdateItemQuality(Item item)
        {
            var increaseAmount = IsExpired(item) ? 2 : 1;
            item.Quality = Math.Min(item.Quality + increaseAmount, MaxQuality);
        }

        private static bool IsExpired(Item item) => item.SellIn <= 0;
    }
}
