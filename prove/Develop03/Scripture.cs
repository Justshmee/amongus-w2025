using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture consisting of a reference and the text (split into words).
    /// Contains methods to hide words and display the scripture.
    /// </summary>
    public class Scripture
    {
        public Reference Reference { get; private set; }
        private List<Word> Words { get; set; }
        private Random rand;

        // Constructor takes a reference and the full text of the scripture.
        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            // Split the text into words, preserving punctuation attached to words.
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
            rand = new Random();
        }

        /// <summary>
        /// Hides a specified number of random words in the scripture.
        /// For the core requirements, words may be chosen even if already hidden.
        /// </summary>
        /// <param name="count">The number of words to attempt to hide.</param>
        public void HideWords(int count)
        {
            int wordsCount = Words.Count;
            if (wordsCount == 0) return;

            // Attempt to hide 'count' words.
            for (int i = 0; i < count; i++)
            {
                int index = rand.Next(wordsCount);
                Words[index].Hide();
            }
        }

        /// <summary>
        /// Checks if all words in the scripture are hidden.
        /// </summary>
        public bool IsCompletelyHidden()
        {
            return Words.All(w => w.IsHidden);
        }

        /// <summary>
        /// Returns the scripture text with hidden words replaced by underscores.
        /// The reference is included at the top.
        /// </summary>
        public string GetDisplayText()
        {
            string displayedText = string.Join(" ", Words.Select(w => w.GetDisplayText()));
            return $"{Reference}\n{displayedText}";
        }
    }
}
