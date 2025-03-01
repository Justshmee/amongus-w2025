using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ReflectionActivity : Activity
    {
        private List<string> prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection Activity", 
            "This activity will help you reflect on times in your life when you have shown strength and resilience. Recognize your power and how you can use it in other areas of your life.")
        {
        }

        public override void Run()
        {
            DisplayStartMessage();
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("Now, ponder on each of the following questions related to this experience:");
            
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                string question = questions[rand.Next(questions.Count)];
                Console.WriteLine($"\n>> {question}");
                PauseWithSpinner(5);  
            }
            DisplayEndMessage();
        }
    }
}
