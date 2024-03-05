using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortAndSearch
{
    public class BinarySearch
    {
        // Binary search function
        public static int Search(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // Check if target is present at mid
                if (array[mid] == target)
                {
                    return mid;
                }

                // If target is greater, ignore left half
                if (array[mid] < target)
                {
                    left = mid + 1;
                }
                // If target is smaller, ignore right half
                else
                {
                    right = mid - 1;
                }
            }

            // Target not found
            return -1;
        }

        // Main method to test the binary search function
        public static void Main(string[] args)
        {
            int[] array = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int target = 23;

            int index = Search(array, target);

            if (index != -1)
            {
                Console.WriteLine("Element found at index: " + index);
            }
            else
            {
                Console.WriteLine("Element not found in the array.");
            }
        }
    }
}
