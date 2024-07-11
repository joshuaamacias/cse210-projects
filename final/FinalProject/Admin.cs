public class Admin
{
    public string Username ;
    public string Password ;

    public Admin(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public void AddCustomer(Bank bank, Customer customer)
    {
        bank.AddCustomer(customer);
    }

    public void AddAccount(Bank bank, Account account)
    {
        bank.AddAccount(account);
    }
}
