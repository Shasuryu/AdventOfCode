using System.Globalization;
using AoCContracts;

namespace AoC_2015.Y2015Day6;
internal class Y2015Day6 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day6/Y2015Day6.txt");
    private string[] input = Input;
    public string SolveSimple()
    {
        var lights = new bool[1000, 1000];
        foreach (var line in input)
        {
            if (line.StartsWith("turn on"))
            {
                GetNumbers(lights, line.Substring(8).Split(',', ' '), true);
            }
            if (line.StartsWith("turn off"))
            {
                GetNumbers(lights, line.Substring(9).Split(',', ' '), false);
            }
            if (line.StartsWith("toggle"))
            {
                GetNumbers(lights, line.Substring(7).Split(',', ' '));
            }
        }
        return lights.Cast<bool>().Count(l => l == true).ToString();
    }

    private static void GetNumbers(bool[,] lights, string[] line, bool instruction)
    {
        var numbers = new[] { int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[3]), int.Parse(line[4]) };
        for (var i = numbers[0]; i <= numbers[2]; i++)
        for (var j = numbers[1]; j <= numbers[3]; j++)
        {
            lights[i, j] = instruction;
        }
    }

    private static void GetNumbers(bool[,] lights, string[] line)
    {
        var numbers = new[] { int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[3]), int.Parse(line[4]) };
        for (var i = numbers[0]; i <= numbers[2]; i++)
        for (var j = numbers[1]; j <= numbers[3]; j++)
        {
            lights[i, j] = !lights[i, j];
        }
    }

    public string SolveAdvanced()
    {
        var lights = new int[1000, 1000];
        foreach (var line in input)
        {
            if (line.StartsWith("turn on"))
            {
                lights = GetNumbers(lights, line.Substring(8).Split(',', ' '), 1);
            }
            if (line.StartsWith("turn off"))
            {
                lights = GetNumbers(lights, line.Substring(9).Split(',', ' '), -1);
            }
            if (line.StartsWith("toggle"))
            {
                lights = GetNumbers(lights, line.Substring(7).Split(',', ' '), 2);
            }
        }
        return lights.Cast<int>().Sum().ToString();
    }

    private static int[,] GetNumbers(int[,] lights, string[] line, int add)
    {
        var numbers = new[] { int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[3]), int.Parse(line[4]) };
        for (var i = numbers[0]; i <= numbers[2]; i++)
        for (var j = numbers[1]; j <= numbers[3]; j++)
        {
            if (!(add == -1 && lights[i, j] == 0))
            {
                lights[i, j] += add;
            }
        }
        return lights;
    }
}
