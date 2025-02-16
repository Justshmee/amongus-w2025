namespace ScriptureMemorizer
{
    public class Scripture
    {
        public Reference Reference { get; private set; }
        private List<Word> Words { get; set; }
        private Random rand;

        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
            rand = new Random();
        }

        public void HideWords(int count)
        {
            int wordsCount = Words.Count;
            if (wordsCount == 0) return;

            for (int i = 0; i < count; i++)
            {
                int index = rand.Next(wordsCount);
                Words[index].Hide();
            }
        }

        public bool IsCompletelyHidden()
        {
            return Words.All(w => w.IsHidden);
        }

        public string GetDisplayText()
        {
            string displayedText = string.Join(" ", Words.Select(w => w.GetDisplayText()));
            return $"{Reference}\n{displayedText}";
        }
    }
}
