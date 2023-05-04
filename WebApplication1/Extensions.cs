using System.Globalization;

namespace WebApplication1;

public static class Extensions
{
    private static LedgerDto ToDto(this Ledger ledger)
    {
        return new LedgerDto
        {
            WalletId = ledger.WalletId,
            Amount = ledger.Amount,
            Type = Enum.GetName(ledger.Type)!,
            CreatedAt = ledger.CreatedAt.ToString(CultureInfo.InvariantCulture),
            Currency = ledger.Currency == null ? string.Empty : Enum.GetName(ledger.Currency.Value)!,
            RemainingBalance = ledger.RemainingBalance,
            Price = ledger.Price,
            Address = ledger.Address
        };
    }
    
    public static IEnumerable<LedgerDto> ToDto(this IEnumerable<Ledger> ledgers)
    {
        foreach (Ledger ledger in ledgers)
        {
            yield return ledger.ToDto();
        }
    }

    public static PortfolioDto ToDto(this Wallet wallet)
    {
        return new PortfolioDto
        {
            Id = wallet.Id,
            UserId = wallet.UserId,
            Balance = wallet.Balance,
            Cryptocurrencies = wallet.Cryptocurrencies.ToDto()
        };
    }

    private static CryptocurrencyDto ToDto(this Cryptocurrency cryptocurrency)
    {
        return new CryptocurrencyDto
        {
            Address = cryptocurrency.Address,
            Currency = Enum.GetName(cryptocurrency.Currency)!,
            Amount = cryptocurrency.Amount
        };
    }
    
    public static IEnumerable<CryptocurrencyDto> ToDto(this IEnumerable<Cryptocurrency> cryptocurrencies)
    {
        foreach (Cryptocurrency cryptocurrency in cryptocurrencies)
        {
            yield return cryptocurrency.ToDto();
        }
    }
}