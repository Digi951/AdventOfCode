namespace AdventOfCode.Year_2023.Day_03;

public static class GearRatios
{
    public static Int32 Calculate(List<String> lines)
    {
        Int32 result = 0;

        Int32 width = lines.Max().Length;
        Int32 height = lines.Count;

        Char[,] map = new char[width, height];

        for (var i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                map[i, j] = lines[i][j];
            }
        }

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                
            }
        }

        return result;
    }

    public static Int32 CalculatePartTwo(List<String> lines)
    {
        Int32 result = 0;
        
        return result;
    }
}