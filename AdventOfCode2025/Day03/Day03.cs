namespace AdventOfCode2025.Day03;

public class Day03
{
    const string inputPath = @"Day03/Input.txt";
    private static long sumJoltagePart1 = 0;
    private static long sumJoltagePart2 = 0;

    public static void Task1and2()
    {
        List<string> banks = [.. File.ReadAllLines(inputPath)];

        foreach(string bank in banks)
        {
            long joltagePart1 = GetJoltage(bank, 2);
            long joltagePart2 = GetJoltage(bank, 12);

            sumJoltagePart1 += joltagePart1;
            sumJoltagePart2 += joltagePart2;
        }

        Console.WriteLine($"Task 1: {sumJoltagePart1}");
        Console.WriteLine($"Task 2: {sumJoltagePart2}");
    }

    private static long GetJoltage(string bank, int size)
    {
        int bankIdx = 0;
        string joltage = "";

        for (int i = 0; i < size; i++)
        {
            bankIdx = HighestNumInBattery(bank, bankIdx, size - i);
            joltage += bank[bankIdx];
            bankIdx++;
        }

        return long.Parse(joltage);
    }

    private static int HighestNumInBattery(string bank, int startIdx, int size)
    {
        int highestNumIdx = startIdx;

        for (int i = startIdx + 1; i < bank.Length; i++)
        {
            if ((bank.Length - i) < size)
                break;
            else if (bank[i] > bank[highestNumIdx])
                highestNumIdx = i;
        }

        return highestNumIdx;
    }
}
