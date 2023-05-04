namespace WebApplication1;

public class Wallet
{
    private decimal _balance;

    public List<Ledger> Ledgers { get; } = new();

    public Wallet()
    {
        Id = Guid.NewGuid();

        Cryptocurrencies = new List<Cryptocurrency>
        {
            new("BTC01", Currency.Btc, 0),
            new("ETH01", Currency.Eth, 0)
        };
    }

    public Guid Id { get; set; }

    public decimal Balance => _balance;
    public long UserId { get; set; }
    public List<Cryptocurrency> Cryptocurrencies { get; }

    public void Buy(Currency currency, decimal amount)
    {
        decimal calculatedAmount = Calculator.Calculate(currency, amount);

        if (_balance < calculatedAmount)
        {
            throw new ApplicationException($"insufficient balance!");
        }

        Cryptocurrency? cryptocurrency = Cryptocurrencies.SingleOrDefault(q => q.Currency == currency);

        if (cryptocurrency == null)
        {
            throw new ApplicationException($"{currency} balance was not found!");
        }

        cryptocurrency.Amount += amount;
        _balance -= calculatedAmount;

        Ledgers.Add(new Ledger
        {
            WalletId = this.Id,
            Amount = amount,
            Type = LedgerType.Buy,
            CreatedAt = DateTime.UtcNow,
            Currency = currency,
            Address = cryptocurrency.Address,
            RemainingBalance = _balance,
            Price = calculatedAmount / amount
        });
    }

    public void Sell(Currency currency, decimal amount)
    {
        Cryptocurrency? cryptocurrency = Cryptocurrencies.SingleOrDefault(q => q.Currency == currency);

        if (cryptocurrency == null)
        {
            throw new ApplicationException($"{cryptocurrency} was not found!");
        }

        if (amount > cryptocurrency.Amount)
        {
            throw new ApplicationException($"insufficient balance for {currency}!");
        }

        decimal calculatedAmount = Calculator.Calculate(currency, amount);
        cryptocurrency.Amount -= amount;
        _balance += calculatedAmount;

        Ledgers.Add(new Ledger
        {
            WalletId = this.Id,
            Amount = amount,
            Type = LedgerType.Sell,
            CreatedAt = DateTime.UtcNow,
            Currency = currency,
            Address = cryptocurrency.Address,
            RemainingBalance = _balance,
            Price = calculatedAmount / amount
        });
    }

    public void Deposit(decimal amount)
    {
        if (amount >= 0)
        {
            _balance += amount;
            
            Ledgers.Add(new Ledger
            {
                WalletId = this.Id,
                Amount = amount,
                Type = LedgerType.Deposit,
                CreatedAt = DateTime.UtcNow,
                RemainingBalance = _balance,
            });
        }
    }
}