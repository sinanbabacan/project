namespace WebApplication1;

public class Cryptocurrency
{
    public Cryptocurrency(string address, Currency currency, decimal amount)
    {
        Address = address;
        Currency = currency;
        Amount = amount;
    }

    public string Address { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
}