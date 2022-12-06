namespace AdventOfCode.Year_2022.Day_06;

public static class TuningTrouble
{
    public static Int32 Calculate(List<String> inputs)
    {
        const Int32 character_Package = 4;

        var fifo = new Queue<String>(character_Package);

        var input = new String(inputs[0]);

        Int32 index = 0;

        for (index = 0; index < input.Length; index++)
        {
            fifo.Enqueue(input[index].ToString());

            if (fifo.Count > character_Package) { fifo.Dequeue(); }

            if (fifo.Count == character_Package && AreCharactersUnique(fifo))
            {
                return index + 1;
            }            
        }

        return 0;
    }

    public static Int32 Calculate2(List<String> inputs)
    {
        const Int32 character_Package = 14;

        var fifo = new Queue<String>(character_Package);

        var input = new String(inputs[0]);

        Int32 index = 0;

        for (index = 0; index < input.Length; index++)
        {
            fifo.Enqueue(input[index].ToString());

            if (fifo.Count > character_Package) { fifo.Dequeue(); }

            if (fifo.Count == character_Package && AreCharactersUnique(fifo))
            {
                return index + 1;
            }
        }

        return 0;
    }

    private static Boolean AreCharactersUnique(Queue<String> inputs)
    {
        var temp = inputs.ToList();

        for (int i = 0; i < inputs.Count; i++)
        {
            for (int j = i + 1; j < inputs.Count; j++)
            {
                if (temp[i] == temp[j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
