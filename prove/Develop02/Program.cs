using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a PromptGenerator
        PromptGenerator promptGenerator = new PromptGenerator();

        // Generate a prompt
        string prompt = promptGenerator.GeneratePrompt();

        // Display the prompt
        Console.WriteLine("Prompt: " + prompt);

        // Create a new journal
        Journal journal = new Journal();

        // Create a new entry
        Entry entry1 = new Entry
        {
            Date = DateTime.Now,
            Content = "Today was a good day."
        };

        // Add the entry to the journal
        journal.AddEntry(entry1);

        // Create another entry
        Entry entry2 = new Entry
        {
            Date = DateTime.Now.AddDays(-1),
            Content = "Yesterday was rainy."
        };

        // Add the entry to the journal
        journal.AddEntry(entry2);

        // Display all entries in the journal
        Console.WriteLine("\nEntries in the journal:");
        foreach (Entry entry in journal.GetEntries())
        {
            Console.WriteLine($"Date: {entry.Date}, Content: {entry.Content}");
        }
    }
}
