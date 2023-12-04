using System.Text.RegularExpressions;

namespace AdventOfCode.Year_2023.Day_02;

public static class CubeConundrum
{
    public static Int32 Calculate(List<String> lines)
    {
        const Int32 START_VALUE_BLUE = 14;
        const Int32 START_VALUE_GREEN = 13;
        const Int32 START_VALUE_RED = 12;
        
        Int32 result = 0;

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            var lineFraction = line.Split(':')[1];
            var sets = lineFraction.Split(';');

            Boolean gameIsPossible = true;

            foreach (var set in sets)
            {
                if (!gameIsPossible)
                {
                    break;
                }
                
                var cubes = set.Split(',');
                Regex regEx = new(@"\d{1,}");

                for (int j = 0; j < cubes.Length; j++)
                {
                    Match match = regEx.Match(cubes[j]);
                    if (cubes[j].Contains("blue", StringComparison.OrdinalIgnoreCase))
                    {
                        Int32 takenBlueCubes = Int32.Parse(match.Value);
                        if (takenBlueCubes > START_VALUE_BLUE)
                        {
                            gameIsPossible = false;
                            break;
                        }
                    }
                    else if (cubes[j].Contains("green", StringComparison.OrdinalIgnoreCase))
                    {
                        Int32 takenGreenCubes = Int32.Parse(match.Value);
                        if (takenGreenCubes > START_VALUE_GREEN)
                        {
                            gameIsPossible = false;
                            break;
                        }
                    }
                    else if (cubes[j].Contains("red", StringComparison.OrdinalIgnoreCase))
                    {
                        Int32 takenRedCubes = Int32.Parse(match.Value);
                        if (takenRedCubes > START_VALUE_RED)
                        {
                            gameIsPossible = false;
                            break;
                        }
                    }
                }
            }
            
            result = gameIsPossible 
                ? result + i + 1 
                : result;
        }

        return result;
    }

    public static Int32 CalculatePartTwo(List<String> lines)
    {
        Int32 result = 0;

        foreach (var line in lines)
        {
            var lineFraction = line.Split(':')[1];
            var sets = lineFraction.Split(';');

            Int32 biggestBlueValue = 0;
            Int32 biggestGreenValue = 0;
            Int32 biggestRedValue = 0;

            foreach (var set in sets)
            {
                var cubes = set.Split(',');
                Regex regEx = new(@"\d{1,}");

                for (int j = 0; j < cubes.Length; j++)
                {
                    Match match = regEx.Match(cubes[j]);
                    
                    if (cubes[j].Contains("blue", StringComparison.OrdinalIgnoreCase))
                    {
                        Int32 takenBlueCubes = Int32.Parse(match.Value);
                        biggestBlueValue = takenBlueCubes > biggestBlueValue ? takenBlueCubes : biggestBlueValue;

                    }
                    else if (cubes[j].Contains("green", StringComparison.OrdinalIgnoreCase))
                    {
                        Int32 takenGreenCubes = Int32.Parse(match.Value);
                        biggestGreenValue = takenGreenCubes > biggestGreenValue ? takenGreenCubes : biggestGreenValue;

                    }
                    else if (cubes[j].Contains("red", StringComparison.OrdinalIgnoreCase))
                    {
                        Int32 takenRedCubes = Int32.Parse(match.Value);
                        biggestRedValue = takenRedCubes > biggestRedValue ? takenRedCubes : biggestRedValue;
                    }
                }
            }

            result += biggestBlueValue * biggestGreenValue * biggestRedValue;
        }        
        
        return result;
    }
}