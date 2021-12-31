namespace AdventToCode.Year_2021.Day_15;

public static class ExtendedPolymerization
{
    public static void Run(Dictionary<string, string> matchingTable)
    {
        var inputs = "COPBCNPOBKCCFFBSVHKO";
        var result = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            inputs.ToList().ForEach( input => result.Add(input.ToString()));

            for (int j = 0; j < inputs.Length - 1; j++)
            {
                var pair = inputs[j].ToString() + inputs[j + 1].ToString();
                var match = matchingTable[pair];
                result.Insert(j * 2 + 1, match);
            }

            inputs = string.Join("", result);
            result.Clear();
        }

        var chars = new List<char>();

        inputs.ToList().ForEach(i => {if(!chars.Contains(i)) chars.Add(i);});

        var counts = new List<int>();

        chars.ToList().ForEach(c => counts.Add(inputs.Count(x => x == c)));

        Console.WriteLine(counts.Max() - counts.Min());
    }
}