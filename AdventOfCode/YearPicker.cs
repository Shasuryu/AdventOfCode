using AoC_2015;
using AoCContracts;

namespace AdventOfCode;
internal class YearPicker : IYearPicker
{
    public IYear PickYear(Year year) => year switch
    {
        Year.Fifteen => new Y2015(),
        _ => throw new ArgumentOutOfRangeException(nameof(year), year, null)
    };
}
