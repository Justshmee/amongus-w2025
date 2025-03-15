using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int CurrentCount { get; set; }
        public int BonusPoints { get; set; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            CurrentCount = 0;
        }

        public override int RecordEvent()
        {
            if (!Completed)
            {
                CurrentCount++;
                int earned = Points;
                if (CurrentCount >= TargetCount)
                {
                    Completed = true;
                    earned += BonusPoints;
                }
                return earned;
            }
            else
            {
                Console.WriteLine("Checklist goal already completed.");
                return 0;
            }
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{Name},{Description},{Points},{TargetCount},{BonusPoints},{CurrentCount},{Completed}";
        }

        public override void LoadData(string data)
        {
            string[] parts = data.Split(',');
            if (parts.Length == 7)
            {
                Name = parts[0];
                Description = parts[1];
                Points = int.Parse(parts[2]);
                TargetCount = int.Parse(parts[3]);
                BonusPoints = int.Parse(parts[4]);
                CurrentCount = int.Parse(parts[5]);
                Completed = bool.Parse(parts[6]);
            }
        }

        public override string ToString()
        {
            return $"{(Completed ? "[X]" : "[ ]")} {Name} ({Description}) -- Completed {CurrentCount}/{TargetCount}";
        }
    }
}
