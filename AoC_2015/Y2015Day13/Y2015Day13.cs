using AoCContracts;
using System.Diagnostics;

namespace AoC_2015.Y2015Day13;
internal class Y2015Day13 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day13/Y2015Day13.txt");
    private static string[][]? _allRouteDistances;
    public string SolveSimple()
    {
        var input = Input;
        var relations = new HashSet<Relations>();
        var guests = new HashSet<string>();
        foreach (var line in input)
        {
            var split = line.Split(' ');
            relations.Add(new Relations(split[0], split[^1][..^1], int.Parse(split[3]) * (split[2] == "gain" ? 1 : -1)));
            guests.Add(split[0]);
        }
        _allRouteDistances = GetPermutations(guests, guests.Count).Select(x => x.ToArray()).ToArray();
        return GetResult(guests, relations, false);
    }

    public string SolveAdvanced()
    {
        var input = Input;
        var relations = new HashSet<Relations>();
        var guests = new HashSet<string>();
        foreach (var line in input)
        {
            var split = line.Split(' ');
            relations.Add(new Relations(split[0], split[^1][..^1], int.Parse(split[3]) * (split[2] == "gain" ? 1 : -1)));
            guests.Add(split[0]);
        }
        return GetResult(guests, relations, true);
    }
    
    private static string GetResult(HashSet<string> guests, HashSet<Relations> relations, bool addMyself)
    {
        var result = new HashSet<int>();
        foreach (var route in _allRouteDistances)
        {
            var happiness = 0;
            for (var i = 0; i < route.Length - 1; i++)
            {
                happiness += relations.Where(x => x.Couple == new Participants(route[i], route[i + 1]))
                    .Sum(x => x.Value);
            }
            if (!addMyself)
            {
                happiness += relations.Where(x => x.Couple == new Participants(route[0], route[^1])).Sum(x => x.Value);
            }
            result.Add(happiness);
        }

        return result.Max().ToString();
    }

    private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }

    private record struct Relations
    {
        public Participants Couple;
        public int Value;

        public Relations(string p1, string p2, int value)
        {
            Couple = new Participants(p1, p2);
            Value = value;
        }
    }

    private record struct Participants
    {
        public string P1;
        public string P2;

        public Participants(string p1, string p2)
        {
            var places = new[] { p1, p2 }.OrderBy(x => x).ToArray();
            P1 = places[0];
            P2 = places[1];
        }
    }
}
