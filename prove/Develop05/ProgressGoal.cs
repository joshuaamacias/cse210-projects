class ProgressGoal : Goal
{
    public int TargetValue ;
    public int CurrentValue ;

    public ProgressGoal(string name, int targetValue, int points) : base(name, points)
    {
        TargetValue = targetValue;
        CurrentValue = 0;
    }

    public override void RecordEvent()
    {
        Console.Write("Enter progress made: ");
        int progress = int.Parse(Console.ReadLine());
        CurrentValue += progress;

        if (CurrentValue >= TargetValue)
        {
            IsCompleted = true;
            Program.UserScore += Points;
        }
    }

    public override string GetStatus()
    {
        return $"Progress: {CurrentValue}/{TargetValue}";
    }
}