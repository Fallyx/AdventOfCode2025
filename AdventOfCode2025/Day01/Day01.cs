namespace AdventOfCode2025.Day01;

public class Day01
{
    const string inputPath = @"Day01/Input.txt";
    private static int dial = 50;
    private static int countPoint0Task1 = 0;
    private static int countPoint0Task2 = 0;

    internal static void Task1and2() 
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];

        foreach (string line in lines)
        {
            int rotation = int.Parse(line[1..]);
            rotation *= line[0] == 'L' ? -1 : 1;
            countPoint0Task2 += Math.Abs((dial + rotation) / 100);
            if (dial > 0 && rotation < 0 && (dial + rotation) % 100 <= 0) countPoint0Task2++;
            dial = (dial + rotation % 100 + 100) % 100;
            if (dial == 0) countPoint0Task1++;
        }

        Console.WriteLine($"Task 1: {countPoint0Task1}");
        Console.WriteLine($"Task 2: {countPoint0Task2}");
    }
}
