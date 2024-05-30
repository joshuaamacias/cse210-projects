class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    // Constructor to initialize the Word with its text
    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        Hidden = true;
    }

    // Override ToString to display the word or underscores if hidden
    public override string ToString()
    {
        return Hidden ? "_____" : Text;
    }
}