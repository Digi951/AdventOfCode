namespace AdventToCode.Year_2021.Helper;

public static class FileReader
{
    public static List<string> ReadFile(string path)
    {
        var lines = File.ReadAllLines(path);
        return lines.ToList();
    }

    public static List<List<(int value, bool check)>> ReadFileAsMatrix(string path)
    {
        var lines = File.ReadAllLines(path);
        var matrix = new List<List<(int value, bool check)>>();

        foreach(var line in lines)
        {
            var row = line.Split(' ').ToList();
            var rowNumbers = new List<int>();

            if(row.Count > 1)
            {
                foreach(var item in row)
                {
                    if(item != "")
                    {
                        rowNumbers.Add(int.Parse(item));
                    }
                }
                (int value, bool check)[] result = rowNumbers.Select(x => (x, false)).ToArray();
                matrix.Add(result.ToList());
            }
        }

        return matrix;
    }

    public static List<string> ReadLineOfFile(string path)
    {
        var line = File.ReadLines(path).ToList();
        var values = line[0].Split(',');
        return values.ToList();
    }

    public static List<(int x1, int y1, int x2, int y2)> ReadLineOfFileAsCoordinatesStartEnd(string path)
    {
        var lines = File.ReadAllLines(path);
        var coordinates = new List<(int x1, int y1, int x2, int y2)>();

        foreach(var line in lines)
        {
            var split = line.Split("->");
            var coordinatesStart = split[0].Split(',');
            var coordinatesEnd = split[1].Split(',');

            coordinates.Add((int.Parse(coordinatesStart[0]), 
                            int.Parse(coordinatesStart[1]), 
                            int.Parse(coordinatesEnd[0]), 
                            int.Parse(coordinatesEnd[1])));
        }

        return coordinates;
    }

    public static List<(int x, int y)> ReadLineOfFileAsCoordinates(string path)
    {
        var lines = File.ReadAllLines(path);
        var coordinates = new List<(int x, int y)>();

        foreach(var line in lines)
        {
            var split = line.Split(",");

            coordinates.Add((int.Parse(split[0]), 
                            int.Parse(split[1])));
        }

        return coordinates;
    }

    public static Dictionary<string, string> ReadLineOfFileForPolymerization(string path)
    {
        var lines = File.ReadAllLines(path);
        var matchingTable = new Dictionary<string, string>();

        foreach (var line in lines)
        {
            var split = line.Split("->");   
            var pair = split[0].Trim();
            var match = split[1].Trim();

            matchingTable.Add(pair, match);
        }

        return matchingTable;
    }

    public static Queue<(string instruction, string first, string second)> ReadLineOfFileAsInstructions(string path)
    {
        var lines = File.ReadAllLines(path);
        var instructions = new Queue<(string instruction, string first, string second)>();

        foreach(var line in lines)
        {
            var split = line.Split(" ");
            var instruction = split[0];
            var first = "";
            if(split.Length > 1) { first = split[1];}
            var second = "";
            if(split.Length > 2) { second = split[2]; }

            instructions.Enqueue((instruction, first, second));
        }

        return instructions;
    }

    public static void ReadLinesOfFileAsDigits(string path, out List<List<string>> patterns, out List<List<string>> digits)
    {
        var lines = File.ReadAllLines(path);
        var localPatterns = new List<List<string>>();
        var localDigits = new List<List<string>>();

        foreach(var line in lines)
        {
            var split = line.Split("|");
            var splitPattern = split[0].Split(" ");
            var splitDigits = split[1].Split(" ");

            var tempPattern = new List<string>();
            var tempDigits = new List<string>();

            splitPattern.Where(x => x != "").ToList().ForEach(x => tempPattern.Add(x));
            splitDigits.Where(x => x != "").ToList().ForEach(x => tempDigits.Add(x));

            localPatterns.Add(tempPattern);
            localDigits.Add(tempDigits);
        }

        patterns = localPatterns;
        digits = localDigits;
    }
}
