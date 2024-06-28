abstract class Goal
{
    public string Name ;
    public int Points ;
    public bool IsCompleted ;

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent();

    public abstract string GetStatus();
}