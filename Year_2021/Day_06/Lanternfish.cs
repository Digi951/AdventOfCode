namespace AdventOfCode.Year_2021.Day_06;

public static class Lanternfish
{
    public static void Calculate(List<string> inputs)
    {
        var lanternfishs = new List<int>();

        inputs.ToList().ForEach(input => lanternfishs.Add(int.Parse(input)));

        var index = 0;

        while(index < 256)
        {
            for (int j = 0; j < lanternfishs.Count; j++)
            {
                if(lanternfishs[j] > 0)
                {
                    lanternfishs[j] -= 1;
                }
                else
                {
                    lanternfishs[j] = 6;
                    lanternfishs.Add(9);
                }

                if(index == 256)
                {
                    break;
                }
            }

            index++;
        } 
        Console.WriteLine($" Anzahl der Fische: {lanternfishs.Count}");
    }
}
