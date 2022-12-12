using System;
namespace AdventOfCode.Year_2022.Day_10;

public static class CathodeRayTube
{
    private static Char[]? _sprite;
    private static char[]? _crt = new char[240];

    private static void Init()
    {
        _sprite = Enumerable.Repeat('.', 40).ToArray();
        for (int i = 0; i < 3; i++)
        {
            _sprite[i] = '#';
        }
         
        _crt = Enumerable.Repeat(' ', 240).ToArray();        
    }

    public static Int32 Calculate(List<String> inputs)
    {
        var instructions = inputs.Select(x => x.Split(' ')).ToList();

        var result = 1;

        Int32 cycle = 1;

        Int32 sumOfStrength = 0;

        for (int i = 0; i < instructions.Count; i++)
        {
            if (instructions[i].Count() > 1 && instructions[i][0] != "noop")
            {
                for (int j = 0; j < 2; j++)
                {
                    cycle++;
                    Console.Write($"Cycle: {cycle} ");

                    if (j == 1) { result += Int32.Parse(instructions[i][1]); }

                    sumOfStrength = CalcStrengthOfSignal(result, cycle, sumOfStrength);
                }

                Console.WriteLine($"/ instruction({instructions[i][1]}) -> result: {result}");
            }

            if (instructions[i][0] == "noop")
            {
                cycle++;
                Console.WriteLine($"Cycle: {cycle} / noop");
                sumOfStrength = CalcStrengthOfSignal(result, cycle, sumOfStrength);
            }
        }        

        return sumOfStrength;
    }

    private static Int32 CalcStrengthOfSignal(int result, int cycle, int sumOfStrength)
    {
        if ((cycle + 20) % 40 == 0)
        {
            var temp = result;

            var strength = result * (cycle);
            Console.WriteLine($" result: {cycle} * {temp} = {strength}");

            sumOfStrength += strength;
        }

        return sumOfStrength;
    }

    public static void Calculate2(List<String> inputs)
    {
        Init();

        var instructions = inputs.Select(x => x.Split(' ')).ToList();

        Int32 shift = 0;
        Int32 oldShift = 0;
        Int32 cycle = 0;
        Int32 instruction = 0;

        PrintCrt(_crt);

        Console.WriteLine();

        for (int i = 0; i < instructions.Count; i++)
        {
            // Cycle 1 for each instruction
            cycle++;
            Console.WriteLine($"During cycle {cycle}: CRT draws pixel in position {cycle - 1}");
            _crt[cycle - 1] = MatchWithSprite((cycle - 1) % 40) ? '#' : '.';
            PrintCrt(_crt);

            // Cycle 2 only for ADDX instructions
            if (instructions[i].Length > 1)
            {
                cycle++;
                Console.WriteLine($"During cycle {cycle}: CRT draws pixel in position {cycle - 1}");
                _crt[cycle - 1] = MatchWithSprite((cycle - 1) % 40) && instructions[i].Length > 1
                                    ? '#'
                                    : '.';
                PrintCrt(_crt);
            }

            if (instructions[instruction].Length > 1)
            {
                oldShift += shift;
                shift = Int32.Parse(instructions[instruction][1]);
                ShiftSprite(shift);
            }
            
            Console.WriteLine($"Finish executing addx {shift} (Register X is now {oldShift + shift + 1})");
            Print(_sprite);

            instruction++;
        }

        Console.WriteLine();
        PrintCrt(_crt);
    }

    private static Boolean MatchWithSprite(Int32 position)
    {        
        if (_sprite![position] == '#')
        {
            return true;
        }
        
        return false;
    }

    private static void ShiftSprite(Int32 shift)
    {
        Int32 middlePosition = 0;

        // Console.WriteLine(shift);

        for (int i = 0; i < _sprite!.Length; i++)
        {
            if (_sprite[i] == '#')
            {
                middlePosition = i + 1;
                break;
            }
        }

        if (middlePosition + shift >= 0 && middlePosition + shift < _sprite.Length)
        {
            middlePosition += shift;
        }

        Int32 startIndex = middlePosition == 0 ? middlePosition : middlePosition - 1;
        Int32 endIndex = middlePosition == 39 ? middlePosition : middlePosition + 1;

        _sprite = Enumerable.Repeat('.', 40).ToArray();
        for (int i = startIndex; i <= endIndex; i++)
        {
            _sprite[i] = '#';
        }
    }

    private static void PrintCrt(Char[] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (i % 40 == 0)
            {
                Console.WriteLine();
            }
            Console.Write(matrix[i]);
        }
        Console.WriteLine();
    }

    private static void Print(Char[] matrix)
    {
        for (Int32 i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(matrix[i]);
        }
        Console.WriteLine();
    }
}
