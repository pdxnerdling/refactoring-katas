using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private readonly QualityStrategyFactory _qualityStrategyFactory;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            _qualityStrategyFactory = new QualityStrategyFactory();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                IQualityStrategy qualityUpdator = _qualityStrategyFactory.GetStrategy(item.Name);
                qualityUpdator.UpdateItemQuality(item);
                if (NotASulfura(item)) item.SellIn--;
            }
        }

        private static bool NotASulfura(Item item) => item.Name != "Sulfuras, Hand of Ragnaros";
    }
}
