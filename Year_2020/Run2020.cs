using AdventOfCode.Year_2020.Day_01;
using AdventOfCode.Year_2020.Helper;

namespace AdventOfCode.Year_2020;

public static class Run2020
{
    public static void Run()
    {
        //Day 01
        var input = FileReader.ReadFile("Year_2020/Day_01/numbers.txt");
        // ReportRepair.CalculatePartOne(input);
        ReportRepair.CalculatePartTwo(input);
    }
}
