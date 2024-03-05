using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortAndSearch
{
    public class HeapSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;

            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // call max heapify on the reduced heap
                Heapify(array, i, 0);
            }
        }

        // To heapify a subtree rooted with node i which is
        // an index in array[]. n is size of heap
        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int left = 2 * i + 1; // left = 2*i + 1
            int right = 2 * i + 2; // right = 2*i + 2

            // If left child is larger than root
            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            // If right child is larger than largest so far
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            // If largest is not root
            if (largest != i)
            {
                int temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

                // Recursively heapify the affected sub-tree
                Heapify(array, n, largest);
            }
        }
    }
}
