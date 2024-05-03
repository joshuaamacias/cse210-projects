using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int>();
        
        int userNumber;
        do
        {
            Console.Write("Enter a number (0 to quit): ");
            userNumber = int.Parse(Console.ReadLine());
            
            if (userNumber != 0)
                numbers.Add(userNumber);
            
        } while (userNumber != 0);

        // Part 1: Compute the sum
        int sum = 0;
        foreach (var number in numbers)
            sum += number;

        Console.WriteLine($"The sum is: {sum}");

        // Part 2: Compute the average
        float average = sum / (float)numbers.Count;
        string average_formatted = average.ToString("F2");
        Console.WriteLine($"The average is: {average_formatted}");

        // Part 3: Find the max
        int max = int.MinValue;
        foreach (var number in numbers)
        {
            if (number > max)
                max = number;
        }

        Console.WriteLine($"The max is: {max}");
    }
}
