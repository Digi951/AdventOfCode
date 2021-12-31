namespace AdventToCode.Year_2021.Day_02;

public static class Dive
{
    public static int Navigate(List<string> instructions)
    {
        var currentHorizontalPosition = 0;
        var currentVerticalPosition = 0;

        foreach(var instruction in instructions)
        {
            var direction = instruction[0];

            _ = direction switch
            {
                'u' => currentVerticalPosition -= int.Parse(instruction[instruction.Length - 1].ToString()),
                'd' => currentVerticalPosition += int.Parse(instruction[instruction.Length - 1].ToString()),
                'f' => currentHorizontalPosition += int.Parse(instruction[instruction.Length - 1].ToString()),
            };
        }

        Console.WriteLine($"Final position is {currentHorizontalPosition} {currentVerticalPosition}");
        return currentHorizontalPosition * currentVerticalPosition;
    }

    public static int NavigateWithAim(List<string> instructions)
    {
        var currentHorizontalPosition = 0;
        var currentVerticalPosition = 0;
        var aim = 0;

        foreach (var instruction in instructions)
        {
            var direction = instruction[0];

            switch (direction)
            {
                case 'u':
                    aim -= int.Parse(instruction[instruction.Length - 1].ToString());
                    break;
                case 'd':
                    aim += int.Parse(instruction[instruction.Length - 1].ToString());
                    break;
                case 'f':
                    currentHorizontalPosition += int.Parse(instruction[instruction.Length - 1].ToString());
                    currentVerticalPosition += aim * int.Parse(instruction[instruction.Length - 1].ToString());
                    break;
            }               
        }

        Console.WriteLine($"Final position is {currentHorizontalPosition} {currentVerticalPosition}");
        return currentHorizontalPosition * currentVerticalPosition;
    }
}
