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
        Int32 register = 0;
        Int32 cycle = 0;
        Int32 instruction = 0;

        //PrintCrt(_crt);

        Console.WriteLine();

        for (int i = 0; i < instructions.Count; i++)
        {
            // Cycle 1 for each instruction
            cycle++;
            Console.WriteLine($"Begin executing {instructions[i][0]} {(instructions[i].Length > 1 ? instructions[i][1] : "")}");
            Console.WriteLine($"During cycle {cycle}: CRT draws pixel in position {cycle - 1}");
            _crt[cycle - 1] = MatchWithSprite((cycle - 1) % 40) ? '#' : ' ';
            PrintCrt(_crt);

            // Cycle 2 only for ADDX instructions
            if (instructions[i].Length > 1)
            {
                cycle++;
                Console.WriteLine($"During cycle {cycle}: CRT draws pixel in position {cycle - 1}");
                _crt[cycle - 1] = MatchWithSprite((cycle - 1) % 40) && instructions[i].Length > 1
                                    ? '#'
                                    : ' ';
                PrintCrt(_crt);
            }

            if (instructions[instruction].Length > 1)
            {
                register = GetMiddleposition();
                shift = Int32.Parse(instructions[instruction][1]);

                if (register + shift < 0)
                {
                    register = 0;
                }
                else if (register + shift > _sprite.Length - 1)
                {
                    register = _sprite.Length - 1;
                }
                else
                {
                    register += shift;
                }

                
                ShiftSprite(shift);
                Console.WriteLine($"Finish executing addx {shift} (Register X is now {register})");
            }
            else
            {
                Console.WriteLine("Finish executing noop");
            }
            
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

    private static Int32 GetMiddleposition()
    {
        Int32 middlePosition = 0;

        for (int i = 0; i < _sprite!.Length; i++)
        {
            if (i < _sprite.Length - 2
                && _sprite[i] == '#' && _sprite[i + 1] == '#' && _sprite[i + 2] == '#')
            {
                middlePosition = i + 1;
                break;
            }
            if (_sprite[0] == '#' && _sprite[1] != '#')
            {
                middlePosition = - 1;
                break;
            }
            if (_sprite[_sprite.Length - 2] != '#' && _sprite[_sprite.Length - 1] == '#')
            {
                middlePosition = _sprite.Length;
                break;
            }
        }

        return middlePosition;
    }

    private static void ShiftSprite(Int32 shift)
    {
        Int32 middlePosition = GetMiddleposition();

        middlePosition += shift;
        Int32 startIndex = middlePosition - 1;
        Int32 endIndex = middlePosition + 1;

        _sprite = Enumerable.Repeat('.', 40).ToArray();

        if (startIndex >= 0) { _sprite[startIndex] = '#'; }
        if (middlePosition >= 0 && middlePosition < _sprite.Length) { _sprite[middlePosition] = '#'; }
        if (endIndex < _sprite.Length) { _sprite[endIndex] = '#'; }
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
