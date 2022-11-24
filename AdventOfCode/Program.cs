using AdventOfCode;
using AoCContracts;
using System.Diagnostics;

var year = Year.Fifteen;
var day = Day.Fifteen;

var daySolver = new YearPicker().PickYear(year).PickDay(day);

var watch = Stopwatch.StartNew();
Console.WriteLine("    Solving " + (int)year + " Day " + (int)day);
Console.WriteLine(" *  S: " + daySolver.SolveSimple());
Console.WriteLine(" ** A: " + daySolver.SolveAdvanced());
watch.Stop();
var timeTaken = watch.Elapsed;
Console.WriteLine($" Time Taken: {timeTaken:mm\\:ss\\.fff}");

//for (int i = 0; i < 25; i++)
//{
//    var daySolver = new YearPicker().PickYear(year).PickDay((Day)i);
//    var stopWatch = Stopwatch.StartNew();
//    Console.WriteLine("    Solving " + (int)year + " Day " + (int)day);
//    Console.WriteLine(" *  S: " + daySolver.SolveSimple());
//    Console.WriteLine(" ** A: " + daySolver.SolveAdvanced());
//    stopWatch.Stop();
//    var timeTakenPerDay = stopWatch.Elapsed;
//    Console.WriteLine($" Time Taken: {timeTakenPerDay:mm\\:ss\\.fff}");
//    Console.WriteLine();
//}