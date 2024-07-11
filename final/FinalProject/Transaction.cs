public abstract class Transaction
{
    protected Account Account;
    protected decimal Amount;

    protected Transaction(Account account, decimal amount)
    {
        Account = account;
        Amount = amount;
    }

    public abstract void Execute();
}
