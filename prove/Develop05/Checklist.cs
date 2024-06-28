class ChecklistGoal : Goal
{
    public int TargetCount ;
    public int CurrentCount ;
    public int BonusPoints ;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) 
        : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            Program.UserScore += Points;
            if (CurrentCount == TargetCount)
            {
                Program.UserScore += BonusPoints;
                IsCompleted = true;
            }
        }
    }

    public override string GetStatus()
    {
        return $"Completed {CurrentCount}/{TargetCount} times";
    }
}