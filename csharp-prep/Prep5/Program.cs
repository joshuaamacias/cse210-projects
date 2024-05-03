using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();

        string userName = GetUserName();
        int userNumber = GetUserNumber();

        int squaredNumber = CalculateSquare(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int GetUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int CalculateSquare(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, your number at the 2 power is {square}");
    }
}
