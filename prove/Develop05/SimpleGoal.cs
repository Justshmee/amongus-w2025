using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override int RecordEvent()
        {
            if (!Completed)
            {
                Completed = true;
                return Points;
            }
            else
            {
                Console.WriteLine("Goal already completed.");
                return 0;
            }
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{Name},{Description},{Points},{Completed}";
        }

        public override void LoadData(string data)
        {
            string[] parts = data.Split(',');
            if (parts.Length == 4)
            {
                Name = parts[0];
                Description = parts[1];
                Points = int.Parse(parts[2]);
                Completed = bool.Parse(parts[3]);
            }
        }
    }
}
