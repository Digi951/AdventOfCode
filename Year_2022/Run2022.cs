using AdventToCode.Year_2022.Day_01;
using AdventToCode.Year_2022.Day_02;
using AdventToCode.Year_2022.Day_03;
using AdventToCode.Year_2022.Day_04;

namespace AdventToCode.Year_2022
{
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
            var input = GlobalHelper.GlobalFileReader.GetAllLines(@"/Users/digi/Programmierung/AdventToCode/Year_2022/Day_04/AssignmentPairs.txt");
            // var result = CampCleanup.Calculate(input);
            var result = CampCleanup.Calculate2(input);


            Console.WriteLine("### " + result + " ###");
            Console.ReadKey();
            
        }
    }
}