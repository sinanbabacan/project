
namespace WebApplication1;

public static class Calculator
{
    private static readonly Dictionary<Currency, decimal> List = new(new[]
    {
        new KeyValuePair<Currency, decimal>(Currency.Btc, 7000),
        new KeyValuePair<Currency, decimal>(Currency.Eth, 1000),
    });

    public static decimal Calculate(Currency currency, decimal amount)
    {
        return List[currency] * amount;
    }
}

