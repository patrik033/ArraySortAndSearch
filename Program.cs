using ArraySortAndSearch;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;

MeasureWithStopWatch();

//var summary = BenchmarkRunner.Run<SortingAlgorithmsBenchmark>(new MediumConfig());

static void MeasureWithStopWatch()
{
    Random random = new Random();
    var lowArr = new int[50];
    lowArr = Enumerable.Range(0, 50)
        .OrderBy(c => random.Next())
        .ToArray();


    var mediumArr = new int[1500];
    mediumArr = Enumerable.Range(0, 1500)
        .OrderBy(c => random.Next())
        .ToArray();

    var highArr = new int[20000];
    highArr = Enumerable.Range(0, 20000)
        .OrderBy(c => random.Next())
        .ToArray();

    var testHighArr = new int[20000];
    testHighArr = Enumerable.Range(0, 20000)
        .OrderBy(c => random.Next())
        .ToArray();




    Console.WriteLine("Sorted low Arrays:");
    SortingAlgorithms.MeasurePerformance(lowArr);
    Console.WriteLine();

    Console.WriteLine("Sorted medium Arrays:");
    SortingAlgorithms.MeasurePerformance(mediumArr);
    Console.WriteLine();

    Console.WriteLine("Sorted high Arrays:");
    SortingAlgorithms.MeasurePerformance(highArr);

    SortingAlgorithms.SortFinal(testHighArr);

    Stopwatch binaryStop = new Stopwatch();
    binaryStop.Start();
    var searchValue = 144;
    var result = BinarySearch.Search(testHighArr, searchValue);
    binaryStop.Stop();

    if (result != -1)
    {
        Console.WriteLine($"Element found at index: {result}, took: {binaryStop.ElapsedTicks} ticks");
    }
    else
    {
        Console.WriteLine("Element not found in the array.");
    }







}