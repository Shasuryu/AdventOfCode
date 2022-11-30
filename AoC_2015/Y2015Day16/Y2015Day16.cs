using AoCContracts;

namespace AoC_2015.Y2015Day16;
internal class Y2015Day16 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day16/Y2015Day16.txt");

    public string SolveSimple()
    {
        var input = Input;
        var aunts = GetAunts();
        var ogSue = new[] { 3, 7, 2, 3, 0, 0, 5, 3, 2, 1 };
        FillAunts(input, aunts);

        //Same as line 21 - 29
        return (aunts.IndexOf(
            aunts.First(aunt =>
                !aunt.Where((value, index) => value != -1 && value != ogSue[index])
                    .Any())) + 1).ToString();

        //for (var i = 0; i < aunts.Count; i++)
        //{
        //    var correctSue = !ogSue.Where((t, j) => aunts[i][j] != -1 && aunts[i][j] != t).Any();
        //    if (correctSue)
        //    {
        //        return (i + 1).ToString();
        //    }
        //}
        //return "";
    }

    public string SolveAdvanced()
    {
        var input = Input;
        var aunts = GetAunts();
        var ogSue = new[] { 3, 7, 2, 3, 0, 0, 5, 3, 2, 1 };
        FillAunts(input, aunts);

        for (var i = 0; i < aunts.Count; i++)
        {
            var correctSue = true;
            for (var j = 0; j < ogSue.Length; j++)
            {
                if (aunts[i][j] == -1) continue;
                var isCorrect = j switch
                {
                    1 => aunts[i][j] > ogSue[j],
                    7 => aunts[i][j] > ogSue[j],
                    3 => aunts[i][j] < ogSue[j],
                    6 => aunts[i][j] < ogSue[j],
                    _ => aunts[i][j] == ogSue[j]
                };

                if (isCorrect) continue;
                correctSue = false;
                break;
            }
            if (correctSue)
            {
                return (i + 1).ToString();
            }
        }
        return "";
    }

    private static List<List<int>> GetAunts()
    {
        var aunts = new List<List<int>>();
        for (var i = 0; i < 500; i++)
        {
            aunts.Add(new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
        }
        return aunts;
    }

    private void FillAunts(string[] input, List<List<int>> aunts)
    {
        foreach (var line in input)
        {
            var split = line.Split(' ');
            var indexes = GetIndexes(new[] { split[2][..^1], split[4][..^1], split[6][..^1] });
            aunts[int.Parse(split[1][..^1]) - 1][indexes[0]] = int.Parse(split[3][..^1]);
            aunts[int.Parse(split[1][..^1]) - 1][indexes[1]] = int.Parse(split[5][..^1]);
            aunts[int.Parse(split[1][..^1]) - 1][indexes[2]] = int.Parse(split[7]);
        }
    }

    private List<int> GetIndexes(string[] line)
    {
        var indexes = new List<int>();
        foreach (var attribute in line)
        {
            switch (attribute)
            {
                case "children":
                    indexes.Add(0);
                    break;
                case "cats":
                    indexes.Add(1);
                    break;
                case "samoyeds":
                    indexes.Add(2);
                    break;
                case "pomeranians":
                    indexes.Add(3);
                    break;
                case "akitas":
                    indexes.Add(4);
                    break;
                case "vizslas":
                    indexes.Add(5);
                    break;
                case "goldfish":
                    indexes.Add(6);
                    break;
                case "trees":
                    indexes.Add(7);
                    break;
                case "cars":
                    indexes.Add(8);
                    break;
                case "perfumes":
                    indexes.Add(9);
                    break;
            }
        }
        return indexes;
    }
}
