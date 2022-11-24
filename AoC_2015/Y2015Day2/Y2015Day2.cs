using AoCContracts;

namespace AoC_2015.Y2015Day2;

public class Y2015Day2 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day2/Y2015Day2.txt");

    public string SolveSimple()
    {
        var totalNeed = 0;
        foreach (var line in Input)
        {
            var stringLine = line.Split('x');
            var l = Array.ConvertAll(stringLine, s => int.Parse(s));
            l = l.OrderBy(x => x).ToArray();
            var s1 = l[0] * l[1] * 2;
            var s2 = l[1] * l[2] * 2;
            var s3 = l[0] * l[2] * 2;

            totalNeed += s1 + s2 + s3 + l[0] * l[1];
        }
        return totalNeed.ToString();
    }

    public string SolveAdvanced()
    {
        var totalNeed = 0;
        foreach (var line in Input)
        {
            var stringLine = line.Split('x');
            var l = Array.ConvertAll(stringLine, s => int.Parse(s));
            l = l.OrderBy(x => x).ToArray();
            var s1 = l[0] + l[0] + l[1] + l[1];
            var s2 = l[0] * l[1] * l[2];

            totalNeed += s1 + s2;
        }
        return totalNeed.ToString();
    }
}
