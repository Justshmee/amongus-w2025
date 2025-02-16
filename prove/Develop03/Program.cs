using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Main program to run the Scripture Memorizer.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Scripture: 1 Nephi 2:15 with its text updated.
            // The scripture text is: "15 And my father dwelt in a tent."
            string scriptureText = "And my father dwelt in a tent.";

            // Create the reference (using the single verse constructor)
            Reference reference = new Reference("1 Nephi", 2, 15);

            // Create the scripture object
            Scripture scripture = new Scripture(reference, scriptureText);

            // Number of words to hide at each step.
            int wordsToHidePerStep = 3;

            // Main loop: display scripture, prompt the user, hide words until all are hidden.
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

                // Hide a few random words
                scripture.HideWords(wordsToHidePerStep);

                // If all words are hidden, display final version and exit.
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
