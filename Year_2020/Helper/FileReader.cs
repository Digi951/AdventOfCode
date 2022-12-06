using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Year_2020.Helper;

public class FileReader
{
    public static List<string> ReadFile(string path)
    {
        var lines = File.ReadAllLines(path);
        return lines.ToList();
    }
}
