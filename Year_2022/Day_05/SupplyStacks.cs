using System;
using System.Text;

namespace AdventOfCode.Year_2022.Day_05;

public static class SupplyStacks
{
    private static Stack<String> _stackOne = new();
    private static Stack<String> _stackTwo = new();
    private static Stack<String> _stackThree = new();
    private static Stack<String> _stackFour = new();
    private static Stack<String> _stackFive = new();
    private static Stack<String> _stackSix = new();
    private static Stack<String> _stackSeven = new();
    private static Stack<String> _stackEight = new();
    private static Stack<String> _stackNine = new();

    private static List<Stack<String>> _stacks = new();


    private static void Init()
    {
        _stackOne.Push("Z");
        _stackOne.Push("N");

        _stackTwo.Push("M");
        _stackTwo.Push("C");
        _stackTwo.Push("D");

        _stackThree.Push("P");

        _stacks.Add(_stackOne);
        _stacks.Add(_stackTwo);
        _stacks.Add(_stackThree);
    }

    private static void Init1()
    {
        _stackOne.Push("F");
        _stackOne.Push("C");
        _stackOne.Push("P");
        _stackOne.Push("G");
        _stackOne.Push("Q");
        _stackOne.Push("R");

        _stackTwo.Push("W");
        _stackTwo.Push("T");
        _stackTwo.Push("C");
        _stackTwo.Push("P");

        _stackThree.Push("B");
        _stackThree.Push("H");
        _stackThree.Push("P");
        _stackThree.Push("M");
        _stackThree.Push("C");

        _stackFour.Push("L");
        _stackFour.Push("T");
        _stackFour.Push("Q");
        _stackFour.Push("S");
        _stackFour.Push("M");
        _stackFour.Push("P");
        _stackFour.Push("R");

        _stackFive.Push("P");
        _stackFive.Push("H");
        _stackFive.Push("J");
        _stackFive.Push("Z");
        _stackFive.Push("V");
        _stackFive.Push("G");
        _stackFive.Push("N");

        _stackSix.Push("D");
        _stackSix.Push("P");
        _stackSix.Push("J");

        _stackSeven.Push("L");
        _stackSeven.Push("G");
        _stackSeven.Push("P");
        _stackSeven.Push("Z");
        _stackSeven.Push("F");
        _stackSeven.Push("J");
        _stackSeven.Push("T");
        _stackSeven.Push("R");

        _stackEight.Push("N");
        _stackEight.Push("L");
        _stackEight.Push("H");
        _stackEight.Push("C");
        _stackEight.Push("F");
        _stackEight.Push("P");
        _stackEight.Push("T");
        _stackEight.Push("J");

        _stackNine.Push("G");
        _stackNine.Push("V");
        _stackNine.Push("Z");
        _stackNine.Push("Q");
        _stackNine.Push("H");
        _stackNine.Push("T");
        _stackNine.Push("C");
        _stackNine.Push("W");

        _stacks.Add(_stackOne);
        _stacks.Add(_stackTwo);
        _stacks.Add(_stackThree);
        _stacks.Add(_stackFour);
        _stacks.Add(_stackFive);
        _stacks.Add(_stackSix);
        _stacks.Add(_stackSeven);
        _stacks.Add(_stackEight);
        _stacks.Add(_stackNine);
    }

    public static String Calculate(List<String> inputs)
    {
        SupplyStacks.Init1();

        var instructions = new List<(Int32 Move, Int32 Source, Int32 Destination)>();

        foreach (var input in inputs)
        {
            var tempDigits = new List<Int32>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    if (i + 1 < input.Length && Char.IsDigit(input[i + 1]))
                    {
                        String number = input[i].ToString() + input[i + 1].ToString();
                        tempDigits.Add(Int32.Parse(number));
                        i++;
                    }
                    else
                    {
                        tempDigits.Add(int.Parse(input[i].ToString()));
                    }                    
                }
            }
            instructions.Add((tempDigits[0], tempDigits[1], tempDigits[2]));
        }

        foreach (var instruction in instructions)
        {
            for (int i = 0; i < instruction.Move; i++)
            {
                String temp = _stacks[instruction.Source - 1].Pop();
                _stacks[instruction.Destination - 1].Push(temp.ToString());
            }
        }

        var result = new StringBuilder();

        foreach (var stack in _stacks)
        {
            result.Append(stack.Peek());
        }

        return result.ToString();
    }

    public static String Calculate2(List<String> inputs)
    {
        SupplyStacks.Init1();

        var instructions = new List<(Int32 Move, Int32 Source, Int32 Destination)>();

        foreach (var input in inputs)
        {
            var tempDigits = new List<Int32>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    if (i + 1 < input.Length && Char.IsDigit(input[i + 1]))
                    {
                        String number = input[i].ToString() + input[i + 1].ToString();
                        tempDigits.Add(Int32.Parse(number));
                        i++;
                    }
                    else
                    {
                        tempDigits.Add(int.Parse(input[i].ToString()));
                    }
                }
            }
            instructions.Add((tempDigits[0], tempDigits[1], tempDigits[2]));
        }

        foreach (var instruction in instructions)
        {
            Stack<String> tempStack = new();

            for (int i = 0; i < instruction.Move; i++)
            {                
                tempStack.Push(_stacks[instruction.Source - 1].Pop());                 
            }

            for (int i = 0; i < instruction.Move; i++)
            {
                _stacks[instruction.Destination - 1].Push(tempStack.Pop().ToString());
            }
        }

        var result = new StringBuilder();

        foreach (var stack in _stacks)
        {
            result.Append(stack.Peek());
        }

        return result.ToString();
    }
}

