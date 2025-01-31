using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptManager promptManager = new PromptManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nJournal App");
                Console.WriteLine("1. Write a New Entry");
                Console.WriteLine("2. Display All Entries");
                Console.WriteLine("3. Save Journal to File");
                Console.WriteLine("4. Load Journal from File");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = promptManager.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        journal.AddEntry(new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd")));
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Enter file name to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        break;
                    case "4":
                        Console.Write("Enter file name to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
