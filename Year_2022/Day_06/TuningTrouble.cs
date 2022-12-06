namespace AdventOfCode.Year_2022.Day_06;

public static class TuningTrouble
{
    public static Int32 Calculate(List<String> inputs)
    {
        var fifo = new Queue<String>(4);

        for (int i = 0; i < 4; i++)
        {
            fifo.Enqueue(inputs[i]);
        }

        

        Int32 result = 0;

        return result;
    }

    private static Boolean AreCharactersUnique(Queue<String> inputs)
    {
        var temp = inputs.ToList();
        return temp[0] != temp[1] 
            && temp[1] != temp[2] 
            && temp[2] != temp[3]
            && temp[3] != temp[4]
            && temp[4] != temp[0];
    }
}
