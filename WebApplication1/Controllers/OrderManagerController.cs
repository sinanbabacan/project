using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderManagerController : ControllerBase
{
    /*
        Implement a simple data model to represent a user's portfolio, including the cryptocurrencies they own and their quantities

        Implement a basic order management system to place buy/sell orders based on user input.

        Create a simple API that allows users to interact with the trading app. The API should support the following commands:

        view_portfolio: Displays the user's portfolio, including the cryptocurrencies and their quantities.
        place_order: Places a buy or sell order for a specified cryptocurrency and quantity.
        view_transactions: Displays the user's transaction history, including buy and sell orders.

        Write a simple test suite that demonstrates the following scenarios:

        Creating a new user portfolio.
        Placing buy and sell orders.
        Viewing the user's portfolio and transaction history.
     */


    private readonly IWalletRepository _walletRepository;
    
    public OrderManagerController(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }
    
    [HttpGet("ViewPortfolio")]
    public IActionResult ViewPortfolio(long userId)
    {
        Wallet wallet = _walletRepository.GetByUserId(userId);

        return Ok(wallet.ToDto());
    }

    [HttpPost("PlaceOrder")]
    public IActionResult PlaceOrder(PlaceOrderRequest request)
    {
        Wallet wallet = _walletRepository.GetByUserId(request.UserId);

        if (request.OrderType == OrderType.Buy)
        {
            wallet.Buy(request.Currency, request.Amount);
        }
        else
        {
            wallet.Sell(request.Currency, request.Amount);
        }
        
        return Ok();
    }

    [HttpGet("ViewTransactions")]
    public IActionResult ViewTransactions(long userId)
    {
        Wallet wallet = _walletRepository.GetByUserId(userId);

        var ledgers = wallet.Ledgers.ToDto();

        return Ok(ledgers);
    }

}