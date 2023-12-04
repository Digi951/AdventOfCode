using System.Text.RegularExpressions;

namespace AdventOfCode.Year_2023.Day_01;

public static class Trebuchet
{
    public static Int32 Calculate(List<String> lines)
    {
        Int32 result = 0;

        foreach (var line in lines) 
        {
            var numbers = line.Where(char.IsDigit).ToList();
            
            var firstNumber = numbers.First();
            var secondNumber = numbers.Last();
            
            result += Convert.ToInt32($"{firstNumber.ToString()}{secondNumber.ToString()}") ;
        }
        
        return result;
    }

    public static Int32 CalculatePartTwo(List<String> lines)
    {
        Int32 result = 0;
        
        var allDigits = new Dictionary<String, Int32>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        for (Int32 i = 1; i < 10; i++)
        {
            allDigits.Add(i.ToString(), i);
        }

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            var firstIndex = line.Length;
            var lastIndex = -1;
            var firstValue = 0;
            var lastValue = 0;

            foreach (var digit in allDigits)
            {
                var index = line.IndexOf(digit.Key);
                if (index == -1)
                {
                    continue;
                }

                if (index < firstIndex)
                {
                    firstIndex = index;
                    firstValue = digit.Value;
                }

                index = line.LastIndexOf(digit.Key);

                if (index > lastIndex)
                {
                    lastIndex = index;
                    lastValue = digit.Value;
                }
            }

            var combinedNumber = firstValue * 10 + lastValue;
            result += combinedNumber;
            Console.WriteLine($"Line {i}: {line} -> {combinedNumber}");
        }

        return result;
    }

    public static Int32 CalculatePartTwoFailure(List<String> lines)
    {
        Int32 result = 0;

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            List<int> extractedDigits = new List<int>();
            var matches = Regex.Matches(line, @"([1-9]|(?<=(one))|(?<=(two))|(?<=(three))|(?<=(four))|(?<=(five))|(?<=(six))|(?<=(seven))|(?<=(eight))|(?<=(nine)))");

            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    extractedDigits.AddRange(match.Groups[1].Value
                        .Select(digitChar => Int32.Parse(digitChar.ToString())));
                }
                else
                {
                    for (int j = 2; j <= 11; j++)
                    {
                        if (match.Groups[j].Success)
                        {
                            String word = match.Groups[j].Value.ToLower();
                            Int32 number = GetNumberFromWord(word);
                            extractedDigits.Add(number);
                        }
                    }
                }
            }

            Int32 firstNumber = extractedDigits.First();
            Int32 secondNumber = extractedDigits.Last();
            Int32 combinedNumber = firstNumber * 10 + secondNumber;
            result += combinedNumber;
            Console.WriteLine($"Line {i}: {line} -> {combinedNumber}");
        }

        return result;
    }
    
    static int GetNumberFromWord(string word)
    {
        return word switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => 0
        };
    }
}