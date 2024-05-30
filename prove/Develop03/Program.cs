
class Program
{
    static void Main(string[] args)
    {
        // Create a reference to the scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // The text of the scripture
        string text = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

        // Create a Scripture object with the reference and text
        Scripture scripture = new Scripture(reference, text);

        // Prompt the user for the number of words to hide each time
        Console.WriteLine("Enter the number of words to hide each time: ");
        if (int.TryParse(Console.ReadLine(), out int wordsToHide) && wordsToHide > 0)
        {
            // Create the Program instance and run it with the user-specified number of words to hide
            Program program = new Program(scripture);
            program.Run(wordsToHide);
        }
        else
        {
            // Inform the user of invalid input
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    private Scripture _scripture;

    // Constructor to initialize the Program with a Scripture object
    public Program(Scripture scripture)
    {
        _scripture = scripture;
    }

    // Run method that accepts the number of words to hide each time
    public void Run(int wordsToHide)
    {
        // Clear the console and display the scripture
        ClearConsole();
        Console.WriteLine(_scripture);

        // Loop until all words are hidden
        while (!_scripture.AllWordsHidden())
        {
            // Prompt the user to press Enter to hide words or type 'quit' to exit
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit: ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }

            // Hide the specified number of random words
            _scripture.HideRandomWords(wordsToHide);

            // Clear the console and display the updated scripture
            ClearConsole();
            Console.WriteLine(_scripture);
        }

        // Inform the user that the program has ended
        Console.WriteLine("\nProgram has ended.");
    }

    // Method to clear the console
    private void ClearConsole()
    {
        Console.Clear();
    }
}