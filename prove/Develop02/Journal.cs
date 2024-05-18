class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response)
    {
        JournalEntry newEntry = new JournalEntry(prompt, response);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine($"Date: {entry.EntryDate}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                writer.WriteLine(entry.EntryDate);
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Response);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string entryDate = reader.ReadLine();
                string prompt = reader.ReadLine();
                string response = reader.ReadLine();
                JournalEntry newEntry = new JournalEntry(prompt, response);
                entries.Add(newEntry);
            }
        }
    }
}