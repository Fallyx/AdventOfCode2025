using System.Numerics;

namespace AdventOfCode2025.Day07;

public class Day07
{
    const string inputPath = @"Day07/Input.txt";

    public static void Task1()
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        int yMax = lines.Count;
        int xMax = lines[0].Length;
        HashSet<Vector2> beams = [new(lines[0].IndexOf('S'), 0)];
        HashSet<Vector2> splitters = [];

        for (int y = 1; y < yMax; y++)
        {
            HashSet<Vector2> nextBeams = [];

            foreach(Vector2 currentBeam in beams)
            {
                if (lines[y][(int)currentBeam.X] == '^')
                {
                    splitters.Add(new(currentBeam.X, y));
                    if (currentBeam.X - 1 >= 0)
                        nextBeams.Add(new(currentBeam.X - 1, y));
                    if (currentBeam.X + 1 < xMax)
                        nextBeams.Add(new(currentBeam.X + 1, y));
                }
                else
                {
                    nextBeams.Add(new(currentBeam.X, y));
                }
            }

            beams = nextBeams;
        }

        Console.WriteLine($"Task 1: {splitters.Count}");
    }

    private record Splitter(Vector2 Pos, bool Used = false)
    {
        public Vector2 Pos { get; set; } = Pos;
        public bool Used { get; set; } = Used;
    }
}
