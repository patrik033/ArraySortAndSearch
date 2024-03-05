using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArraySortAndSearch
{
    [Config(typeof(MediumConfig))]
    [MemoryDiagnoser]
    public class SortingAlgorithmsBenchmark
    {
        private int[] arr;

        [Params(50, 1500, 20000)]
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            Random random = new Random();
            arr = new int[ArraySize];
            arr = Enumerable.Range(0, ArraySize)
                .OrderBy(c => random.Next())
            .ToArray();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void HybridSort()
        {
            OptimizedHybridSort.Sort(arr);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void BubbleSortBenchmark()
        {
            SortingAlgorithms.BubbleSort(arr);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void MergeSortBenchmark()
        {
            SortingAlgorithms.MergeSort(arr, 0, arr.Length - 1);
        }


     
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void QuickSortBenchmark()
        {
            SortingAlgorithms.QuickSort(arr, 0, arr.Length - 1);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void ArraySortBenchmark()
        {
            SortingAlgorithms.ArraySort(arr);
        }

      
        public IEnumerable<object[]> Data()
        {
            Random random = new Random();
            yield return new object[] { Enumerable.Range(0, ArraySize).OrderBy(c => random.Next()).ToArray()};
   
        }
    }
}
