namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture reference.
    /// Supports both single verse and verse ranges.
    /// </summary>
    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        // Constructor for a single verse reference (e.g., "1 Nephi 2:15")
        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        // Constructor for a verse range reference (e.g., "Proverbs 3:5-6")
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (EndVerse.HasValue)
            {
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
            }
            else
            {
                return $"{Book} {Chapter}:{StartVerse}";
            }
        }
    }
}
