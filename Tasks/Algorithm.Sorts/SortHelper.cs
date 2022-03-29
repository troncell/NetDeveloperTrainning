using BenchmarkDotNet.Attributes;

namespace Algorithm.Sort;
public class SortHelper
{

    public SortHelper()
    {

    }

    public static void Bubble(int[] arr)
    {
        int num = arr.Length;
        for (int i = 0; i < num - 1; i++)
            for (int j = 0; j < num - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    // swap tmp and arr[i]
                    int tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
    }

    /* Printing the array */
    public static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}