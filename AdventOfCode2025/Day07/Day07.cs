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
        HashSet<Vector2> splitters = [];
        Dictionary<Vector2, long> beams = new()
        {
            { new(lines[0].IndexOf('S'), 0), 1 }
        };

        for (int y = 1; y < yMax; y++)
        {
            Dictionary<Vector2, long> nextBeams = [];
            foreach(KeyValuePair<Vector2, long> currentBeam in beams)
            {
                if (lines[y][(int)currentBeam.Key.X] == '^')
                {
                    splitters.Add(new(currentBeam.Key.X, y));
                    if (currentBeam.Key.X - 1 >= 0)
                    {
                        Vector2 newBeamPos = new(currentBeam.Key.X - 1, y);
                        if (nextBeams.ContainsKey(newBeamPos))
                            nextBeams[newBeamPos] += currentBeam.Value;
                        else
                            nextBeams.Add(newBeamPos, currentBeam.Value);
                    }
                    if (currentBeam.Key.X + 1 < xMax)
                    {
                        Vector2 newBeamPos = new(currentBeam.Key.X + 1, y);
                        if (nextBeams.ContainsKey(newBeamPos))
                            nextBeams[newBeamPos] += currentBeam.Value;
                        else
                            nextBeams.Add(newBeamPos, currentBeam.Value);
                    }
                }
                else
                {
                    Vector2 newBeamPos = new(currentBeam.Key.X, y);
                    if (nextBeams.ContainsKey(newBeamPos))
                        nextBeams[newBeamPos] += currentBeam.Value;
                    else
                        nextBeams.Add(newBeamPos, currentBeam.Value);
                }
            }

            beams = nextBeams;
        }

        Console.WriteLine($"Task 1: {splitters.Count}");
        Console.WriteLine($"Task 2: {beams.Where(b => b.Key.Y == yMax - 1).Sum(b => b.Value)}");
    }

    private record Splitter(Vector2 Pos, bool Used = false)
    {
        public Vector2 Pos { get; set; } = Pos;
        public bool Used { get; set; } = Used;
    }
}
