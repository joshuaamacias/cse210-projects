class Program
{
    public static int UserScore = 0;
    public static List<Goal> Goals = new List<Goal>();

    static void Main(string[] args)
    {
        LoadGoals();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine($"Current Score: {UserScore}");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal");
        Console.WriteLine("5. Negative Goal");
        Console.Write("Choose an option: ");
        string type = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Enter points for completion: ");
                int simplePoints = int.Parse(Console.ReadLine());
                Goals.Add(new SimpleGoal(name, simplePoints));
                break;
            case "2":
                Console.Write("Enter points for each occurrence: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                Goals.Add(new EternalGoal(name, eternalPoints));
                break;
            case "3":
                Console.Write("Enter points for each occurrence: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completion: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                Goals.Add(new ChecklistGoal(name, checklistPoints, targetCount, bonusPoints));
                break;
            case "4":
                Console.Write("Enter target value: ");
                int targetValue = int.Parse(Console.ReadLine());
                Console.Write("Enter points for completion: ");
                int progressPoints = int.Parse(Console.ReadLine());
                Goals.Add(new ProgressGoal(name, targetValue, progressPoints));
                break;
            case "5":
                Console.Write("Enter points to be deducted: ");
                int negativePoints = int.Parse(Console.ReadLine());
                Goals.Add(new NegativeGoal(name, negativePoints));
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Enter the goal number to record an event: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < Goals.Count)
        {
            Goals[goalIndex].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please try again.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].Name} - {Goals[i].GetStatus()}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(UserScore);
            foreach (Goal goal in Goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}|{goal.IsCompleted}|{(goal is ChecklistGoal checklistGoal ? $"{checklistGoal.CurrentCount}|{checklistGoal.TargetCount}|{checklistGoal.BonusPoints}" : goal is ProgressGoal progressGoal ? $"{progressGoal.CurrentValue}|{progressGoal.TargetValue}" : "")}");
            }
        }
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                UserScore = int.Parse(reader.ReadLine());
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    int points = int.Parse(parts[2]);
                    bool isCompleted = bool.Parse(parts[3]);

                    switch (type)
                    {
                        case nameof(SimpleGoal):
                            Goals.Add(new SimpleGoal(name, points) { IsCompleted = isCompleted });
                            break;
                        case nameof(EternalGoal):
                            Goals.Add(new EternalGoal(name, points));
                            break;
                        case nameof(ChecklistGoal):
                            int currentCount = int.Parse(parts[4]);
                            int targetCount = int.Parse(parts[5]);
                            int bonusPoints = int.Parse(parts[6]);
                            Goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints) { CurrentCount = currentCount, IsCompleted = isCompleted });
                            break;
                        case nameof(ProgressGoal):
                            int currentValue = int.Parse(parts[4]);
                            int targetValue = int.Parse(parts[5]);
                            Goals.Add(new ProgressGoal(name, targetValue, points) { CurrentValue = currentValue, IsCompleted = isCompleted });
                            break;
                        case nameof(NegativeGoal):
                            Goals.Add(new NegativeGoal(name, points) { IsCompleted = isCompleted });
                            break;
                    }
                }
            }
        }
    }
}