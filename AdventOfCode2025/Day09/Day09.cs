using System.Numerics;

namespace AdventOfCode2025.Day09;

public class Day09
{
    const string inputPath = @"Day09/Input.txt";

    public static void Task1()
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        List<Vector2> coords = [];
        long largestRectangle = 0;

        foreach (string line in lines)
        {
            int[] tileCoord = [.. line.Split(',').Select(int.Parse)];
            coords.Add(new(tileCoord[0], tileCoord[1]));
        }

        for (int i = 0; i < coords.Count; i++)
        {
            for (int x = i + 1; x < coords.Count; x++)
            {
                long rectangle = ((long) Math.Abs(coords[i].X - coords[x].X) + 1) * ((long) Math.Abs(coords[i].Y - coords[x].Y) + 1);
                if (rectangle > largestRectangle)
                    largestRectangle = rectangle;
            }
        }

        Console.WriteLine($"Task 1: {largestRectangle}");
    }
}
