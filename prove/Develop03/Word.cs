class Word
{
    private string Text ;
    private bool Hidden ;

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

    public bool IsHidden()
    {
        return Hidden;
    }
}