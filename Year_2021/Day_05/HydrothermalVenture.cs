namespace AdventOfCode.Year_2021.Day_05;

public static class HydrothermalVenture
{
    public static void Calculate(List<(int x1, int y1, int x2, int y2)> coordinates)
    {
        var maxX = coordinates.Max(x => x.x1 > x.x2 ? x.x1 : x.x2);
        var maxY = coordinates.Max(x => x.y1 > x.y2 ? x.y1 : x.y2);

        var grid = new List<List<int>>();

        for (int i = 0; i <= maxY; i++)
        {
            grid.Add(new List<int>());
            for (int j = 0; j <= maxX; j++)
            {
                grid[i].Add(0);
            }
        }

        foreach (var coordinate in coordinates)
        {
                if(coordinate.x1 > coordinate.x2 && coordinate.y1 == coordinate.y2)
                {
                    for (int i = coordinate.x2; i <= coordinate.x1; i++)
                    {
                        grid[coordinate.y1][i]++;
                    }
                }
                else if(coordinate.x2 > coordinate.x1 && coordinate.y1 == coordinate.y2)
                {
                    for (int i = coordinate.x1; i <= coordinate.x2; i++)
                    {
                        grid[coordinate.y1][i]++;
                    }
                }

                if (coordinate.y1 > coordinate.y2 && coordinate.x1 == coordinate.x2)
                {
                    for (int i = coordinate.y2; i <= coordinate.y1; i++)
                    {
                        grid[i][coordinate.x1]++;
                    }
                }
                else if(coordinate.y2 > coordinate.y1 && coordinate.x1 == coordinate.x2)
                {
                    for (int i = coordinate.y1; i <= coordinate.y2; i++)
                    {
                        grid[i][coordinate.x1]++;
                    }
                }
        }

        //count numbers of coordinates greater than 1

        var count = 0;
        for (int i = 0; i <= maxX; i++)
        {
            for (int j = 0; j <= maxY; j++)
            {
                if (grid[i][j] > 1)
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }

    public static void CalculateDiagonal(List<(int x1, int y1, int x2, int y2)> coordinates)
    {
        var maxX = coordinates.Max(x => x.x1 > x.x2 ? x.x1 : x.x2);
        var maxY = coordinates.Max(x => x.y1 > x.y2 ? x.y1 : x.y2);

        var grid = new List<List<int>>();

        for (int i = 0; i <= maxY; i++)
        {
            grid.Add(new List<int>());
            for (int j = 0; j <= maxX; j++)
            {
                grid[i].Add(0);
            }
        }

        foreach (var coordinate in coordinates)
        {
            //Check if the coordinates are on the same line (horizontal))
            if(coordinate.x1 > coordinate.x2 && coordinate.y1 == coordinate.y2)
            {
                for (int i = coordinate.x2; i <= coordinate.x1; i++)
                {
                    grid[coordinate.y1][i]++;
                }
            }
            else if(coordinate.x2 > coordinate.x1 && coordinate.y1 == coordinate.y2)
            {
                for (int i = coordinate.x1; i <= coordinate.x2; i++)
                {
                    grid[coordinate.y1][i]++;
                }
            }

            //Check if the coordinates are on the same line (vertical)
            if (coordinate.y1 > coordinate.y2 && coordinate.x1 == coordinate.x2)
            {
                for (int i = coordinate.y2; i <= coordinate.y1; i++)
                {
                    grid[i][coordinate.x1]++;
                }
            }
            else if(coordinate.y2 > coordinate.y1 && coordinate.x1 == coordinate.x2)
            {
                for (int i = coordinate.y1; i <= coordinate.y2; i++)
                {
                    grid[i][coordinate.x1]++;
                }
            }

            //Check if the coordinates are on the same line (diagonal)
            //  #
            // #
            if(Math.Abs(coordinate.x1 - coordinate.x2) == Math.Abs(coordinate.y1 - coordinate.y2) && 
            coordinate.x1 > coordinate.x2 && coordinate.y1 > coordinate.y2)
            {
                for (int i = 0; i <= coordinate.x1 - coordinate.x2; i++)
                {
                    grid[coordinate.y2 + i][coordinate.x2 + i]++;
                }
            }
            else if(Math.Abs(coordinate.x2 - coordinate.x1) == Math.Abs(coordinate.y2 - coordinate.y1) && 
            coordinate.x2 > coordinate.x1 && coordinate.y2 > coordinate.y1)
            {
                for (int i = 0; i <= coordinate.x2 - coordinate.x1; i++)
                {
                    grid[coordinate.y1 + i][coordinate.x1 + i]++;
                }
            }

            //Check if the coordinates are on the same line (diagonal)
            // #
            //  #
            if(Math.Abs(coordinate.x1 - coordinate.x2) == Math.Abs(coordinate.y2 - coordinate.y1) && 
            coordinate.x1 > coordinate.x2 && coordinate.y2 > coordinate.y1)
            {
                for (int i = 0; i <= coordinate.x1 - coordinate.x2; i++)
                {
                    grid[coordinate.y2 - i][coordinate.x2 + i]++;
                }
            }
            else if(Math.Abs(coordinate.x2 - coordinate.x1) == Math.Abs(coordinate.y1 - coordinate.y2) && 
            coordinate.x2 > coordinate.x1 && coordinate.y1 > coordinate.y2)
            {
                for (int i = 0; i <= coordinate.y1 - coordinate.y2; i++)
                {
                    grid[coordinate.y2 + i][coordinate.x2 - i]++;
                }
            }
        }

        //count numbers of coordinates greater than 1
        var count = 0;
        for (int i = 0; i <= maxX; i++)
        {
            for (int j = 0; j <= maxY; j++)
            {
                if (grid[i][j] > 1)
                {
                    count++;
                }
            }
        }

        //PrintGrid(grid, coordinates);
        Console.WriteLine(count);
    }

    private static void PrintGrid(List<List<int>> grid, (int x1, int y1, int x2, int y2) coordinates)
    {
        Console.WriteLine($"{coordinates.x1} {coordinates.y1} {coordinates.x2} {coordinates.y2}");
        for (int i = 0; i < grid.Count; i++)
        {
            Console.Write($"{i}| ");
            for (int j = 0; j < grid[i].Count; j++)
            {
                Console.Write($"{grid[i][j]} ");
            }
            Console.WriteLine(); 
        }
        Console.WriteLine();
    }
}
