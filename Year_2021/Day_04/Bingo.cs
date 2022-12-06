namespace AdventOfCode.Year_2021.Day_04;

public static class Bingo
{
    public static int Calculate(List<string> input, List<List<(int value, bool check)>> matrizes)
    {

        foreach(var number in input)
        {
            for(int i = 0; i < matrizes.Count; i++)
            {
                for(int j = 0; j < matrizes[i].Count; j++)
                {
                    if(matrizes[i][j].value == int.Parse(number))
                    {
                        matrizes[i][j] = (matrizes[i][j].value, true);
                        var bingo = CheckMatrixForBingo(matrizes, i, j);
                    }
                }
            }
            
        }

        return 0;
    }

    private static bool CheckMatrixForBingo(List<List<(int value, bool check)>> matrizes, int row, int column)
    {
        //Check which number of matrix
        int numberOfMatrix = row / 5;
        int numberOfRow = row % 5;

        var startHorizontal = 0;
        var startVertical = numberOfMatrix * 5 - numberOfRow;

        var bingoHorizontal = false;
        var bingoVertical = false;

        for (int i = 0; i < 5; i++)
        {
            if (matrizes[numberOfMatrix][startHorizontal + i].check)
            {
                bingoHorizontal = true;
            }
            else
            {
                bingoHorizontal = false;
                break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (matrizes[startVertical + i][column].check)
            {
                bingoVertical = true;
            }
            else
            {
                bingoVertical = false;
                break;
            }
        }

        return bingoHorizontal || bingoVertical;
    }
}
