namespace WebApplication1;

public class LedgerDto
{
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string CreatedAt { get; set; }
    public string Currency { get; set; }
    public decimal RemainingBalance { get; set; }
    public decimal? Price { get; set; }
    
    public string? Address { get; set; }
}