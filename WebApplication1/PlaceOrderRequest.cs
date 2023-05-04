namespace WebApplication1;

public class PlaceOrderRequest
{
    public long UserId { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public OrderType OrderType { get; set; } 
}