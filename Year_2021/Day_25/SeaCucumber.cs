namespace AdventToCode.Year_2021.Day_25;

public static class SeaCucumber
{
    private static bool _withLogging = false;

    public static void Run(List<List<char>> cucumbers)
    {
        var localCucumbers = CopyList(cucumbers);
        var jumpingCucumbers = new Queue<(int row, int column, char direction)>();
        bool moved;
        var index = 0;
        var initialCucumbers = CopyList(cucumbers);

        do
        {
            moved = false;

            for (int row = 0; row < initialCucumbers.Count; row++)
            {
                for (int column = initialCucumbers[row].Count - 1; column >= 0; column--)
                {
                    if (initialCucumbers[row][column] == '>')
                    {
                        if((column + 1) < initialCucumbers[row].Count)
                        {
                            if(initialCucumbers[row][column + 1] == '.')  
                            {
                                localCucumbers[row][column] = '.';
                                localCucumbers[row][column + 1] = '>';
                                moved = true;
                            } 
                        }
                        else
                        {
                            if(initialCucumbers[row][0] == '.')
                            {
                                localCucumbers[row][column] = '.';
                                jumpingCucumbers.Enqueue((row, 0, '>'));
                                moved = true;
                            }
                        }
                    }
                }
            }

            while (jumpingCucumbers.Count > 0)
            {
                var tempCucumber = jumpingCucumbers.Dequeue();
                localCucumbers[tempCucumber.row][tempCucumber.column] = tempCucumber.direction;
            }
            
            jumpingCucumbers.Clear();
            var cucumbersAfterRight = CopyList(localCucumbers);

            for (int row = cucumbersAfterRight.Count - 1; row >= 0; row--)
            {
                for (int column = 0; column < cucumbersAfterRight[row].Count; column++)
                {
                    if (cucumbersAfterRight[row][column] == 'v')
                    {
                        if((row + 1) < cucumbersAfterRight.Count)
                        {
                            if(cucumbersAfterRight[row + 1][column] == '.')  
                            {
                                localCucumbers[row][column] = '.';
                                localCucumbers[row + 1][column] = 'v';
                                moved = true;
                            } 
                        }
                        else
                        {
                            if(cucumbersAfterRight[0][column] == '.')
                            {
                                localCucumbers[row][column] = '.';
                                jumpingCucumbers.Enqueue((0, column, 'v'));
                                moved = true;
                            }
                        }
                    }
                }
            }

            while (jumpingCucumbers.Count > 0)
            {
                var tempCucumber = jumpingCucumbers.Dequeue();
                localCucumbers[tempCucumber.row][tempCucumber.column] = tempCucumber.direction;
            }

            index++;
            if(!moved)
            {
                Console.WriteLine($"No more moves after Step {index}");
                break;
            }

            if(_withLogging) 
            {
                Console.WriteLine($"Step {index}");
                PrintCucumbers(localCucumbers);
            }
            initialCucumbers = CopyList(localCucumbers);
        } while (index <= 10000000);

        PrintCucumbers(localCucumbers);
        Console.WriteLine($"Moved: {moved}");
    }

    private static void PrintCucumbers(List<List<char>> cucumbers)
    {
        for (int row = 0; row < cucumbers.Count; row++)
        {
            Console.Write($"{row} ");

            for (int column = 0; column < cucumbers[row].Count; column++)
            {
                Console.Write($"{cucumbers[row][column]}");
            }
            Console.WriteLine();
        }
    }

    private static List<List<char>> CopyList(List<List<char>> cucumbers)
    {
        var newCucumbers = new List<List<char>>();

        for (int row = 0; row < cucumbers.Count; row++)
        {
            newCucumbers.Add(new List<char>());

            for (int column = 0; column < cucumbers[row].Count; column++)
            {
                newCucumbers[row].Add(cucumbers[row][column]);
            }
        }

        return newCucumbers;
    }
}
