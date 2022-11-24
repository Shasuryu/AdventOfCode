using AoCContracts;

namespace AoC_2015.Y2015Day5;
internal class Y2015Day5 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day5/Y2015Day5.txt");
    private static string Letters = "abcdefghijklmnopqrstuvwxyz";
    public string SolveSimple()
    {
        var goodStrings = 0;
        foreach (var line in Input)
        {
            var vowels = 0;
            var vowel = false;
            var contain = false;

            var doubleLetter = Letters.Any(letter => line.Contains(letter + letter.ToString()));

            foreach (var letter in "aeiou")
            {
                vowels += line.Count(c => c == letter);

                if (vowels >= 3)
                {
                    vowel = true;
                }
            }

            if (!(line.Contains("ab") || line.Contains("cd") || line.Contains("pq") || line.Contains("xy")))
            {
                contain = true;
            }

            if (doubleLetter && vowel && contain)
            {
                goodStrings++;
            }
        }
        return goodStrings.ToString();
    }

    public string SolveAdvanced()
    {
        var goodStrings = 0;
        foreach (var line in Input)
        {
            var twoLetter = false;
            var contain = false;

            foreach (var letter in Letters)
            {
                foreach (var let in Letters)
                {
                    if (line.Contains(letter.ToString() + let.ToString() + letter.ToString()))
                    {
                        contain = true;
                        break;
                    }
                }
            }

            twoLetter = Enumerable.Range(0, line.Length - 1).Any(i => line.IndexOf(line.Substring(i, 2), i + 2) >= 0);

            if (twoLetter && contain)
            {
                goodStrings++;
            }
        }
        return goodStrings.ToString();
    }
}
