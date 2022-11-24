using AoCContracts;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace AoC_2015.Y2015Day4;

internal class Y2015Day4 : IDaySolver
{
    private static string Input => File.ReadAllText("Y2015Day4/Y2015Day4.txt");

    public string SolveSimple()
    {
        return GetHashed(Input, "00000");
    }

    public string SolveAdvanced()
    {
        return GetHashed(Input, "000000");
    }

    private string GetHashed(string input, string prefix)
    {
        var index = new ConcurrentQueue<int>();

        Parallel.ForEach(Enumerable.Range(0, int.MaxValue), () => MD5.Create(), (i, state, md5) =>
            {
                var inputBytes = System.Text.Encoding.ASCII.GetBytes(input + i);
                var hashString = Convert.ToHexString(md5.ComputeHash(inputBytes));

                if (!hashString.StartsWith(prefix)) return md5;
                index.Enqueue(i);
                state.Stop();
                return md5;
            },
            _ => { }
        );
        return index.Min().ToString();
    }
}