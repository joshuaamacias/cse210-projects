using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts;

    public PromptGenerator()
    {
        // Initialize prompts
        prompts = new List<string>
        {
            "Write about your favorite childhood memory.",
            "Describe a challenge you overcame recently.",
            "What are you grateful for today?",
            "Write about something that made you smile.",
            "Reflect on a goal you want to achieve."
        };
    }

    public string GeneratePrompt()
    {
        // Generate a random prompt
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
