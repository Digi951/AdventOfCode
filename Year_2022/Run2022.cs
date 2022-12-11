using AdventOfCode.Year_2022.Day_01;
using AdventOfCode.Year_2022.Day_02;
using AdventOfCode.Year_2022.Day_03;
using AdventOfCode.Year_2022.Day_04;
using AdventOfCode.Year_2022.Day_05;
using AdventOfCode.Year_2022.Day_06;
using AdventOfCode.Year_2022.Day_07;
using AdventOfCode.Year_2022.Day_10;

namespace AdventOfCode.Year_2022;

public class Run2022
{
    public static void Run()
    {
        // Day 01
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_01/Calories.txt");
        // result = CalorieCounting.Calculate(input);
        // var result = CalorieCounting.CalculateTopThree(input);

        // Day 02
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_02/StrategyGuide.txt");
        // var result = RockPaperScissor.Calculate(input);
        // var result = RockPaperScissor.Calculate2(input);

        // Day 03
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_03/RucksackCompartments.txt");
        // var result = RucksackReorganization.Calculate2(input);
        // var result = RucksackReorganization.Calculate2(input);

        // Day 04
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_04/AssignmentPairs.txt");
        // var result = CampCleanup.Calculate(input);
        // var result = CampCleanup.Calculate2(input);

        // Day 05
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_05/Procedure.txt");
        // var result = SupplyStacks.Calculate(input);
        //var result = SupplyStacks.Calculate2(input);

        // Day 06
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_06/DataStream.txt");
        // var result = TuningTrouble.Calculate(input);
        // var result = TuningTrouble.Calculate2(input);

        // Day 07
        // var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_07/TerminalInputs.txt");
        // var result = NoSpaceLeftOnDevice.Calculate(input);

        // Day 10
        var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_10/Instructions.txt");
        // var result = CathodeRayTube.Calculate(input);
        CathodeRayTube.Calculate2(input);

        // Console.WriteLine("### " + result + " ###");
        Console.ReadKey();
        
    }
}