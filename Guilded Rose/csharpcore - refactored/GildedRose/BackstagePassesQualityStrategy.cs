using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace GildedRoseKata
{
    internal class BackstagePassesQualityStrategy : IQualityStrategy
    {
        private const int MaxQuality = 50;

        public BackstagePassesQualityStrategy() { }

        public void UpdateItemQuality(Item item)
        {
            if (AfterConcert(item)) 
                item.Quality = 0;
            else if (FiveDaysToConcert(item))
                item.Quality = Math.Min(item.Quality + 3, MaxQuality);
            else if (SixToTenDaysUntilConcert(item))
                item.Quality = Math.Min(item.Quality + 2, MaxQuality);
            else
                item.Quality = Math.Min(item.Quality + 1, MaxQuality);
        }

        private static bool AfterConcert(Item item) => item.SellIn <= 0;

        private static bool FiveDaysToConcert(Item item) => 
            item.SellIn <= 5 && item.SellIn > 0;

        private static bool SixToTenDaysUntilConcert(Item item) =>
            item.SellIn <= 10 && item.SellIn >= 6;
    }
}
