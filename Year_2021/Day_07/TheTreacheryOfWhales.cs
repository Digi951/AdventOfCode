namespace AdventOfCode.Year_2021.Day_07;

public class TheTreacheryOfWhales
{
    private static int counter = 0;
    private static int lowestCounter = int.MaxValue;

    public static void CountFuel(List<string> positions)
    {
        for (int i = 1; i <= positions.Count; i++)
        { 
            positions.ToList().ForEach(x =>
            {
                counter += Math.Abs(int.Parse(x) - i);
            });

            Console.WriteLine($"Fuel to position {i} = {counter}");
            lowestCounter = counter < lowestCounter ? counter : lowestCounter;
            counter = 0;
        }
        Console.WriteLine($"Lowest counter: {lowestCounter}");
    }

    public static void CountFuelPart2(List<string> positions)
    {
        for (int i = 1; i <= positions.Count; i++)
        { 
            positions.ToList().ForEach(x =>
            {
                var gap = Math.Abs(int.Parse(x) - i);
                counter += gap * (gap + 1) / 2;
            });

            Console.WriteLine($"Fuel to position {i} = {counter}");
            lowestCounter = counter < lowestCounter ? counter : lowestCounter;
            counter = 0;
        }
        Console.WriteLine($"Lowest counter: {lowestCounter}");
    }
}