using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private List<string> prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", 
            "This activity will help you reflect on the good things in your life by having you list as many items as you can in a certain area.")
        {
        }

        public override void Run()
        {
            DisplayStartMessage();
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("You will have a few seconds to think before you start listing your items.");
            PauseWithSpinner(3);
            Console.WriteLine("Start listing your items. Press Enter after each item.");

            DateTime endTime = DateTime.Now.AddSeconds(duration);
            int count = 0;
            List<string> items = new List<string>();
            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        items.Add(input);
                        count++;
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine($"\nYou listed {count} items.");
            DisplayEndMessage();
        }
    }
}
