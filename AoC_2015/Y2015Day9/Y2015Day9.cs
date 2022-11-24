using AoCContracts;

namespace AoC_2015.Y2015Day9;
internal class Y2015Day9 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day9/Y2015Day9.txt");
    private static HashSet<int> AllRouteDistances = GetDistance();
    public string SolveSimple()
    {
        return AllRouteDistances.Min().ToString();
    }

    public string SolveAdvanced()
    {
        return AllRouteDistances.Max().ToString();
    }

    private static HashSet<int> GetDistance()
    {
        var input = Input;
        var distance = new HashSet<Route>();
        var places = new HashSet<string>();
        foreach (var line in input)
        {
            var linePart = line.Split(" to ");
            var secondLinePart = linePart[1].Split(" = ");
            distance.Add(new Route(linePart[0], secondLinePart[0], int.Parse(secondLinePart[1])));

            places.Add(linePart[0]);
            places.Add(secondLinePart[0]);
        }

        var possibleRoutes = GetPermutations(places, places.Count).Select(x => x.ToArray()).ToArray();
        var result = new HashSet<int>();
        foreach (var route in possibleRoutes)
        {
            var currentDistance = 0;
            for (var i = 0; i < route.Length - 1; i++)
            {
                currentDistance += distance.First(x => x.linkedDestinations == new LinkedDestinations(route[i], route[i + 1])).Distance;
            }
            result.Add(currentDistance);
        }
        return result;
    }

    private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }

    private record struct Route
    {
        public LinkedDestinations linkedDestinations;
        public int Distance;

        public Route(string p1, string p2, int distance)
        {
            linkedDestinations = new LinkedDestinations(p1, p2);
            Distance = distance;
        }
    }

    private record struct LinkedDestinations
    {
        public string P1;
        public string P2;

        public LinkedDestinations(string p1, string p2)
        {
            var places = new[] { p1, p2 }.OrderBy(x => x).ToArray();
            P1 = places[0];
            P2 = places[1];
        }
    }
}
