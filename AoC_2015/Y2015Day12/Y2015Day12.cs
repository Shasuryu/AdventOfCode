using AoCContracts;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace AoC_2015.Y2015Day12;
internal class Y2015Day12 : IDaySolver
{
    private static string Input => File.ReadAllText("Y2015Day12/Y2015Day12.json");
    public string SolveSimple()
    {
        var input = Input;
        var values = JObject.Parse(input)
            .SelectTokens("$..*")
            .Where(t => !t.HasValues)
            .ToDictionary(t => t.Path, t => t.ToString());
        var result = values.Sum(value => Regex.IsMatch(value.Value, "[0-9]") ? int.Parse(value.Value) : 0);
        return result.ToString();
    }

    public string SolveAdvanced()
    {
        var input = Input;
        var values = JObject.Parse(input)
            .SelectTokens("$..*")
            .Where(t => !t.HasValues)
            .ToDictionary(t => t.Path, t => t.ToString());
        var valueWithoutRed = new HashSet<string>();
        foreach (var value in values.Where(value => value.Value == "red" && !value.Key.EndsWith(']')))
        {
            valueWithoutRed.Add(value.Key[..^2]);
        }

        return values
            .Where(x => !valueWithoutRed.Any(n => x.Key.StartsWith(n)) && int.TryParse(x.Value, out _))
            .Sum(x => int.Parse(x.Value))
            .ToString();
    }
}
