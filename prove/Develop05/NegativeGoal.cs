class NegativeGoal : Goal
{
    public NegativeGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Program.UserScore -= Points;
        IsCompleted = true;
    }

    public override string GetStatus()
    {
        return "[Negative]";
    }
}