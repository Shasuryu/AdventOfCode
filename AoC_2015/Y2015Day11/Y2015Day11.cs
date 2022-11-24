using AoCContracts;

namespace AoC_2015.Y2015Day11;
internal class Y2015Day11 : IDaySolver
{
    private static string Input => File.ReadAllText("Y2015Day11/Y2015Day11.txt");
    private string newInput = "";
    public string SolveSimple()
    {
        var input = Input;
        var password = input.Reverse().ToArray();
        do
        {
            AwesomeRecursion(ref password, 0);
            input = new string(password.Reverse().ToArray());
        } while (!(ContainsAscendingLetters(input) && NotContainIOL(input) && ContainsLetterPair(input)));

        newInput = input;
        return input;
    }

    public string SolveAdvanced()
    {
        var input = newInput;
        var password = input.Reverse().ToArray();
        do
        {
            AwesomeRecursion(ref password, 0);
            input = new string(password.Reverse().ToArray());
        } while (!(ContainsAscendingLetters(input) && NotContainIOL(input) && ContainsLetterPair(input)));

        return input;
    }

    private bool ContainsLetterPair(string input)
    {
        return "abcdefghijklmnopqrstuvwxyz".Count(letter => input.Contains(letter + letter.ToString())) >= 2;
    }

    private bool NotContainIOL(string input)
    {
        return !input.Contains('i') && (!input.Contains('o') && !input.Contains('l'));
    }

    private bool ContainsAscendingLetters(string input)
    {
        var numberInput = input.Select(x => (int)x).ToArray();
        for (var i = 0; i < numberInput.Length - 2; i++)
        {
            if (numberInput[i] + 1 == numberInput[i + 1] && numberInput[i] + 2 == numberInput[i + 2])
            {
                return true;
            }
        }
        return false;
    }

    private void AwesomeRecursion(ref char[] input, int i)
    {
        input[i] = (char)(((int)input[i]) + 1);
        if (input[i] == '{')
        {
            input[i] = 'a';
            AwesomeRecursion(ref input, i + 1);
        }
    }
}
