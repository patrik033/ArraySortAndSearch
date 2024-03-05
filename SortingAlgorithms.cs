using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortAndSearch
{
    public static class SortingAlgorithms
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        public static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        public static void ArraySort(int[] arr)
        {
            Array.Sort(arr);
        }

        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        public static void SortFinal(int[] arr)
        {
            OptimizedHybridSort.Sort(arr);
        }

        public static void MeasurePerformance(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();

            int[] arrBubbleSort = new int[arr.Length];
            int[] arrMergeSort = new int[arr.Length];
            int[] arrQuickSort = new int[arr.Length];
            int[] arrHybridSort = new int[arr.Length];
            int[] heapSort = new int[arr.Length];
            int[] arrSort = new int[arr.Length];



            Array.Copy(arr, arrBubbleSort, arr.Length);
            Array.Copy(arr, arrMergeSort, arr.Length);
            Array.Copy(arr, arrQuickSort, arr.Length);
            Array.Copy(arr, arrHybridSort, arr.Length);
            Array.Copy(arr, heapSort, arr.Length);
            Array.Copy(arr, arrSort, arr.Length);



            stopwatch.Start();
            BubbleSort(arrBubbleSort);
            stopwatch.Stop();
            Console.WriteLine("Bubble Sort Time: " + stopwatch.ElapsedTicks + "ms");

            stopwatch.Restart();
            MergeSort(arrMergeSort, 0, arrMergeSort.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Merge Sort Time: " + stopwatch.ElapsedTicks + "ms");

            stopwatch.Restart();
            QuickSort(arrQuickSort, 0, arrQuickSort.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort Time: " + stopwatch.ElapsedTicks + "ms");

            stopwatch.Restart();
            OptimizedHybridSort.Sort(arrHybridSort);
            stopwatch.Stop();
            Console.WriteLine("Hybrid Sort Time: " + stopwatch.ElapsedTicks + "ms");

            stopwatch.Restart();
            HeapSort.Sort(heapSort);
            stopwatch.Stop();
            Console.WriteLine("Heap Sort Time: " + stopwatch.ElapsedTicks + "ms");

            stopwatch.Restart();
            Array.Sort(arrHybridSort);
            stopwatch.Stop();
            Console.WriteLine("Array.Sort Time: " + stopwatch.ElapsedTicks + "ms");
        }

    }
}
