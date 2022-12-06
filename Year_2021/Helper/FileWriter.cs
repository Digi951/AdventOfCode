namespace AdventOfCode.Year_2021.Helper;

public static class FileWriter
{
    private static StreamWriter _streamWriter;
    public static void InitializieStreamWriter(string path) => _streamWriter = new StreamWriter(path,true);
    public static void WriteFile(string content)
    {
        _streamWriter.WriteLine(content);
        _streamWriter.Flush();
    }
    public static void WriteLineFile(string content) 
    {
        _streamWriter.WriteLine(content);
        _streamWriter.Flush();
    }
    public static void CloseStreamWriter() => _streamWriter.Close();
}
