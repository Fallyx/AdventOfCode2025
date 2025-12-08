using System.Numerics;

namespace AdventOfCode2025.Day08;

public class Day08
{
    const string inputPath = @"Day08/Input.txt";

    public static void Task1and2()
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        int amountPairsTask1 = 1000;
        List<Vector4> boxes = []; // w = circuit group
        List<Junction> junctions = [];
        int groupCounter = 1;

        foreach(string line in lines)
        {
            int[] coord = [.. line.Split(',').Select(int.Parse)];
            boxes.Add(new(coord[0], coord[1], coord[2], groupCounter++));
        }

        for (int i = 0; i < boxes.Count - 1; i++)
        {
            for (int x = i + 1; x < boxes.Count; x++)
                junctions.Add(new(i, x, Distance(boxes[i], boxes[x])));
        }

        junctions = [.. junctions.OrderBy(d => d.Distance)];
        int counter = -1;

        while (true)
        {
            counter++;
            List<int> junctionSize = [.. boxes.GroupBy(b => b.W).OrderByDescending(s => s.Count()).Select(s => s.Count())];

            if (counter == amountPairsTask1)
                Console.WriteLine($"Task 1: {junctionSize[0] * junctionSize[1] * junctionSize[2]}");

            Junction current = junctions[counter];
            Vector4 a = boxes[current.A];
            Vector4 b = boxes[current.B];

            if (junctionSize.Count == 2 && a.W != b.W)
            {
                Console.WriteLine($"Task 2: {(long) a.X * (long) b.X}");
                break;
            }

            int newGroup = (int) a.W;
            int oldGroup = (int) b.W;

            if (newGroup == oldGroup)
                continue;

            for(int x = 0; x < boxes.Count; x++)
            {
                if (boxes[x].W == oldGroup)
                {
                    Vector4 update = boxes[x];
                    update.W = newGroup;
                    boxes[x] = update;
                }
            }
        }
    }

    private static double Distance(Vector4 start, Vector4 end)
    {
        return Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.Z - start.Z, 2));
    }

    private record Junction(int A, int B, double Distance);
}
