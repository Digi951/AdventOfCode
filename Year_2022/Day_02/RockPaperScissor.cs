using System;
namespace AdventOfCode.Year_2022.Day_02;

public static class RockPaperScissor
{
    const Int32 draw = 3;
    const Int32 victory = 6;

    private static Dictionary<String, String> _winStrategy = new()
    {
        { "A", "Y"},
        { "B", "Z"},
        { "C", "X"}
    };

    private static Dictionary<String, String> _loseStrategy = new()
    {
        { "A", "Z"},
        { "B", "X"},
        { "C", "Y"}
    };

    private static Dictionary<String, String> _drawStrategy = new()
    {
        { "A", "X"},
        { "B", "Y"},
        { "C", "Z"}
    };

    private static Dictionary<String, String> _translate = new()
    {
        { "A", "Rock"},
        { "B", "Paper"},
        { "C", "Scissor"},
        { "X", "Rock"},
        { "Y", "Paper"},
        { "Z", "Scissor"}
    };

    private static Dictionary<String, Int32> _points = new()
    {
        { "X", 1 },
        { "Y", 2 },
        { "Z", 3 }
    };

    public static Int32 Calculate(List<String> inputs)
    {
        // Rock -> A/X -> 1
        // Paper -> B/Y -> 2
        // Scissor -> C/Z ->3

        List<String[]> strategyGuide = new();

        foreach (var input in inputs)
        {
            var temp = input.Split(' ');

            strategyGuide.Add(temp);
        }

        var result = 0;
        Int32 index = 1;

        foreach (var item in strategyGuide)
        {
            Console.Write($"{index} ");

            if (item[1] == _winStrategy[item[0]])
            {
                Console.Write($"Sieg: {item[1]}({_translate[item[1]]}) vs. {item[0]}({_translate[item[0]]}) ");
                var temp = _points[item[1]] + victory;
                Console.WriteLine($"Punkte: {_points[item[1]]} + {victory} = {temp}");
                result += temp;
            }
            else if (item[1] == _drawStrategy[item[0]])
            {
                Console.Write($"Unentschieden: {item[1]}({_translate[item[1]]}) vs. {item[0]}({_translate[item[0]]}) ");
                var temp = _points[item[1]] + draw;
                Console.WriteLine($"Punkte: {_points[item[1]]} + {draw} = {temp}");
                result += temp;
            }
            else if (item[1] == _loseStrategy[item[0]])
            {
                Console.Write($"Verloren: {item[1]}({_translate[item[1]]}) vs. {item[0]}({_translate[item[0]]}) ");
                var temp = _points[item[1]];
                Console.WriteLine($"Punkte: {temp}");                    
                result += temp;
            }

            index++;
        }

        return result;
    }

    public static Int32 Calculate2(List<String> inputs)
    {
        // Rock -> A/X -> 1
        // Paper -> B/Y -> 2
        // Scissor -> C/Z ->3

        // X -> I lose
        // Y -> draw
        // Z -> I win

        List<String[]> strategyGuide = new();

        foreach (var input in inputs)
        {
            var temp = input.Split(' ');

            strategyGuide.Add(temp);
        }

        var result = 0;
        Int32 index = 1;

        foreach (var item in strategyGuide)
        {
            Console.Write($"{index} -> ");
            if (item[1] == "X")
            {
                Console.WriteLine($"Verloren: {_points[_loseStrategy[item[0]]]}");
                result += _points[_loseStrategy[item[0]]];
            }
            else if (item[1] == "Y")
            {
                Console.WriteLine($"Unentschieden: {draw} + {_points[_drawStrategy[item[0]]]}");
                result += draw + _points[_drawStrategy[item[0]]];
            }
            else
            {
                Console.WriteLine($"Sieg: {victory} + {_points[_winStrategy[item[0]]]}");
                result += victory + _points[_winStrategy[item[0]]];
            }
            index++;
        }

        return result;
    }
}

