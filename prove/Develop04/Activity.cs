using System;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for common functionality
    public abstract class Activity
    {
        protected int duration; // in seconds
        protected string activityName;
        protected string description;

        public Activity(string name, string desc)
        {
            activityName = name;
            description = desc;
        }

        // Common starting message
        public virtual void DisplayStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {activityName}.");
            Console.WriteLine(description);
            Console.Write("Please enter the duration of the activity in seconds: ");
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Invalid input. Please enter a positive number: ");
            }
            Console.WriteLine("Get ready...");
            PauseWithSpinner(3);
        }

        // Common ending message
        public virtual void DisplayEndMessage()
        {
            Console.WriteLine("\nGood job!");
            PauseWithSpinner(3);
            Console.WriteLine($"You have completed the {activityName} for {duration} seconds.");
            PauseWithSpinner(3);
        }

        // A simple spinner animation
        protected void PauseWithSpinner(int seconds)
        {
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            string spinner = @"-\|/";
            int counter = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[counter % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b");
                counter++;
            }
        }

        // A countdown timer animation (for use in the breathing activity, etc.)
        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                // Erase the number (assuming one digit, adjust if needed)
                Console.Write("\b \b");
            }
        }

        // Each derived class will implement its own Run method.
        public abstract void Run();
    }
}
