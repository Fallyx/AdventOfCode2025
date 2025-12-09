using System.Numerics;

namespace AdventOfCode2025.Day09;

public class Day09
{
    const string inputPath = @"Day09/Input.txt";

    public static void Task1and2()
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        List<Vector2> coords = [];
        long largestRectangleTask1 = 0;
        long largestRectangleTask2 = 0;

        foreach (string line in lines)
        {
            int[] tileCoord = [.. line.Split(',').Select(int.Parse)];
            coords.Add(new(tileCoord[0], tileCoord[1]));
        }

        for (int i = 0; i < coords.Count - 1; i++)
        {
            for (int j = i + 1; j < coords.Count; j++)
            {
                long rectangle = ((long) Math.Abs(coords[i].X - coords[j].X) + 1) * ((long) Math.Abs(coords[i].Y - coords[j].Y) + 1);
                if (rectangle > largestRectangleTask1)
                    largestRectangleTask1 = rectangle;

                if (rectangle > largestRectangleTask2)
                {
                    bool intersect = false;
                    for (int a = 0; a < coords.Count; a++)
                    {
                        int b = ((a + 1) % coords.Count + coords.Count) % coords.Count;
                        intersect = DoesIntersect(coords[i], coords[j], coords[a], coords[b]);
                        if (intersect)
                            break;
                    }

                    if (!intersect)
                        largestRectangleTask2 = rectangle;
                }
            }
        }

        Console.WriteLine($"Task 1: {largestRectangleTask1}");
        Console.WriteLine($"Task 2: {largestRectangleTask2}");
    }

    private static bool DoesIntersect(Vector2 p1Start, Vector2 p1End, Vector2 p2Start, Vector2 p2End)
    {
        float p1MinX = Math.Min(p1Start.X, p1End.X) + 1;
        float p1MaxX = Math.Max(p1Start.X, p1End.X) - 1;
        float p1MinY = Math.Min(p1Start.Y, p1End.Y) + 1;
        float p1MaxY = Math.Max(p1Start.Y, p1End.Y) - 1;

        if (p2Start.X == p2End.X)
            return !(p2Start.X < p1MinX || p2Start.X > p1MaxX || (p2Start.Y < p1MinY && p2End.Y < p1MinY) || (p2Start.Y > p1MaxY && p2End.Y > p1MaxY));
        else if (p2Start.Y == p2End.Y)
            return !(p2Start.Y < p1MinY || p2Start.Y > p1MaxY || (p2Start.X < p1MinX && p2End.X < p1MinX) || (p2Start.X > p1MaxX && p2End.X > p1MaxX));
        return false;
    }
}
