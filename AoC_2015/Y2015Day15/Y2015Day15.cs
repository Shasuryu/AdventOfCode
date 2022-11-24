using System.Diagnostics;
using AoCContracts;

namespace AoC_2015.Y2015Day15;
internal class Y2015Day15 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day15/Y2015Day15.txt");
    public string SolveSimple()
    {
        var input = Input;
        var ingredients =
            input.Select(line => line.Split(' '))
                .Select(split => new Ingredient(
                    int.Parse(split[2][..^1]),
                    int.Parse(split[4][..^1]),
                    int.Parse(split[6][..^1]),
                    int.Parse(split[8][..^1]),
                    int.Parse(split[10])))
                .ToList();

        var spoonCount = GetHighestScore(ingredients);

        return GetScore(ingredients, spoonCount).ToString();
    }

    public string SolveAdvanced()
    {
        var input = Input;
        var ingredients =
            input.Select(line => line.Split(' '))
                .Select(split => new Ingredient(
                    int.Parse(split[2][..^1]),
                    int.Parse(split[4][..^1]),
                    int.Parse(split[6][..^1]),
                    int.Parse(split[8][..^1]),
                    int.Parse(split[10])))
                .ToList();

        var spoonations = Partition(100, 4)
            .Where(x => CalculateCalories(ingredients, x.ToArray()) == 500);

        return spoonations.Select(x => GetScore(ingredients, x.ToArray())).Max().ToString();
    }

    private IEnumerable<int[]> Partition(int n, int k)
    {
        if (k == 1)
        {
            yield return new int[] { n };
        }
        else
        {
            for (var i = 0; i <= n; i++)
            {
                foreach (var rest in Partition(n - i, k - 1))
                {
                    yield return rest.Select(x => x).Append(i).ToArray();
                }
            }
        }
    }

    private int CalculateCalories(List<Ingredient> ingredients, int[] spoonCount)
    {
        var calories = Enumerable.Range(0, 4).Sum(i => ingredients[i].Calories * spoonCount[i]);
        return calories;
    }

    private static int[] GetHighestScore(IEnumerable<Ingredient> ingredients)
    {
        ingredients = ingredients.ToArray();
        var spoonCount = new[] { 1, 1, 1, 1 };
        for (var i = 0; i < 96; i++)
        {
            var tests = new[]
            {
                (int[]) spoonCount.Clone(), (int[]) spoonCount.Clone(), (int[]) spoonCount.Clone(), (int[]) spoonCount.Clone()
            };
            for (var j = 0; j < 4; j++)
            {
                tests[j][j] += 1;
            }

            var scores = new List<int>
            {
                GetScore(ingredients, tests[0]),
                GetScore(ingredients, tests[1]),
                GetScore(ingredients, tests[2]),
                GetScore(ingredients, tests[3])
            };

            var highestScore = scores.IndexOf(scores.Max());
            spoonCount = tests[highestScore];
        }

        return spoonCount;
    }

    private static int GetScore(IEnumerable<Ingredient> ingredients, int[] spoonCount)
    {
        var ingredientsArray = ingredients.ToArray();
        var capacity = ingredientsArray[0].Capacity * spoonCount[0] + ingredientsArray[1].Capacity * spoonCount[1] +
                       ingredientsArray[2].Capacity * spoonCount[2] + ingredientsArray[3].Capacity * spoonCount[3];
        var durability = ingredientsArray[0].Durability * spoonCount[0] + ingredientsArray[1].Durability * spoonCount[1] +
                         ingredientsArray[2].Durability * spoonCount[2] + ingredientsArray[3].Durability * spoonCount[3];
        var flavor = ingredientsArray[0].Flavor * spoonCount[0] + ingredientsArray[1].Flavor * spoonCount[1] +
                     ingredientsArray[2].Flavor * spoonCount[2] + ingredientsArray[3].Flavor * spoonCount[3];
        var texture = ingredientsArray[0].Texture * spoonCount[0] + ingredientsArray[1].Texture * spoonCount[1] +
                      ingredientsArray[2].Texture * spoonCount[2] + ingredientsArray[3].Texture * spoonCount[3];
        durability = durability < 0 ? 0 : durability;
        flavor = flavor < 0 ? 0 : flavor;
        texture = texture < 0 ? 0 : texture;
        capacity = capacity < 0 ? 0 : capacity;
        return capacity * durability * flavor * texture;
    }

    private class Ingredient
    {
        public int Capacity;
        public int Durability;
        public int Flavor;
        public int Texture;
        public int Calories;

        public Ingredient(int capacity, int durability, int flavor, int texture, int calories)
        {
            Capacity = capacity;
            Durability = durability;
            Flavor = flavor;
            Texture = texture;
            Calories = calories;
        }
    }
}
