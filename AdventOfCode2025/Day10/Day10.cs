using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day10;

public partial class Day10
{
    const string inputPath = @"Day10/Input.txt";

    public static void Task1()
    {
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        int buttonPressesTask1 = 0;

        foreach (string line in lines)
        {
            MatchCollection mc = LineRegex().Matches(line);
            string lightDiagram = mc[0].Value[1 .. ^1];
            int[] joltageReq = [.. mc[^1].Value[1 .. ^1].Split(',').Select(int.Parse)];
            List<int>[] buttons = new List<int>[mc.Count - 2];
            string startLight = new('.', lightDiagram.Length);
            Dictionary<string, int> paths = new()
            {
                { startLight, 0 }
            };

            for (int i = 1; i < mc.Count - 1; i++)
                buttons[i - 1] = [.. mc[i].Value[1 .. ^1].Split(',').Select(int.Parse).Order()];

            LightButtonPresses(startLight, paths, buttons);

            buttonPressesTask1 += paths[lightDiagram];
        }

        Console.WriteLine($"Task 1: {buttonPressesTask1}");
    }

    private static void LightButtonPresses(String startLight, Dictionary<String, int> paths, List<int>[] buttons)
    {
        Queue<string> queue = new();
        queue.Enqueue(startLight);

        while (queue.Count > 0)
        {
            string currentLight = queue.Dequeue();
            int newScore = paths[currentLight] + 1;

            for (int i = 0; i < buttons.Length; i++)
            {
                StringBuilder sb = new();
                int buttonsIdx = 0;
                for (int x = 0; x < currentLight.Length; x++)
                {
                    if (buttonsIdx < buttons[i].Count && x == buttons[i][buttonsIdx])
                    {
                        sb.Append(currentLight[x] == '.' ? '#' : '.');
                        buttonsIdx++;
                    }
                    else
                        sb.Append(currentLight[x]);
                }

                string newLight = sb.ToString();

                if (paths.TryAdd(newLight, newScore))
                    queue.Enqueue(newLight);
                else if (paths[newLight] > newScore)
                {
                    paths[newLight] = newScore;
                    queue.Enqueue(newLight);
                }
            }
        }
    }

    [GeneratedRegex(@"(\[[\.#]+\]|\((\d,?)+\)|{(\d,?)+})")]
    private static partial Regex LineRegex();
}
