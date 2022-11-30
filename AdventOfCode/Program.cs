using AdventOfCode;
using AoCContracts;
using System.Diagnostics;

var year = Year.Fifteen;
var day = Day.Eightteen;

var daySolver = new YearPicker().PickYear(year).PickDay(day);

var watch = Stopwatch.StartNew();
Console.WriteLine("    Solving " + (int)year + " Day " + (int)day);
Console.WriteLine(" *  S: " + daySolver.SolveSimple());
Console.WriteLine(" ** A: " + daySolver.SolveAdvanced());
watch.Stop();
var timeTaken = watch.Elapsed;
Console.WriteLine($" Time Taken: {timeTaken:mm\\:ss\\.fff}");