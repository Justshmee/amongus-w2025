using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override int RecordEvent()
        {
            return Points;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{Name},{Description},{Points}";
        }

        public override void LoadData(string data)
        {
            string[] parts = data.Split(',');
            if (parts.Length == 3)
            {
                Name = parts[0];
                Description = parts[1];
                Points = int.Parse(parts[2]);
            }
        }

        public override string ToString()
        {
            return $"[∞] {Name} ({Description})";
        }
    }
}
