namespace AdventOfCode2025.Day06;

public class Day06
{
    const string inputPath = @"Day06/Input.txt";

    public static void Task1and2()
    {
        long grandTotalTask1 = 0;
        long grandTotalTask2 = 0;
        Dictionary<int, List<long>> numbers = [];
        List<string> lines = [.. File.ReadAllLines(inputPath)];
        string operationLine = lines.Last();
        int numIdx = 0;
        int opIdx = 0;

        while(opIdx < operationLine.Length)
        {
            int whiteSpaces = operationLine.Skip(opIdx + 1).TakeWhile(c => c == ' ').Count();
            if (opIdx + whiteSpaces == operationLine.Length - 1)
                whiteSpaces++;

            List<string> numStr = [];

            for (int i = 0; i < lines.Count - 1; i++)
                numStr.Add(String.Join("", lines[i].Skip(numIdx).Take(whiteSpaces)));

            if (operationLine[opIdx] == '+')
            {
                grandTotalTask1 += numStr.Select(long.Parse).Sum();
                grandTotalTask2 += CalcTask2(whiteSpaces, numStr, true);
            }
            else if (operationLine[opIdx] == '*')
            {
                grandTotalTask1 += numStr.Select(long.Parse).Aggregate((a, b) => a * b);
                grandTotalTask2 += CalcTask2(whiteSpaces, numStr, false);
            }

            numIdx += whiteSpaces + 1;
            opIdx += whiteSpaces + 1;
        }

        Console.WriteLine($"Task 1: {grandTotalTask1}");
        Console.WriteLine($"Task 2: {grandTotalTask2}");
    }

    private static long CalcTask2(int whiteSpaces, List<string> numStr, bool isAdd)
    {
        long subTot = isAdd ? 0 : 1;
        for (int x = 0; x < whiteSpaces; x++)
        {
            string num = "";
            for (int y = 0; y < numStr.Count; y++)
                num += numStr[y][x];

            if (isAdd)
                subTot += long.Parse(num);
            else
                subTot *= long.Parse(num);
        }

        return subTot;
    }
}
