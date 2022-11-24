using System.Text.RegularExpressions;
using AoCContracts;

namespace AoC_2015.Y2015Day8;
internal class Y2015Day8 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day8/Y2015Day8.txt");
    public string SolveSimple()
    {
        var input = Input;
        var character = 0;
        foreach (var line in input)
        {
            character += line.Length - Regex.Unescape(line.Substring(1, line.Length - 2)).Length;
        }
        return character.ToString();
    }



    public string SolveAdvanced()
    {
        var input = Input;
        var character = 0;
        foreach (var line in input)
        {
            character += ("\"" + Regex.Escape(line).Replace("\"", "\\\"") + "\"").Length - line.Length;
        }
        return character.ToString();
    }
}
