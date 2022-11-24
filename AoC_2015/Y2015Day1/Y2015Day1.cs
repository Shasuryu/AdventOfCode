using AoCContracts;

namespace AoC_2015.Y2015Day1;

public class Y2015Day1 : IDaySolver
{
    private static string Input => File.ReadAllText("Y2015Day1/Y2015Day1.txt");
    public string SolveSimple()
    {
        var i = 0;
        foreach (var c in Input)
        {
            if (c == '(')
            {
                i++;
            }
            else
            {
                i--;
            }
        }

        return i.ToString();
    }

    public string SolveAdvanced()
    {
        var i = 0;
        for (var index = 0; index < Input.Length; index++)
        {
            var c = Input[index];
            if (c == '(')
            {
                i++;
            }
            else
            {
                i--;
            }

            if (i != -1) continue;
            return (index + 1).ToString();
        }
        return "";
    }
}