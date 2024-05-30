class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    // Constructor to initialize the Reference with book, chapter, and verse range
    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    // Override ToString to display the reference in a readable format
    public override string ToString()
    {
        if (VerseEnd.HasValue)
        {
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        }
        else
        {
            return $"{Book} {Chapter}:{VerseStart}";
        }
    }
}
