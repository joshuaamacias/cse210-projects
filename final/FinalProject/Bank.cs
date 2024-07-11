public class Bank
{
    private List<Account> _accounts;
    private List<Customer> _customers;

    public Bank()
    {
        _accounts = new List<Account>();
        _customers = new List<Customer>();
    }

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public Account GetAccount(int accountNumber)
    {
        return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    }

    public Customer GetCustomerByUsername(string username)
    {
        return _customers.FirstOrDefault(c => c.Username == username);
    }

    public bool UsernameExists(string username)
    {
        return _customers.Any(c => c.Username == username);
    }

    public int GetNextAccountNumber()
    {
        return _accounts.Count + 1;
    }

    public void SaveData(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var customer in _customers)
            {
                writer.WriteLine($"Customer,{customer.Name},{customer.Username},{customer.Password}");
            }
            foreach (var account in _accounts)
            {
                writer.WriteLine($"Account,{account.AccountNumber},{account.Balance}");
            }
        }
    }

    public void LoadData(string filePath)
    {
        _customers.Clear();
        _accounts.Clear();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length > 0)
                {
                    if (parts[0] == "Customer" && parts.Length == 4)
                    {
                        string name = parts[1];
                        string username = parts[2];
                        string password = parts[3];
                        Customer customer = new Customer(name, username, password, null); // Account will be loaded separately
                        _customers.Add(customer);
                    }
                    else if (parts[0] == "Account" && parts.Length == 3)
                    {
                        int accountNumber;
                        decimal balance;
                        if (int.TryParse(parts[1], out accountNumber) && decimal.TryParse(parts[2], out balance))
                        {
                            Account account = new Account(accountNumber, balance);
                            _accounts.Add(account);

                            // Link account to customer (assuming a one-to-one relationship for simplicity)
                            Customer linkedCustomer = _customers.FirstOrDefault(c => c.Account != null && c.Account.AccountNumber == accountNumber);
                            if (linkedCustomer != null)
                            {
                                linkedCustomer.Account = account;
                            }
                        }
                    }
                }
            }
        }
    }
}
