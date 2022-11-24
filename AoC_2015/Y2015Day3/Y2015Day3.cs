using AoCContracts;

namespace AoC_2015.Y2015Day3;
internal class Y2015Day3 : IDaySolver
{
    private static string Input => File.ReadAllText("Y2015Day3/Y2015Day3.txt");
    private string input = Input;

    public string SolveSimple()
    {
        var i = 0;
        var j = 0;
        List<Position> allPositions = new List<Position>();
        foreach (var c in input)
        {
            switch (c)
            {
                case '<':
                    i++;
                    break;
                case '>':
                    i--;
                    break;
                case 'v':
                    j--;
                    break;
                case '^':
                    j++;
                    break;
            }
            allPositions.Add(new Position(i, j));
        }
        allPositions.Add(new Position(0, 0));
        return allPositions.Distinct().Count().ToString();
    }

    public string SolveAdvanced()
    {
        var i = 0;
        var j = 0;
        var k = 0;
        var l = 0;
        var m = 0;
        List<Position> allPositions = new List<Position>();
        foreach (var c in input)
        {
            if (m % 2 == 0)
            {
                switch (c)
                {
                    case '<':
                        i++;
                        break;
                    case '>':
                        i--;
                        break;
                    case 'v':
                        j--;
                        break;
                    case '^':
                        j++;
                        break;
                }
                allPositions.Add(new Position(i, j));
            }
            else
            {
                switch (c)
                {
                    case '<':
                        k++;
                        break;
                    case '>':
                        k--;
                        break;
                    case 'v':
                        l--;
                        break;
                    case '^':
                        l++;
                        break;
                }
                allPositions.Add(new Position(k, l));
            }
            m++;
        }
        allPositions.Add(new Position(0, 0));
        return allPositions.Distinct().Count().ToString();
    }

    public struct Position
    {
        public int I;
        public int J;

        public Position(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
