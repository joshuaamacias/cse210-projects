using System;
using System.Linq;

class Program
{
    private static readonly string DataFilePath = "bankData.txt";

    static void Main(string[] args)
    {
        Bank bank = new Bank();
        ATM atm = new ATM(bank);

        bank.LoadData(DataFilePath);

        Admin admin = new Admin("admin", "password");
        // Existing customer for demonstration
        if (!bank.UsernameExists("john_doe"))
        {
            Account existingAccount = new Account(12345, 500.00m);
            Customer existingCustomer = new Customer("John Doe", "john_doe", "securepassword", existingAccount);
            bank.AddCustomer(existingCustomer);
            bank.AddAccount(existingAccount);
        }

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");
            Console.Write("Please choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Customer loggedInCustomer = HandleLogin(bank);
                    if (loggedInCustomer != null)
                    {
                        ShowATMMenu(atm, loggedInCustomer);
                    }
                    break;
                case "2":
                    HandleSignUp(bank);
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        bank.SaveData(DataFilePath);
    }

    static Customer HandleLogin(Bank bank)
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Customer customer = bank.GetCustomerByUsername(username);
        if (customer != null && customer.ValidateCredentials(username, password))
        {
            Console.WriteLine("Login successful.");
            return customer;
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
            return null;
        }
    }

    static void HandleSignUp(Bank bank)
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        string username;
        do
        {
            Console.Write("Enter a username: ");
            username = Console.ReadLine();
            if (bank.UsernameExists(username))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
            }
        } while (bank.UsernameExists(username));

        Console.Write("Enter a password: ");
        string password = Console.ReadLine();
        Account newAccount = new Account(bank.GetNextAccountNumber(), 10.00m);
        Customer newCustomer = new Customer(name, username, password, newAccount);

        bank.AddCustomer(newCustomer);
        bank.AddAccount(newAccount);

        Console.WriteLine("Sign-up successful. Your account has been created with an initial balance of $10.");
    }

    static void ShowATMMenu(ATM atm, Customer loggedInCustomer)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Logout");
            Console.Write("Please choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleDeposit(atm, loggedInCustomer.Account);
                    break;
                case "2":
                    HandleWithdrawal(atm, loggedInCustomer.Account);
                    break;
                case "3":
                    HandleCheckBalance(loggedInCustomer.Account);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void HandleDeposit(ATM atm, Account account)
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount;
        if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
        {
            Transaction deposit = new Deposit(account, amount);
            atm.ExecuteTransaction(deposit);
            Console.WriteLine("Deposit successful.");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void HandleWithdrawal(ATM atm, Account account)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount;
        if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
        {
            try
            {
                Transaction withdrawal = new Withdrawal(account, amount);
                atm.ExecuteTransaction(withdrawal);
                Console.WriteLine("Withdrawal successful.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void HandleCheckBalance(Account account)
    {
        Console.WriteLine($"Your balance is: {account.Balance:C}");
    }
}
