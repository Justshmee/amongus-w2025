namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a single word in the scripture.
    /// Contains the word text and whether it is hidden.
    /// </summary>
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        // Hide the word.
        public void Hide()
        {
            IsHidden = true;
        }

        // Return the word's display text (either the word or underscores)
        public string GetDisplayText()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }
}
