namespace AdventOfCode.Year_2021.Day_09;

public static class smokebasin
{
    public static void Run(List<string> inputs)
    {
        var neighbours = new List<(int y, int x)>(){(0,1), (1,0), (0,-1), (-1,0)};
        var heightmap = new List<int>();

        for (int i = 0; i < inputs.Count; i++)
        {
            for (int j = 0; j < inputs[0].Length; j++)
            {
                //Console.WriteLine($"Checking Value {inputs[i][j]} at {i}, {j}");
                var neighbourIsSmaller = false;

                foreach(var neighbour in neighbours)
                {
                    if(i + neighbour.y < 0 || i + neighbour.y >= inputs.Count 
                        || j + neighbour.x < 0 || j + neighbour.x >= inputs[0].Length)
                    {
                        continue;
                    }

                    if(inputs[i + neighbour.y][j + neighbour.x] <= inputs[i][j])
                    {
                        // Console.Write($"Neighbour: [{i + neighbour.y}] [{j + neighbour.x}]. {inputs[i + neighbour.y][j + neighbour.x]} < Value: {inputs[i][j]}. ");
                        // Console.WriteLine("Neighbour is smaller");
                        // Console.WriteLine(new string('-', 10));
                        neighbourIsSmaller = true;
                        break;
                    }
                    // else
                    // {
                    //     Console.WriteLine($"Neighbour: [{i + neighbour.y}] [{j + neighbour.x}]. {inputs[i + neighbour.y][j + neighbour.x]} > Value: {inputs[i][j]}");
                    // }
                    
                }
                if(!neighbourIsSmaller)
                {
                    heightmap.Add(int.Parse(inputs[i][j].ToString()) + 1);
                    // Console.WriteLine($"All Neighbours checked. Value: {inputs[i][j]}. Added Value: {heightmap.Last()}");
                    // Console.WriteLine(new string('-', 10));
                }
            }
        }

        //heightmap.ToList().ForEach(x => Console.Write($"{x} "));

        var result = 0;
        heightmap.ToList().ForEach(x => result += x);

        Console.WriteLine($"Result: {result}");
    }

    public static void Run2(List<string> inputs)
    {
        bool[,] visited = new bool[inputs.Count, inputs[0].Length];
        var bassins = new List<List<(int y, int x)>>();
        var neighbours = new List<(int y, int x)>(){(0,1), (1,0), (0,-1), (-1,0)};

        for (int i = 0; i < inputs.Count; i++)
        {
            for (int j = 0; j < inputs[0].Length; j++)
            {
                if(!visited[i,j])
                {
                    CheckNeighbour(i, j, inputs, visited, neighbours, bassins);
                }
                else
                {
                    continue;
                }
            }
        }
    }

    //Check if the current node is part of a basin
    private static void CheckNeighbour(int row, int column, List<string> inputs, bool[,] visited, List<(int y, int x)> neighbours, List<List<(int y, int x)>> bassins)
    {
        (int Row, int Column) neighbourCoordinate = (row, column);
        
        while(neighbourCoordinate.Row <= inputs.Count - 1 && neighbourCoordinate.Row >= 0 
            && neighbourCoordinate.Column <= inputs[0].Length - 1 && neighbourCoordinate.Column >= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                
            }
        }
    }
}