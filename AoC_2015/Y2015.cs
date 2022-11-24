using AoCContracts;

namespace AoC_2015;
public class Y2015 : IYear
{
    public IDaySolver PickDay(Day day) => day switch
    {
        Day.One => new Y2015Day1.Y2015Day1(),
        Day.Two => new Y2015Day2.Y2015Day2(),
        Day.Three => new Y2015Day3.Y2015Day3(),
        Day.Four => new Y2015Day4.Y2015Day4(),
        Day.Five => new Y2015Day5.Y2015Day5(),
        Day.Six => new Y2015Day6.Y2015Day6(),
        Day.Seven => new Y2015Day7.Y2015Day7(),
        Day.Eight => new Y2015Day8.Y2015Day8(),
        Day.Nine => new Y2015Day9.Y2015Day9(),
        Day.Ten => new Y2015Day10.Y2015Day10(),
        Day.Eleven => new Y2015Day11.Y2015Day11(),
        Day.Twelve => new Y2015Day12.Y2015Day12(),
        Day.Thirteen => new Y2015Day13.Y2015Day13(),
        Day.Fourteen => new Y2015Day14.Y2015Day14(),
        Day.Fifteen => new Y2015Day15.Y2015Day15(),
        Day.Sixteen => new Y2015Day16.Y2015Day16(),
        Day.Seventeen => new Y2015Day17.Y2015Day17(),
        Day.Eightteen => new Y2015Day18.Y2015Day18(),
        Day.Nineteen => new Y2015Day19.Y2015Day19(),
        Day.Twenty => new Y2015Day20.Y2015Day20(),
        Day.Twentyone => new Y2015Day21.Y2015Day21(),
        Day.Twentytwo => new Y2015Day22.Y2015Day22(),
        Day.Twentythree => new Y2015Day23.Y2015Day23(),
        Day.Twentyfour => new Y2015Day24.Y2015Day24(),
        Day.Twentyfive => new Y2015Day25.Y2015Day25(),
        _ => throw new ArgumentOutOfRangeException(nameof(day), day, null)
    };
}
