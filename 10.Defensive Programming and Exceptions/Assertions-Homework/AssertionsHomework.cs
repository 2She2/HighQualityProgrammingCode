using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The array is not initialized!");
        Debug.Assert(arr.Length > 0, "There are no elements in the array!");
        Debug.Assert(arr.Length > 1, "There is only one element. There is no point to sort one element!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    // There is no point to check the method, because it is private, but...
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        // First to asserts are same as in upper method, just in case of someone use this method again in this class
        Debug.Assert(arr != null, "The array is not initialized!");
        Debug.Assert(arr.Length > 0, "There are no elements in the array!");
        Debug.Assert(arr.Length > 1, "There is only one element. It is smallest and biggest in the same time!");
        Debug.Assert(startIndex < endIndex, "Start index must be less than end index!");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "startIndex is out of array bounds");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "endIndex is out of array bounds");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        Debug.Assert(!Object.ReferenceEquals(x, y), "Both reference are pointing to the same object");

        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The array is not initialized!");
        Debug.Assert(value != null, "value is not initialized!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        // First to asserts are same as in upper method, just in case of someone use this method again in this class
        Debug.Assert(arr != null, "The array is not initialized!");
        Debug.Assert(value != null, "value is not initialized!");
        Debug.Assert(arr.Length > 0, "There are no elements in the array!");
        Debug.Assert(arr.Length > 1, "There is only one element. It is smallest and biggest in the same time!");
        Debug.Assert(startIndex < endIndex, "Start index must be less than end index!");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "startIndex is out of array bounds");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "endIndex is out of array bounds");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
