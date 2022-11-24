using AoCContracts;

namespace AoC_2015.Y2015Day14;
internal class Y2015Day14 : IDaySolver
{
    private static string[] Input => File.ReadAllLines("Y2015Day14/Y2015Day14.txt");
    private HashSet<Reindeer> Reindeers = GetReindeers();
    public string SolveSimple()
    {
        foreach (var deer in Reindeers)
        {
            deer.Distance += 2503 / (deer.SpeedDuration + deer.RestDuration) * (deer.SpeedDuration * deer.Speed);
            deer.Distance += 2503 % (deer.SpeedDuration + deer.RestDuration) > deer.SpeedDuration 
                ? deer.SpeedDuration * deer.Speed 
                : 2503 % (deer.SpeedDuration + deer.RestDuration) * deer.Speed;
        }
        return Reindeers.Max(x => x.Distance).ToString();
    }

    public string SolveAdvanced()
    {
        for (var timeToCalculate = 1; timeToCalculate <= 2503; timeToCalculate++)
        {
            foreach (var deer in Reindeers)
            {
                deer.Distance = 0;
                deer.Distance += timeToCalculate / (deer.SpeedDuration + deer.RestDuration) * (deer.SpeedDuration * deer.Speed);
                deer.Distance += timeToCalculate % (deer.SpeedDuration + deer.RestDuration) > deer.SpeedDuration
                    ? deer.SpeedDuration * deer.Speed
                    : timeToCalculate % (deer.SpeedDuration + deer.RestDuration) * deer.Speed;
            }
            var highestDistance = Reindeers.Max(x => x.Distance);
            foreach (var deer in Reindeers.Where(r => r.Distance == highestDistance))
            {
                deer.Points++;
            }
        }
        return Reindeers.Max(x => x.Points).ToString();
    }

    private static HashSet<Reindeer> GetReindeers()
    {
        var input = Input;
        var reindeer = new HashSet<Reindeer>();
        foreach (var line in input)
        {
            var split = line.Split(' ');
            reindeer.Add(new Reindeer(split[0], int.Parse(split[3]), int.Parse(split[6]), int.Parse(split[13])));
        }

        return reindeer;
    }

    private class Reindeer
    {
        public string Name;
        public int Speed;
        public int SpeedDuration;
        public int RestDuration;
        public int Distance;
        public int Points;

        public Reindeer(string name, int speed, int speedDuration, int restDuration)
        {
            Name = name;
            Speed = speed;
            SpeedDuration = speedDuration;
            RestDuration = restDuration;
            Distance = 0;
        }
    }
}
