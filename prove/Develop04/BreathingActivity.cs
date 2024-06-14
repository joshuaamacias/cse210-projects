public class BreathingActivity : BaseActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity(int duration)
    {
        int inhaleTime = 4; // 4 seconds to breath in
        int exhaleTime = 5; // 5 seconds to breath out
        int cycles = duration / (inhaleTime + exhaleTime);

        for (int i = 0; i < cycles; i++)
        {
            PauseWithCountdown("Breathe in...", inhaleTime); // Usar countdown para inhalar
            PauseWithCountdown("Now breathe out...", exhaleTime); // Usar countdown para exhalar
            Console.WriteLine(" ");
        }
    }
}
