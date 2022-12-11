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
         
        _crt = Enumerable.Repeat('.', 240).ToArray();        
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

        Int32 cycle = 1;
        Int32 instruction = 0;

        PrintCrt(_crt);

        Console.WriteLine();

        // Print(_sprite);

        for (int i = 0; i < instructions.Count; i++)
        {
            var shift = 0;

            if (instructions[instruction].Length > 1)
            {
                shift = Int32.Parse(instructions[instruction][1]);
            }

            if (MatchWithSprite((cycle - 1) % 40))
            {
                //Console.WriteLine("Block 1");
                //Print(_sprite);                    
                _crt[cycle - 1] = '#';
                PrintCrt(_crt);
            }

            Console.WriteLine($"Cycle: {cycle} | Instruction: {shift} | Position: {cycle - 1}");
            cycle++;

            if (MatchWithSprite((cycle - 1) % 40) && instructions[instruction].Length > 1)
            {
                //Console.WriteLine("Block 2");
                //Print(_sprite);
                _crt[cycle - 1] = '#';
                PrintCrt(_crt);

                Console.WriteLine($"Cycle: {cycle} | Instruction: {shift} | Position: {cycle - 1}");
                cycle++;

                ShiftSprite(shift);
                Print(_sprite);
            }
            
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
            Console.Write(matrix[i] + " ");
        }
        Console.WriteLine();
    }

    private static void Print(Char[] matrix)
    {
        for (Int32 i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(matrix[i] + " ");
        }
        Console.WriteLine();
    }
}
