public class ATM : IATMOperations
{
    private Bank _bank;

    public ATM(Bank bank)
    {
        _bank = bank;
    }

    public void ExecuteTransaction(Transaction transaction)
    {
        transaction.Execute();
    }

    public Account GetAccount(int accountNumber)
    {
        return _bank.GetAccount(accountNumber);
    }
}
