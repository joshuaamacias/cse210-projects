public abstract class BaseActivity
{
    protected string Name;
    protected string Description;

    public void Start(int duration)
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name} Activity.");
        Console.WriteLine("");
        Console.WriteLine(Description);
        Console.WriteLine("");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("");
        Console.WriteLine("Prepare to begin...");
        Pause(5); // Use PauseWithSpin for "Prepare to begin"
        Console.Clear();

        
        RunActivity(duration);

        Console.WriteLine("Well done!!");
        Pause(3);
        Console.WriteLine($"You have completed the {Name} Activity for {duration} seconds.");
    }

    protected abstract void RunActivity(int duration);

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            int delay = 250;
            Console.Write("|\b");
            Thread.Sleep(delay);
            Console.Write("\\\b");
            Thread.Sleep(delay);
            Console.Write("-\b");
            Thread.Sleep(delay);
            Console.Write("/\b");
            Thread.Sleep(delay);
            Console.Write("|\b");
            Thread.Sleep(delay);
            Console.Write("|\b");
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    protected void PauseWithCountdown(string message, int seconds)
{
    Console.Write(message);
    for (int i = seconds; i > 0; i--)
    {
        Console.Write($" {i}");
        Thread.Sleep(1000); // Esperar 1 segundo
        Console.Write(new string('\b', i.ToString().Length + 1)); // Retroceder el número de caracteres necesarios
    }
    Console.Write(new string(' ', seconds.ToString().Length + 1)); // Limpiar el número 1
    Console.Write(new string('\b', seconds.ToString().Length + 1)); // Retroceder el espacio en blanco
    Console.WriteLine(); // Nueva línea después del countdown
}



}

