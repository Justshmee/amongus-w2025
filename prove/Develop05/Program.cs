using System;

namespace EternalQuest
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalScore = 0;
        static string saveFile = "goals.txt";

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Show Score");
                Console.WriteLine("7. Exit");
                Console.Write("Select a choice from the menu: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        Console.WriteLine($"Your current score is: {totalScore}");
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("\nSelect Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points for goal: ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;
            switch (typeChoice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter target count for checklist: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points for completion: ");
                    int bonus = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }

            goals.Add(newGoal);
            Console.WriteLine("Goal added successfully!");
        }

        static void ListGoals()
        {
            Console.WriteLine("\nYour Goals:");
            int count = 1;
            foreach (var goal in goals)
            {
                Console.WriteLine($"{count}. {goal}");
                count++;
            }
        }

        static void RecordEvent()
        {
            Console.WriteLine("\nSelect a goal to record an event for:");
            int count = 1;
            foreach (var goal in goals)
            {
                Console.WriteLine($"{count}. {goal}");
                count++;
            }
            Console.Write("Enter goal number: ");
            int goalNumber = int.Parse(Console.ReadLine());
            if (goalNumber > 0 && goalNumber <= goals.Count)
            {
                int earned = goals[goalNumber - 1].RecordEvent();
                totalScore += earned;
                Console.WriteLine($"Event recorded! You earned {earned} points.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        static void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter(saveFile))
            {
                writer.WriteLine(totalScore);
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }

        static void LoadGoals()
        {
            if (!File.Exists(saveFile))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            goals.Clear();
            string[] lines = File.ReadAllLines(saveFile);
            if (lines.Length > 0)
            {
                totalScore = int.Parse(lines[0]);
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    // Format: "GoalType:Data"
                    string[] parts = line.Split(':', 2);
                    if (parts.Length < 2) continue;
                    string type = parts[0];
                    string data = parts[1];

                    Goal loadedGoal = null;
                    switch (type)
                    {
                        case "SimpleGoal":
                            loadedGoal = new SimpleGoal("", "", 0);
                            break;
                        case "EternalGoal":
                            loadedGoal = new EternalGoal("", "", 0);
                            break;
                        case "ChecklistGoal":
                            loadedGoal = new ChecklistGoal("", "", 0, 0, 0);
                            break;
                    }
                    if (loadedGoal != null)
                    {
                        loadedGoal.LoadData(data);
                        goals.Add(loadedGoal);
                    }
                }
                Console.WriteLine("Goals loaded successfully!");
            }
        }
    }
}
