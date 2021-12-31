namespace AdventToCode.Year_2021.Day_13;

public static class TransparentOrigami
{
    public static int Folding(List<(int x, int y)> inputs)
    {
        var foldingCoordinates = new List<(int x, int y)>();

        var startingMatrix = new List<List<bool>>();

        for(int i = 0; i <= inputs.Max(x => x.y); i++)
        {
            var newItem = Enumerable.Repeat(false, inputs.Max(x => x.x + 1)).ToList();
            startingMatrix.Add(newItem);
        }

        for (int i = 0; i < inputs.Count; i++)
        {
            startingMatrix[inputs[i].y][inputs[i].x] = true;
        }
            
        //PrintMatrix(startingMatrix);
        // foldingCoordinates.Add((0, 7));
        // foldingCoordinates.Add((5, 0));
        foldingCoordinates.Add((655, 0));
        foldingCoordinates.Add((0, 447));
        foldingCoordinates.Add((327, 0));
        foldingCoordinates.Add((0, 223));
        foldingCoordinates.Add((163, 0));
        foldingCoordinates.Add((0, 111));
        foldingCoordinates.Add((81, 0));
        foldingCoordinates.Add((0, 55));
        foldingCoordinates.Add((40, 0));
        foldingCoordinates.Add((0, 27));
        foldingCoordinates.Add((0, 13));
        foldingCoordinates.Add((0, 6));

        var currentFoldedMatrix = startingMatrix;
        var newFoldedMatrix = new List<List<bool>>();

        foreach (var coordinate in foldingCoordinates)
        {
            newFoldedMatrix = FoldMatrix(currentFoldedMatrix, coordinate);
            currentFoldedMatrix = newFoldedMatrix;
        }


        //PrintMatrix(foldedMatrix);
        
        Console.WriteLine();
        PrintMatrix(currentFoldedMatrix);

        return currentFoldedMatrix.Sum(x => x.Count(y => y));
    }

    private static List<List<bool>> FoldMatrix(List<List<bool>> inputMatrix, (int x, int y) foldingCoordinate)
    {
        var newXLength = foldingCoordinate.x > 0 ? foldingCoordinate.x : inputMatrix[0].Count;
        var newYLength = foldingCoordinate.y > 0 ? foldingCoordinate.y : inputMatrix.Count;

        var countXItems = foldingCoordinate.x > 0 ? inputMatrix[0].Count - 1 : 0;
        var countYItems = foldingCoordinate.y > 0 ? inputMatrix.Count - 1 : 0;

        var newMatrix = new List<List<bool>>();

        for(int i = 0; i < newYLength; i++)
        {
            var newItem = Enumerable.Repeat(false, newXLength).ToList();
            newMatrix.Add(newItem);
        }

        // Copy the values from the input matrix to the new matrix
        for(var y = 0; y < newYLength; y++)
        {
            for(var x = 0; x < newXLength; x++)
            {
                newMatrix[y][x] = inputMatrix[y][x];
            }
        }

        PrintMatrix(newMatrix);

        // Copy the values from folded matrix to the new matrix
        if(newXLength < inputMatrix[0].Count)
        {
            for(var x = foldingCoordinate.x + 1; x < inputMatrix[0].Count; x++)
            {
                for(var y = 0; y < inputMatrix.Count; y++)
                {
                    if(inputMatrix[y][x])
                    {
                        newMatrix[y][countXItems - x] = inputMatrix[y][x];
                    }
                }
            }
        }

        if (newYLength < inputMatrix.Count)
        {
            for (var y = foldingCoordinate.y + 1; y < inputMatrix.Count; y++)
            {
                for (var x = 0; x < inputMatrix[y].Count; x++)
                {
                    if (inputMatrix[y][x])
                    {
                        newMatrix[countYItems - y][x] = inputMatrix[y][x];
                    }
                }
            }
        }

        return newMatrix;
    }

    private static void PrintMatrix(List<List<bool>> intput)
    {
        var count = 0;
        for(int y = 0; y < intput.Count; y++)
        {
            Console.Write($"{y} ");
            for(int x = 0; x < intput[y].Count; x++)
            {
                if(intput[y][x])count++;
                Console.Write(intput[y][x] ? "#" : ".");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"{count}");
        Console.WriteLine();
    }
}