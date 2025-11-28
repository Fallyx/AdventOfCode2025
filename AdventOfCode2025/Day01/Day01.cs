namespace AdventOfCode2025.Day01;

public class Day01
{
    const string inputPath = @"Day01/Input.txt";

    internal static void Task1() 
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];

        lines.ForEach(i => Console.WriteLine(i));
    }
}
