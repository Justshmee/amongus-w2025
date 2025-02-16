using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string scriptureText = "And my father dwelt in a tent.";

            Reference reference = new Reference("1 Nephi", 2, 15);

            Scripture scripture = new Scripture(reference, scriptureText);

            int wordsToHidePerStep = 3;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                {
                    break;
                }

                scripture.HideWords(wordsToHidePerStep);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words have been hidden. Press any key to exit.");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
