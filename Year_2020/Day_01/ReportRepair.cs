using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventToCode.Year_2020.Day_01;

public static class ReportRepair
{
    public static void CalculatePartOne(List<string> input)
    {
        var localInput = new List<string>(input);
        var result = from firstNumber in localInput
             from secondNumber in localInput
             where int.Parse(firstNumber) != int.Parse(secondNumber) && int.Parse(firstNumber) + int.Parse(secondNumber) == 2020
             select new { firstNumber, secondNumber };
             
             Console.WriteLine($"First number: {result.First().firstNumber}. Second number: {result.First().secondNumber}");
             Console.WriteLine($"Result: {int.Parse(result.First().firstNumber) * int.Parse(result.First().secondNumber)}");
    }

    public static void CalculatePartTwo(List<string> input)
    {
        var localInput = new List<string>(input);
        var result = from firstNumber in localInput
             from secondNumber in localInput
             from thirdNumber in localInput
             where int.Parse(firstNumber) + int.Parse(secondNumber) + int.Parse(thirdNumber) == 2020
             select new { firstNumber, secondNumber, thirdNumber };
             
             Console.WriteLine($"First number: {result.First().firstNumber}. Second number: {result.First().secondNumber}. Third number: {result.First().thirdNumber}");
             Console.WriteLine($"Result: {int.Parse(result.First().firstNumber) * int.Parse(result.First().secondNumber) * int.Parse(result.First().thirdNumber)}");
    }
}
