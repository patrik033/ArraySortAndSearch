using ArraySortAndSearch;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

//MeasureWithStopWatch();

var summary = BenchmarkRunner.Run<SortingAlgorithmsBenchmark>(new MediumConfig());

static void MeasureWithStopWatch()
{
    Random random = new Random();
    var lowArr = new int[50];
    lowArr = Enumerable.Range(0, 50)
        .OrderBy(c => random.Next())
        .ToArray();


    var mediumArr = new int[500];
    mediumArr = Enumerable.Range(0, 500)
        .OrderBy(c => random.Next())
        .ToArray();

    var highArr = new int[20000];
    highArr = Enumerable.Range(0, 20000)
        .OrderBy(c => random.Next())
        .ToArray();



    Console.WriteLine("Sorted low Arrays:");
    SortingAlgorithms.MeasurePerformance(lowArr);

    Console.WriteLine("Sorted medium Arrays:");
    SortingAlgorithms.MeasurePerformance(mediumArr);


    Console.WriteLine("Sorted high Arrays:");
    SortingAlgorithms.MeasurePerformance(highArr);
}