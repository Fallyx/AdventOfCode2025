namespace AdventOfCode2025.Day05;

public class Day05
{
    const string inputPath = @"Day05/Input.txt";

    public static void Task1and2()
    {
        List<Range> freshIdRanges = [];
        int amountFreshIds = 0;
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        bool rangeLines = true;

        foreach (string line in lines)
        {
            if (line.Length == 0)
            {
                rangeLines = false;
                continue;
            }
            else if (rangeLines)
            {
                long[] range = [.. line.Split('-').Select(long.Parse)];
                freshIdRanges.Add(new(range[0], range[1]));
            }
            else
            {
                long id = long.Parse(line);
                if (freshIdRanges.Any(f => f.Min <= id && f.Max >= id))
                    amountFreshIds++;
            }
        }

        Console.WriteLine($"Task 1: {amountFreshIds}");

        List<Range> orderedRanges = [.. freshIdRanges.OrderBy(i => i.Min)];
        List<Range> task2Ranges = [orderedRanges.First()];
        int task2RangesIdx = 0;

        for(int i = 1; i < orderedRanges.Count; i++)
        {
            if (task2Ranges[task2RangesIdx].Max >= orderedRanges[i].Min && task2Ranges[task2RangesIdx].Max < orderedRanges[i].Max)
                task2Ranges[task2RangesIdx].Max = orderedRanges[i].Max;
            else if (task2Ranges[task2RangesIdx].Max < orderedRanges[i].Min)
            {
                task2Ranges.Add(orderedRanges[i]);
                task2RangesIdx++;
            }
        }

        Console.WriteLine($"Task 2: {task2Ranges.Sum(i => i.Max - i.Min + 1)}");
    }

    internal record Range(long Min, long Max)
    {
        public long Min {get; set;} = Min;
        public long Max {get; set;} = Max;
    }
}
