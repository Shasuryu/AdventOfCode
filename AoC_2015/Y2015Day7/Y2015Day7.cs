using AoCContracts;
using System.Text.RegularExpressions;

namespace AoC_2015.Y2015Day7;
internal class Y2015Day7 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day7/Y2015Day7.txt");
    public string SolveSimple()
    {
        return Calculate(Input, new Dictionary<string, ushort?>()).ToString();
    }

    public string SolveAdvanced()
    {
        return Calculate(Input, new Dictionary<string, ushort?> { { "b", Calculate(Input, new Dictionary<string, ushort?>()) } }).ToString();
    }

    private ushort Calculate(string[] input, Dictionary<string, ushort?> values)
    {
        PrepareValues(values, ref input);
        while (input.Length > 0)
        {
            foreach (var line in input)
            {
                var lineParts = Regex.Split(line, "\\s+").Where(x => x != "->").ToArray();
                if (Regex.IsMatch(line, @"(\w+) AND (\w+) -> (\w+)"))
                {
                    if (!ContainsValues(values, new[] { lineParts[0], lineParts[2] })) continue;
                    values[lineParts[^1]] = (ushort)(values[lineParts[0]] & values[lineParts[2]]);
                    input = input.Where(x => x != line).ToArray();
                }
                else if (Regex.IsMatch(line, @"(\w+) OR (\w+) -> (\w+)"))
                {
                    if (!ContainsValues(values, new[] { lineParts[0], lineParts[2] })) continue;
                    values[lineParts[^1]] = (ushort)(values[lineParts[0]] | values[lineParts[2]]);
                    input = input.Where(x => x != line).ToArray();
                }
                else if (Regex.IsMatch(line, @"(\w+) RSHIFT (\w+) -> (\w+)"))
                {
                    if (!ContainsValues(values, new[] { lineParts[0] })) continue;
                    values[lineParts[^1]] = (ushort)(values[lineParts[0]] >> int.Parse(lineParts[2]));
                    input = input.Where(x => x != line).ToArray();
                }
                else if (Regex.IsMatch(line, @"(\w+) LSHIFT (\w+) -> (\w+)"))
                {
                    if (!ContainsValues(values, new[] { lineParts[0] })) continue;
                    values[lineParts[^1]] = (ushort)(values[lineParts[0]] << int.Parse(lineParts[2]));
                    input = input.Where(x => x != line).ToArray();
                }
                else if (Regex.IsMatch(line, @"NOT (\w+) -> (\w+)"))
                {
                    if (!ContainsValues(values, new[] { lineParts[1] })) continue;
                    values[lineParts[^1]] = (ushort)~values[lineParts[1]];
                    input = input.Where(x => x != line).ToArray();
                }
                else if (Regex.IsMatch(line, @"(\w+) -> (\w+)"))
                {
                    if (!ContainsValues(values, new[] { lineParts[0] })) continue;
                    values[lineParts[^1]] = values[lineParts[0]];
                    input = input.Where(x => x != line).ToArray();
                }
                else if (Regex.IsMatch(line, @"(\w+) -> (\w+)") && Regex.IsMatch(lineParts[0], "^[0-9]"))
                {
                    values[lineParts[^1]] = ushort.Parse(lineParts[0]);
                    input = input.Where(x => x != line).ToArray();
                }
            }
        }
        return (ushort)values["a"]!;
    }

    private void PrepareValues(Dictionary<string, ushort?> values, ref string[] input)
    {
        for (var index = 0; index < input.Length; index++)
        {
            var line = input[index];
            var lineParts = Regex.Split(line, "\\s+").Where(x => x != "->").ToArray();
            foreach (var part in lineParts)
            {
                if (Regex.IsMatch(part, "^[a-z]{1,2}$"))
                {
                    values.TryAdd(part, null);
                }
                else if (Regex.IsMatch(part, "^[0-9]"))
                {
                    values.TryAdd(part, ushort.Parse(part));
                }
            }

            if (lineParts.Length != 2 || !Regex.IsMatch(lineParts[0], "^[0-9]{1,100}$")) continue;
            {
                input = input.Where(x => x != line).ToArray();
                if (ContainsValues(values, new[] {lineParts[1]})) continue;
                values[lineParts[1]] = ushort.Parse(lineParts[0]);
            }
        }
    }

    bool ContainsValues(Dictionary<string, ushort?> dict, IEnumerable<string> keys)
    {
        return !keys.Any(k => !dict.ContainsKey(k) || dict[k] == null);
    }
}