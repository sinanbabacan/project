namespace WebApplication1;

public class Ledger
{
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public LedgerType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public Currency? Currency { get; set; }
    public decimal RemainingBalance { get; set; }
    public decimal? Price { get; set; }
    public string? Address { get; set; }
}