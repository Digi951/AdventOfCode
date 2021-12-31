namespace AdventToCode.Year_2021.Day_08;

public static class SevenSegmentSearch
{
    public static void Calculate(List<List<string>> patterns, List<List<string>> digits)
    {
        var count = 0;
        string[] unsortedPatterns = new string[10];

        for (int i = 0; i < patterns.Count; i++)
        {
            unsortedPatterns[1] = patterns[i].Where(x => x.Length == 2).FirstOrDefault();
            unsortedPatterns[4] = patterns[i].Where(x => x.Length == 4).FirstOrDefault();
            unsortedPatterns[7] = patterns[i].Where(x => x.Length == 3).FirstOrDefault();
            unsortedPatterns[8] = patterns[i].Where(x => x.Length == 7).FirstOrDefault();
            unsortedPatterns[3] = patterns[i].Where(x => x.Length == 5 && x.Contains(unsortedPatterns[1][0]) && x.Contains(unsortedPatterns[1][1])).FirstOrDefault();
            unsortedPatterns[6] = patterns[i].Where(x => x.Length == 6 && (x.Contains(unsortedPatterns[1][0]) ^ x.Contains(unsortedPatterns[1][1]))).FirstOrDefault();
            var zeroAndNine = patterns[i].Where(x => x.Length == 6 && (x.Contains(unsortedPatterns[7][0]) && x.Contains(unsortedPatterns[7][1]) && x.Contains(unsortedPatterns[7][2]))).ToList();
            unsortedPatterns[9] = zeroAndNine.Where(x => x.Length == 6 && (x.Contains(unsortedPatterns[3][0]) && x.Contains(unsortedPatterns[3][1]) && x.Contains(unsortedPatterns[3][2]) && x.Contains(unsortedPatterns[3][3]) && x.Contains(unsortedPatterns[3][4]))).FirstOrDefault();
            unsortedPatterns[0] = zeroAndNine.Where(x => x != unsortedPatterns[9]).FirstOrDefault();
            var twoAndFive = patterns[i].Where(x => x.Length == 5 && x != unsortedPatterns[3]).ToList();
            unsortedPatterns[5] = twoAndFive.Where(x => unsortedPatterns[6].Contains(x[0]) && unsortedPatterns[6].Contains(x[1]) && unsortedPatterns[6].Contains(x[2]) && unsortedPatterns[6].Contains(x[3]) && unsortedPatterns[6].Contains(x[4])).FirstOrDefault();
            unsortedPatterns[2] = twoAndFive.Where(x => x != unsortedPatterns[5]).FirstOrDefault();

            var sortedPatterns = new List<string>();        
            unsortedPatterns.ToList().ForEach(x => sortedPatterns.Add(new string(x.ToCharArray().OrderBy(x => x).ToArray())));

            var sortedDigits = new List<string>();
            digits[i].ToList().ForEach(x => sortedDigits.Add(new string(x.ToCharArray().OrderBy(x => x).ToArray())));

            for (int j = 0; j < sortedDigits.Count; j++)
            {
                for (int k = 0; k < sortedPatterns.Count; k++)
                {
                    if(sortedDigits[j] == sortedPatterns[k])
                    {
                        //Console.WriteLine(k);
                        if(k == 1 || k == 4 || k == 7 || k == 8)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(count);
    }

    public static void CalculatePart2(List<List<string>> patterns, List<List<string>> digits)
    {
        var result = 0;
        string[] unsortedPatterns = new string[10];

        for (int i = 0; i < patterns.Count; i++)
        {
            unsortedPatterns[1] = patterns[i].Where(x => x.Length == 2).FirstOrDefault();
            unsortedPatterns[4] = patterns[i].Where(x => x.Length == 4).FirstOrDefault();
            unsortedPatterns[7] = patterns[i].Where(x => x.Length == 3).FirstOrDefault();
            unsortedPatterns[8] = patterns[i].Where(x => x.Length == 7).FirstOrDefault();
            unsortedPatterns[3] = patterns[i].Where(x => x.Length == 5 && x.Contains(unsortedPatterns[1][0]) && x.Contains(unsortedPatterns[1][1])).FirstOrDefault();
            unsortedPatterns[6] = patterns[i].Where(x => x.Length == 6 && (x.Contains(unsortedPatterns[1][0]) ^ x.Contains(unsortedPatterns[1][1]))).FirstOrDefault();
            var zeroAndNine = patterns[i].Where(x => x.Length == 6 && (x.Contains(unsortedPatterns[7][0]) && x.Contains(unsortedPatterns[7][1]) && x.Contains(unsortedPatterns[7][2]))).ToList();
            unsortedPatterns[9] = zeroAndNine.Where(x => x.Length == 6 && (x.Contains(unsortedPatterns[3][0]) && x.Contains(unsortedPatterns[3][1]) && x.Contains(unsortedPatterns[3][2]) && x.Contains(unsortedPatterns[3][3]) && x.Contains(unsortedPatterns[3][4]))).FirstOrDefault();
            unsortedPatterns[0] = zeroAndNine.Where(x => x != unsortedPatterns[9]).FirstOrDefault();
            var twoAndFive = patterns[i].Where(x => x.Length == 5 && x != unsortedPatterns[3]).ToList();
            unsortedPatterns[5] = twoAndFive.Where(x => unsortedPatterns[6].Contains(x[0]) && unsortedPatterns[6].Contains(x[1]) && unsortedPatterns[6].Contains(x[2]) && unsortedPatterns[6].Contains(x[3]) && unsortedPatterns[6].Contains(x[4])).FirstOrDefault();
            unsortedPatterns[2] = twoAndFive.Where(x => x != unsortedPatterns[5]).FirstOrDefault();

            var sortedPatterns = new List<string>();        
            unsortedPatterns.ToList().ForEach(x => sortedPatterns.Add(new string(x.ToCharArray().OrderBy(x => x).ToArray())));

            var sortedDigits = new List<string>();
            digits[i].ToList().ForEach(x => sortedDigits.Add(new string(x.ToCharArray().OrderBy(x => x).ToArray())));
            
            for (int j = 0; j < sortedDigits.Count; j++)
            {
                for (int k = 0; k < sortedPatterns.Count; k++)
                {
                    if(sortedDigits[j] == sortedPatterns[k])
                    {
                        if(j == 0) result += k * 1000;
                        if(j == 1) result += k * 100;
                        if(j == 2) result += k * 10;
                        if(j == 3) result += k * 1;
                    }
                }
            }
        }

        Console.WriteLine(result);
    }
}
