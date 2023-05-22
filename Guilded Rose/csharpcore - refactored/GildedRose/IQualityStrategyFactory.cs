namespace GildedRoseKata
{
    public interface IQualityStrategyFactory
    {
        IQualityStrategy GetStrategy(string itemName);
    }
}