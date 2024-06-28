class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Program.UserScore += Points;
    }

    public override string GetStatus()
    {
        return "[∞]";
    }
}