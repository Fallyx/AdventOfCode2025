using System.Numerics;

namespace AdventOfCode2025.Day04;

public class Day04
{
    const string inputPath = @"Day04/Input.txt";

    public static void Task1()
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        Dictionary<Vector2, int> rolls = [];

        for (int y = 0; y < lines.Count; y++)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                if (lines[y][x] == '@')
                    rolls.Add(new(x, y), 0);
            }
        }

        int initRolls = rolls.Count;

        foreach (KeyValuePair<Vector2, int> roll in rolls)
        {
            CountNeighbors((int) roll.Key.X, (int) roll.Key.Y, rolls);
        }

        Console.WriteLine($"Task 1: {rolls.Count(r => r.Value < 4)}");

        int rollsCount;
        do
        {
            rollsCount = rolls.Count;
            rolls = rolls.Where(r => r.Value >= 4).ToDictionary();

            foreach (KeyValuePair<Vector2, int> roll in rolls)
            {
                CountNeighbors((int) roll.Key.X, (int) roll.Key.Y, rolls);
            }

        } while (rollsCount != rolls.Count);

        Console.WriteLine($"Task 2: {initRolls - rolls.Count}");
    }

    private static void CountNeighbors(int x, int y, Dictionary<Vector2, int> rolls)
    {
        rolls[new(x, y)] = 0;

        for (int mY = -1; mY <= 1; mY++)
        {
            for (int mX = -1; mX <= 1; mX++)
            {
                if (mX == 0 && mY == 0) 
                    continue;
                else if (rolls.ContainsKey(new(x + mX, y + mY)))
                    rolls[new(x, y)]++;
            }
        }
    }
}
