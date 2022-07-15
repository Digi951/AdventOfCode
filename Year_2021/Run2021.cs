using AdventToCode.Year_2021.Day_01;
using AdventToCode.Year_2021.Day_02;
using AdventToCode.Year_2021.Day_03;
using AdventToCode.Year_2021.Day_04;
using AdventToCode.Year_2021.Day_05;
using AdventToCode.Year_2021.Day_06;
using AdventToCode.Year_2021.Day_07;
using AdventToCode.Year_2021.Day_08;
using AdventToCode.Year_2021.Day_09;
using AdventToCode.Year_2021.Day_10;
using AdventToCode.Year_2021.Day_13;
using AdventToCode.Year_2021.Day_15;
using AdventToCode.Year_2021.Day_21;
using AdventToCode.Year_2021.Day_24;
using AdventToCode.Year_2021.Day_25;
using AdventToCode.Year_2021.Helper;

namespace AdventToCode.Year_2021;

public static class Run2021
{
    public static void Run()
    {
        //Day 01
        // var input = FileReader.ReadFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_01/Measurement.txt");
        // var result = SonarSweep.Measure(input);
        // var result = SonarSweep.MeasureWindow(input);

        //Day 02
        //var input = FileReader.ReadFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_02/DiveList.txt");
        //var result = Dive.Navigate(input);
        //var result = Dive.NavigateWithAim(input);

        //Day 03
        //var input = FileReader.ReadFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_03/Binary.txt");
        //var result = BinaryDiagnostic.Calculate(input);
        //var result =
        //BinaryDiagnostic.Verify(input);

        //Day 04
        // var numbers = FileReader.ReadLineOfFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_04/numbers.txt");
        // var matrizes = FileReader.ReadFileAsMatrix(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_04/matrizes.txt");
        // var result = Bingo.Calculate(numbers, matrizes);

        //Day 05
        // var coordinates = FileReader.ReadLineOfFileAsCoordinates(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_05/coordinates.txt");
        // HydrothermalVenture.CalculateDiagonal(coordinates);

        //Day 06
        //var numbers = FileReader.ReadLineOfFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_06/Lanternfish.txt");
        //Lanternfish.Calculate(numbers);

        //Day 07
        //var positions = FileReader.ReadLineOfFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_07/positions.txt");
        //Day_07.TheTreacheryOfWhales.CountFuel(positions);
        //Day_07.TheTreacheryOfWhales.CountFuelPart2(positions);

        //Day 08
        // var patterns = new List<List<string>>();
        // var digits = new List<List<string>>();
        // FileReader.ReadLinesOfFileAsDigits(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_08/digits.txt", out patterns, out digits);
        // SevenSegmentSearch.CalculatePart2(patterns, digits);

        //Day 09
        // var heights = FileReader.ReadFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_09/heightmap.txt");
        // smokebasin.Run(heights);

        //Day 10
        // var subsystem = FileReader.ReadFile(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_10/NavigationSubsystem.txt");
        // var result = SyntaxScoring.CheckNavigationSubsystemForIllegalCharacters(subsystem);
        // var result2 = SyntaxScoring.CheckNavigationSubsystemForMissingCharacters(subsystem, result.IllegalLines);

        //Day 13
        // var coordinates = FileReader.ReadLineOfFileAsCoordinates(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_13/folding.txt");
        // var result = TransparentOrigami.Folding(coordinates);
        // Console.WriteLine(result);

        //Day 15
        // var matchingTable = FileReader.ReadLineOfFileForPolymerization(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_15/matchingTable.txt");
        // ExtendedPolymerization.Run(matchingTable);

        //Day 21
        // DiracDice.Run();

        //Day 24      
        // var instructions = FileReader.ReadLineOfFileAsInstructions(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_24/instructions.txt");
        // ArithmeticLogicUnit.Run(instructions);

        //Day 25
        var input = FileReader.ReadLinesOfFileAsHerds(@"/Users/digi/Programmierung/AdventToCode/Year_2021/Day_25/seaCucumberHerds.txt");
        SeaCucumber.Run(input);

        Console.WriteLine("End of Program");
    }
}