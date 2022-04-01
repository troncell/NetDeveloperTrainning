
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Algorithm.Sort.App // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Compare different sorts!");
            BenchmarkRunner.Run<Program>();
        }
        
    
        //冒泡排序
        [Benchmark]
        public void RunBubbleSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.Bubble(array);
            //SortHelper.PrintArray(array);
        }
        //希尔排序
        [Benchmark]
        public void RunShellSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.Shell(array);
            //SortHelper.PrintArray(array);
        }
        //选择排序
        [Benchmark]
        public void RunSelectionSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.Selection(array);
            //SortHelper.PrintArray(array);
        }
        //简单选择排序
        [Benchmark]
        public void RunSimpleSelectSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.SimpleSelect(array);
            //SortHelper.PrintArray(array);
        }
        //快速排序
        [Benchmark]
        public void RunQuickSortSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.QuickSort(array, 0, 7);
            //SortHelper.PrintArray(array);
        }
        //插入排序
        [Benchmark]
        public void RunInsertionSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.Insertion(array);
            //SortHelper.PrintArray(array);
        }
        //堆排序
        [Benchmark]
        public void RunHeapSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.Heap(array, array.Length);
            //SortHelper.PrintArray(array);
        }
        //桶排序
        [Benchmark]
        public void RunBucketSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.Bucket(array, 98, 13);
            //SortHelper.PrintArray(array);
        }

    }
}