namespace WebApplication1;

public class PortfolioDto
{
    public Guid Id { get; set; }
    public long UserId { get; set; }
    public decimal Balance { get; set; }
    public IEnumerable<CryptocurrencyDto> Cryptocurrencies { get; set; }
}