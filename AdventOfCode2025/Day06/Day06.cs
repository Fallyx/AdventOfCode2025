namespace AdventOfCode2025.Day06;

public class Day06
{
    const string inputPath = @"Day06/Input.txt";

    public static void Task1()
    {
        long grandTotalTask1 = 0;
        Dictionary<int, List<long>> numbers = [];
        List<string> lines = [.. File.ReadAllLines(inputPath)];

        for (int i = 0; i < lines.Count; i++)
        {
            string[] problems = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (lines[i][0] == '+' || lines[i][0] == '*')
            {
                for (int x = 0; x < problems.Length; x++)
                {
                    if (problems[x] == "+")
                        grandTotalTask1 += numbers[x].Sum();
                    else if (problems[x] == "*")
                        grandTotalTask1 += numbers[x].Aggregate((a, b) => a * b);
                }
            }
            else
            {
                for (int x = 0; x < problems.Length; x++)
                {
                    if (numbers.TryGetValue(x, out List<long>? value))
                        value.Add(long.Parse(problems[x]));
                    else
                       numbers.Add(x, [long.Parse(problems[x])]); 
                }
            }
        }

        Console.WriteLine($"Task 1: {grandTotalTask1}");
    }
}
