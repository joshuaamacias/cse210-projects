public class Deposit : Transaction
{
    public Deposit(Account account, decimal amount) : base(account, amount) { }

    public override void Execute()
    {
        Account.Deposit(Amount);
    }
}
