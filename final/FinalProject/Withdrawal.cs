public class Withdrawal : Transaction
{
    public Withdrawal(Account account, decimal amount) : base(account, amount) { }

    public override void Execute()
    {
        Account.Withdraw(Amount);
    }
}
