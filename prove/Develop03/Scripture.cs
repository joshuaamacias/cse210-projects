class Scripture
{
    private Reference Reference ;
    private List<Word> Words ;

    // Constructor to initialize the Scripture with its reference and text
    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Method to hide a specified number of random words
    public void HideRandomWords(int count = 1)
    {
        Random random = new Random();
        var wordsToHide = Words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < count; i++)
        {
            if (wordsToHide.Any())
            {
                Word wordToHide = wordsToHide[random.Next(wordsToHide.Count)];
                wordToHide.Hide();
                wordsToHide.Remove(wordToHide);
            }
        }
    }
 
    // Method to check if all words are hidden
    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden());
    }

    // Override ToString to display the scripture text with hidden words as underscores
    public override string ToString()
    {
        string wordsStr = string.Join(" ", Words);
        return $"{Reference}\n{wordsStr}";
    }
}