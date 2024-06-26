// I exceeded the requirements by adding more providing more prompts to the user so they can feel more comfortable to write something 
// in their journal.
// Also I was able to save the journal in another file.

using System;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int choice;

        do
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter your response to today's prompt: ");
                    string[] prompts = { "Who was the most interesting person I interacted with today?",
                                         "What was the best part of my day?",
                                         "How did I see the hand of the Lord in my life today?",
                                         "What was the strongest emotion I felt today?",
                                         "If I had one thing I could do over today, what would it be?",
                                         "What is something that you improved from yesterday?",
                                         "Were you able to do some good today? to whom and why?" };
                    
                    
                    string prompt = prompts[new Random().Next(prompts.Length)];
                    Console.WriteLine($"Today's prompt: {prompt}");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response);
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case 4:
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        } while (choice != 5);
    }
}
