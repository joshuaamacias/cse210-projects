public class Customer
{
    public string Name ;
    public string Username ;
    public string Password ;
    public Account Account ;

    public Customer(string name, string username, string password, Account account)
    {
        Name = name;
        Username = username;
        Password = password;
        Account = account;
    }

    public bool ValidateCredentials(string username, string password)
    {
        return Username == username && Password == password;
    }
}
