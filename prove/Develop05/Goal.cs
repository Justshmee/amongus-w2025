using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool Completed { get; protected set; }

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            Completed = false;
        }

        public abstract int RecordEvent();

        public abstract string GetStringRepresentation();

        public abstract void LoadData(string data);

        public override string ToString()
        {
            return $"{(Completed ? "[X]" : "[ ]")} {Name} ({Description})";
        }
    }
}
