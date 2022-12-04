using System;
namespace AdventToCode.Year_2022.Day_04;

public static class CampCleanup
{
    public static Int32 Calculate(List<String> inputs)
    {
        var result = 0;

        var sections = new List<(String sectionOne, String sectionTwo)>();

        Int32 startSectionOne = 0;
        Int32 endSectionOne = 0;
        Int32 startSectionTwo = 0;
        Int32 endSectionTwo = 0;

        foreach (var input in inputs)
        {
            var temp = input.Split('-', ',');

            startSectionOne = Int32.Parse(temp[0]);
            endSectionOne = Int32.Parse(temp[1]);
            startSectionTwo = Int32.Parse(temp[2]);
            endSectionTwo = Int32.Parse(temp[3]);

            if ((startSectionOne <= startSectionTwo && endSectionOne >= endSectionTwo)
                || (startSectionTwo <= startSectionOne && endSectionTwo >= endSectionOne))
            {
                result++;
            }
        }

        return result;
    }

    public static Int32 Calculate2(List<String> inputs)
    {
        var result = 0;

        var sections = new List<(String sectionOne, String sectionTwo)>();

        Int32 startSectionOne = 0;
        Int32 endSectionOne = 0;
        Int32 startSectionTwo = 0;
        Int32 endSectionTwo = 0;

        Int32 index = 1;

        foreach (var input in inputs)
        {
            var temp = input.Split('-', ',');

            startSectionOne = Int32.Parse(temp[0]);
            endSectionOne = Int32.Parse(temp[1]);
            startSectionTwo = Int32.Parse(temp[2]);
            endSectionTwo = Int32.Parse(temp[3]);

            if ((startSectionOne <= startSectionTwo && endSectionOne >= endSectionTwo)
                || (startSectionTwo <= startSectionOne && endSectionTwo >= endSectionOne)
                || (startSectionTwo <= endSectionOne && endSectionTwo >= startSectionOne)
                || (startSectionOne <= endSectionTwo && endSectionOne >= startSectionTwo))
            {
                result++;

                Console.WriteLine($"{index}: Match number {result} -> {startSectionOne}-{endSectionOne}, {startSectionTwo}-{endSectionTwo}");
            }

            index++;
        }

        return result;
    }
}

