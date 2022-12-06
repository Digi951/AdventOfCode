
namespace AdventOfCode.GlobalHelper
{
    public static class GlobalFileReader
    {
        public static List<String> GetAllLines(String sourcePath)
        {
            var result = File.ReadAllLines(sourcePath);

            return result.ToList();
        }
    }
}