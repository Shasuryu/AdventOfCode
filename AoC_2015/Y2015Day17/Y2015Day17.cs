using System.Collections.Immutable;
using AoCContracts;

namespace AoC_2015.Y2015Day17;
internal class Y2015Day17 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day17/Y2015Day17.txt");
    public string SolveSimple()
    {
        var input = Input;
        var containers = input.Select(int.Parse).ToArray();

        var allPermutations = Fill(containers).ToArray();
        return allPermutations.Length.ToString();
    }

    public string SolveAdvanced()
    {
        var input = Input;
        var containers = input.Select(int.Parse).ToArray();

        var allPermutations = Fill(containers).ToArray();
        var minLength = allPermutations.Min(x => x.Count);
        return allPermutations.Count(x => x.Count == minLength).ToString();
    }

    private int GetMinPermutation(List<int> containers, int value)
    {
        var result = 0;
        var minPerms = 0;
        while (result <= value)
        {
            result += containers.Max();
            containers.Remove(containers.Max());
            minPerms++;
        }
        return minPerms;
    }

    private int GetMaxPermutation(List<int> containers, int value)
    {
        var result = 0;
        var maxPerms = 0;
        while (result <= value)
        {
            result += containers.Min();
            containers.Remove(containers.Min());
            maxPerms++;
        }
        return maxPerms;
    }

    private IEnumerable<ImmutableList<int>> Fill(int[] containers)
    {
        return AwesomeRecursion(0, 150);

        IEnumerable<ImmutableList<int>> AwesomeRecursion(int index, int remainingAmount)
        {
            if (index >= containers.Length)
            {
                yield break;
            }
            if (remainingAmount == containers[index])
            {
                yield return ImmutableList.Create(index);
            }
            if (remainingAmount >= containers[index])
            {
                foreach (var list in AwesomeRecursion(index + 1, remainingAmount - containers[index]))
                {
                    yield return list.Add(index);
                }
            }
            foreach (var v in AwesomeRecursion(index + 1, remainingAmount))
            {
                yield return v;
            }
        }
    }

    private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new[] { t2 }));
    }
}
