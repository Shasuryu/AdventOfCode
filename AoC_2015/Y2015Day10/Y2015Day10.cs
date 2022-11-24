using System.Text;
using AoCContracts;

namespace AoC_2015.Y2015Day10;
internal class Y2015Day10 : IDaySolver
{
    private static string Input => File.ReadAllText("Y2015Day10/Y2015Day10.txt");
    public string SolveSimple()
    {
        return Lns(40);
    }

    public string SolveAdvanced()
    {
        return Lns(50);
    }

    private static string Lns(int iterations)
    {
        var input = Input;
        for (var iteration = 0; iteration < iterations; iteration++)
        {
            var sb = new StringBuilder();
            var character = input[0];
            var counter = 1;
            for (var index = 1; index < input.Length; index++)
            {
                if (input[index] == character)
                {
                    counter++;
                }
                else
                {
                    sb.Append(counter.ToString());
                    sb.Append(character);
                    character = input[index];
                    counter = 1;
                }
            }

            sb.Append(counter.ToString());
            sb.Append(character);
            input = sb.ToString();
        }

        return input.Length.ToString();
    }
}
