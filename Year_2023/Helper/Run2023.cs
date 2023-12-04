using AdventOfCode.Year_2023.Day_01;
using AdventOfCode.Year_2023.Day_02;
using AdventOfCode.Year_2023.Day_03;
using AdventOfCode.Year_2023.Day_04;

namespace AdventOfCode.Year_2023;

public class Run2023
{
    public static void Run()
    {
        // Day 01
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2023/Day_01/Input.txt");
        // var result = Trebuchet.Calculate(input);
        // var result = Trebuchet.CalculatePartTwoFailure(input);
        
        // Day 02
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2023/Day_02/Input.txt");
        // var result = CubeConundrum.Calculate(input);
        // var result = CubeConundrum.CalculatePartTwo(input);
        
        // Day 03
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2023/Day_03/Input.txt");
        // var result = GearRatios.Calculate(input);
        // var result = CubeConundrum.CalculatePartTwo(input);
        
        // Day 04
        var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2023/Day_04/Input.txt");
        // var result = ScratchCards.Calculate(input);
        var result = ScratchCards.CalculatePartTwo(input);
            
        Console.WriteLine(result);
        Console.ReadKey();
    }
}