using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortAndSearch
{
    public class OptimizedHybridSort
    {
        // We set a threshold to decide when to use insertion sort versus merge sort.
        // If the array size is less than or equal to this threshold, we use insertion sort.
        private const int InsertionSortThreshold = 16;

        // This method is the entry point for sorting an array using the hybrid sort algorithm.
        public static void Sort(int[] array)
        {
            HybridSort(array, 0, array.Length - 1); // Start the sorting process from the beginning to the end of the array.
        }

        // This method measures the performance of the sorting algorithm.
        public static void MeasurePerformance(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch(); // Create a stopwatch to measure sorting time.

            int[] arrBubbleSort = new int[array.Length]; // Create a copy of the array for sorting.

            Array.Copy(array, arrBubbleSort, array.Length); // Copy the original array for sorting.

            stopwatch.Start(); // Start the stopwatch.
            Sort(arrBubbleSort); // Sort the copied array.
            stopwatch.Stop(); // Stop the stopwatch.

            // Display the sorting time.
            Console.WriteLine("Hybrid Sort Time: " + stopwatch.ElapsedTicks + "ms");
        }

        // This method implements the hybrid sorting algorithm.
        private static void HybridSort(int[] array, int low, int high)
        {
            // If the size of the array is small, use insertion sort for efficiency.
            if (high - low < InsertionSortThreshold)
            {
                InsertionSort(array, low, high);
            }
            // If the array size is larger, use merge sort for efficiency.
            else
            {
                int mid = low + (high - low) / 2; // Calculate the midpoint of the array.

                // Recursively sort the left and right halves of the array.
                HybridSort(array, low, mid);
                HybridSort(array, mid + 1, high);

                // Merge the sorted halves of the array.
                Merge(array, low, mid, high);
            }
        }

        // This method implements the insertion sort algorithm.
        private static void InsertionSort(int[] array, int low, int high)
        {
            // Iterate through the array starting from the second element.
            for (int i = low + 1; i <= high; i++)
            {
                int key = array[i];
                int j = i - 1;

                // Move elements of array[low..i-1] that are greater than key
                // to one position ahead of their current position.
                while (j >= low && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        // This method merges two sorted subarrays into one sorted array.
        private static void Merge(int[] array, int low, int mid, int high)
        {
            int[] tempArray = new int[high - low + 1]; // Temporary array to store merged elements.
            int i = low, j = mid + 1, k = 0; // Initialize indices for left, right, and merged arrays.

            // Compare elements from both halves and merge them into tempArray.
            while (i <= mid && j <= high)
            {
                if (array[i] <= array[j])
                {
                    tempArray[k++] = array[i++];
                }
                else
                {
                    tempArray[k++] = array[j++];
                }
            }

            // Copy any remaining elements from the left subarray.
            while (i <= mid)
            {
                tempArray[k++] = array[i++];
            }

            // Copy any remaining elements from the right subarray.
            while (j <= high)
            {
                tempArray[k++] = array[j++];
            }

            // Copy the merged elements from tempArray back to the original array.
            Array.Copy(tempArray, 0, array, low, tempArray.Length);
        }
    }
}
