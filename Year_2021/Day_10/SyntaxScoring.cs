namespace AdventOfCode.Year_2021.Day_10;

public static class SyntaxScoring
{
    public static (int Points, List<int> IllegalLines) CheckNavigationSubsystemForIllegalCharacters(List<string> inputs)
    {
        var navigationSubsystem = new Stack<char>();
        var illegalCharacters = new List<char>();
        var illegalLines = new List<int>();
        char expectedCharacter;
        var row = 0;

        foreach(var input in inputs)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] is '(' or'[' or '{' or '<')
                {
                    navigationSubsystem.Push(input[i]);
                    continue;
                }

                expectedCharacter = navigationSubsystem.Peek() switch
                {
                    '(' => ')',
                    '[' => ']',
                    '{' => '}',
                    '<' => '>',
                    _ => throw new Exception("Unexpected character")
                };
                
                if(input[i] == expectedCharacter)
                {
                    navigationSubsystem.Pop();
                }
                else
                {
                    illegalCharacters.Add(input[i]);
                    illegalLines.Add(row);
                    //Console.WriteLine($"Illegal character: {input[i]} found in row {row}");
                    break;
                }
            }
            row++;
        }

        return (CalculateSumOfIlegal(illegalCharacters), illegalLines);
    }

    public static long CheckNavigationSubsystemForMissingCharacters(List<string> inputs, List<int> illegalLines)
    {
        var navigationSubsystem = new Stack<char>();
        var excpectedCharacters = new List<char>();
        char expectedCharacter;
        var row = 0;
        var result = new List<long>();

        foreach (var input in inputs)
        {
            if(!illegalLines.Contains(row)) 
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if(input[i] is '(' or'[' or '{' or '<')
                    {
                        navigationSubsystem.Push(input[i]);
                        continue;
                    }

                    expectedCharacter = navigationSubsystem.Peek() switch
                    {
                        '(' => ')',
                        '[' => ']',
                        '{' => '}',
                        '<' => '>',
                        _ => throw new Exception("Unexpected character")
                    };
                    
                    if(input[i] == expectedCharacter)
                    {
                        navigationSubsystem.Pop();
                    }
                }
            }
            if(CalculateSumOfMissing(navigationSubsystem) > 0)
            {
                result.Add(CalculateSumOfMissing(navigationSubsystem));
                //Console.WriteLine($"Row {row}. Itemnumber: {result.Count}. Result: {result.LastOrDefault()}");
            }

            row++;
            navigationSubsystem.Clear();
            
        }

        var sortedResult = new List<long>();
        sortedResult = result.OrderBy(x => x).ToList();

        return sortedResult[sortedResult.Count / 2];
    }

    private static int CalculateSumOfIlegal(List<char> inputs)
    {
        var result = 0;

        inputs.ToList().ForEach(x => {
            result += x switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                _ => 0
            };
        });

        return result;
    }

    private static long CalculateSumOfMissing(Stack<char> inputs)
    {
        long result = 0;

        inputs.ToList().ForEach(x => {
            result = x switch
            {
                '(' => result * 5 + 1,
                '[' => result * 5 + 2,
                '{' => result * 5 + 3,
                '<' => result * 5 + 4,
                _ => 0
            };
        });

        return result;
    }
}
