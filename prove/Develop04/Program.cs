class Program
{
    private static Dictionary<string, int> activityLog = new Dictionary<string, int>
    {
        { "Breathing", 0 },
        { "Reflection", 0 },
        { "Listing", 0 }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4)
            {
                if (choice == 4)
                {
                    break;
                }

                Console.Write("How long, in seconds, would you like for your session?  ");
                int duration;
                if (int.TryParse(Console.ReadLine(), out duration))
                {
                    BaseActivity activity;
                    string activityName;
                    switch (choice)
                    {
                        case 1:
                            activity = new BreathingActivity();
                            activityName = "Breathing";
                            break;
                        case 2:
                            activity = new ReflectionActivity();
                            activityName = "Reflection";
                            break;
                        case 3:
                            activity = new ListingActivity();
                            activityName = "Listing";
                            break;
                        default:
                            throw new InvalidOperationException("Invalid choice.");
                    }

                    // Update the log count
                    activityLog[activityName]++;

                    activity.Start(duration);
                }
                else
                {
                    Console.WriteLine("Invalid duration. Please enter a number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a number between 1 and 4.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        // Display the activity log before exiting
        Console.Clear();
        Console.WriteLine("Activity Log:");
        foreach (var entry in activityLog)
        {
            Console.WriteLine($"{entry.Key} Activity: {entry.Value} time(s)");
        }
    }
}

