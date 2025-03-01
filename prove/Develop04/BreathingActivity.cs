using System;

namespace MindfulnessApp
{
    // Breathing Activity
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", 
            "This activity will help you relax by guiding your breathing. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            DisplayStartMessage();

            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in... ");
                Countdown(4); // Adjust duration per breath cycle as needed
                Console.WriteLine();
                Console.Write("Breathe out... ");
                Countdown(6); // Adjust duration per breath cycle as needed
                Console.WriteLine("\n");
            }
            DisplayEndMessage();
        }
    }
}
