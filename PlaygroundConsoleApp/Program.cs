using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


Console.WriteLine("Start");
MeasureTime2(() => CountToNearlyInfinity());

Console.WriteLine($"Do: {MeasureTime(() => CalculateSomeResult())}");

static int MeasureTime(Func<int> action)
{
    var watch = Stopwatch.StartNew();
    var result = action();
    watch.Stop();
    Console.WriteLine(String.Format("Stop: {0}", watch.ElapsedMilliseconds));
    return result;
}
static void MeasureTime2(Action action)
{
    var watch = Stopwatch.StartNew();
    action();
    watch.Stop();
    Console.WriteLine(String.Format("Stop: {0}", watch.ElapsedMilliseconds));
}


static void CountToNearlyInfinity()
{
    for (int i = 0; i < 1000000000; i++) ;
}

static int CalculateSomeResult()
{
    for (int i = 0; i < 1000000000; i++) ;
    return 42;
}