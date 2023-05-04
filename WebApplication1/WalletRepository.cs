namespace WebApplication1;

public class WalletRepository : IWalletRepository
{
    private static readonly List<Wallet> Wallets = new();

    static WalletRepository()
    {
        var wallet = new Wallet
        {
            UserId = 1212
        };

        wallet.Deposit(100000);

        Wallets.Add(wallet);
    }
    
    public Wallet GetByUserId(long userId)
    {
        Wallet? wallet = Wallets.SingleOrDefault(q => q.UserId == userId);

        if (wallet == null)
        {
            throw new ApplicationException("The user has not any wallet");
        }

        return wallet;
    }
}

public interface IWalletRepository
{
    Wallet GetByUserId(long userId);
}