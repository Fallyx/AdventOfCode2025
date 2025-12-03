using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day02;

public class Day02
{
    const string inputPath = @"Day02/Input.txt";
    private static long sumInvalidIdsPart1 = 0;
    private static long sumInvalidIdsPart2 = 0;

    internal static void Task1and2()
    {
        List<string> productIdRanges = [.. File.ReadLines(inputPath).First().Split(',')];

        foreach (string range in productIdRanges)
        {
            string[] bounds = range.Split('-');
            long lower = long.Parse(bounds[0]);
            long upper = long.Parse(bounds[1]);

            for(long i = lower; i<= upper; i++)
            {
                string num = i.ToString();
                string left = num[.. (num.Length / 2)];
                string right = num[(num.Length / 2) ..];

                if (left == right)
                    sumInvalidIdsPart1 += i;

                for (int x = 1; x <= num.Length / 2; x++)
                {
                    List<string> nums = [.. Regex.Matches(num, ".{1," + x + "}").Cast<Match>().Select(m => m.Value)];

                    if (nums.All(n => n == nums[0]))
                    {
                        sumInvalidIdsPart2 += i;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"Task 1: {sumInvalidIdsPart1}");
        Console.WriteLine($"Task 2: {sumInvalidIdsPart2}");
    }
}
