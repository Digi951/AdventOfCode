using AdventToCode.Extensions;

namespace AdventToCode.Year_2021.Day_01;

public static class SonarSweep
{
    public static int Measure(List<string> input)
    {
        int count = 0;
        int previous = int.Parse(input[0]);

        foreach (int i in 1..input.Count)
        {
            int current = int.Parse(input[i]);
        
            if (current > previous)
            {
                count++;
            }
            previous = current;
        }

        return count;
    }

    public static int MeasureWindow(List<string> input)
    {
        int count = 0;
        int previousSum = int.Parse(input[0]) + int.Parse(input[1]) + int.Parse(input[2]);

        foreach (int i in 3..input.Count)
        {
            int currentSum = int.Parse(input[i - 2]) + int.Parse(input[i - 1]) + int.Parse(input[i]);
            if (currentSum > previousSum)
            {
                count++;
            }
            previousSum = currentSum;
        }

        return count;
    }
}
