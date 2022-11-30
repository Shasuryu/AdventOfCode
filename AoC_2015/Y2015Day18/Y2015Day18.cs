using System.Linq;
using System.Text;
using AoCContracts;

namespace AoC_2015.Y2015Day18;
internal class Y2015Day18 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day18/Y2015Day18.txt");
    public string SolveSimple()
    {
        var input = Input;

        var tmp = CreateArrays(input, out var tmp2);

        foreach (var iterations in Enumerable.Range(0, 100))
        {
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    var combinations = new[] {new[] {i + 1, j}, new[] {i + 1, j + 1}, new[] {i, j + 1}, new[] {i - 1, j + 1}, new[] {i - 1, j}, new[] {i - 1, j - 1}, new[] {i, j - 1}, new[] {i + 1, j - 1}};

                    var count = combinations.Where(combination => combination[0] >= 0 && combination[0] < 100).Where(combination => combination[1] >= 0 && combination[1] < 100).Count(combination => tmp[combination[0], combination[1]]);

                    SetLight(tmp, i, j, count, tmp2);
                }
            }
            Array.Copy(tmp2, tmp, tmp2.Length);
        }

        var counter = CountLights(tmp);
        return counter.ToString();
    }

    public string SolveAdvanced()
    {
        var input = Input;

        var tmp = CreateArrays(input, out var tmp2);

        foreach (var position in new[]{(0,0),(0,99),(99,0),(99,99)})
        {
            tmp[position.Item1, position.Item2] = true;
            tmp2[position.Item1, position.Item2] = true;
        }

        foreach (var iterations in Enumerable.Range(0, 100))
        {
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    var combinations = new[] {new[] {i + 1, j}, new[] {i + 1, j + 1}, new[] {i, j + 1}, new[] {i - 1, j + 1}, new[] {i - 1, j}, new[] {i - 1, j - 1}, new[] {i, j - 1}, new[] {i + 1, j - 1}};

                    var count = combinations.Where(combination => combination[0] >= 0 && combination[0] < 100).Where(combination => combination[1] >= 0 && combination[1] < 100).Count(combination => tmp[combination[0], combination[1]]);

                    if ((i, j) == (0, 0) || (i, j) == (0, 99) || (i, j) == (99, 0) || (i, j) == (99, 99))
                    {
                        continue;
                    }
                    
                    SetLight(tmp, i, j, count, tmp2);
                }
            }
            Array.Copy(tmp2, tmp, tmp2.Length);
        }

        var counter = CountLights(tmp);
        return counter.ToString();
    }

    private static bool[,] CreateArrays(string[] input, out bool[,] tmp2)
    {
        var tmp = new bool[100, 100];
        tmp2 = new bool[100, 100];

        for (var i = 0; i < 100; i++)
        for (var j = 0; j < 100; j++)
        {
            if (input[i][j] != '#') continue;
            tmp[i, j] = true;
            tmp2[i, j] = true;
        }

        return tmp;
    }

    private static void SetLight(bool[,] tmp, int i, int j, int count, bool[,] tmp2)
    {
        if (tmp[i, j] && count is 2 or 3)
        {
            tmp2[i, j] = true;
        }
        if (tmp[i, j] && count is not (2 or 3))
        {
            tmp2[i, j] = false;
        }
        if (tmp[i, j] == false && count == 3)
        {
            tmp2[i, j] = true;
        }
        if (tmp[i, j] == false && count != 3)
        {
            tmp2[i, j] = false;
        }
    }

    private static int CountLights(bool[,] tmp)
    {
        var counter = 0;
        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j < 100; j++)
            {
                if (tmp[i, j])
                {
                    counter++;
                }
            }
        }
        return counter;
    }
}