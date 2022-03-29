using Algorithm.Sorts;
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
        //插入排序
        [Benchmark]
        public void RunInsertionSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            InsertionHelper.Insertion(array);
            //SortHelper.PrintArray(array);
        }
        //选择排序
        [Benchmark]
        public void RunSelectionSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SelectionHelper.Selection(array);
            //SortHelper.PrintArray(array);
        }
        //希尔排序
        [Benchmark]
        public void RunShellSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            ShellHelper.Shell(array);
            //SortHelper.PrintArray(array);
        }
        //简单选择排序
        [Benchmark]
        public void RunSimpleSelectSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SimpleSelectHelper.SimpleSelect(array);
            //SortHelper.PrintArray(array);
        }
        //三向切分排序
        [Benchmark]
        public void RunQuickSortOptimizationSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            QuickSortOptimizationHelper.QuickSortOptimization(array, 3, 4);
            //SortHelper.PrintArray(array);
        }
        //堆排序
        [Benchmark]
        public void RunHeapSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            HeapHelper.Heap(array, array.Length);
            //SortHelper.PrintArray(array);
        }
        //归并排序（数组）
        [Benchmark]
        public void RunMergeArrSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            MergeHelper.MergeArr(array, array.Length);
            //SortHelper.PrintArray(array);
        }
        //归并排序（列表）
        [Benchmark]
        public void RunMergeListSort()
        {
            List<int> list = new List<int>();
            list.Add(90);
            list.Add(76);
            list.Add(45);
            list.Add(93);
            list.Add(68);
            list.Add(13);
            list.Add(98);
            //SortHelper.PrintArray(array);
            MergeHelper.MergeList(list);
            //SortHelper.PrintArray(array);
        }
        //归并排序（数组）
        [Benchmark]
        public void RunBucketSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            BucketHelper.Bucket(array, 98, 13);
            //SortHelper.PrintArray(array);
        }
    }
}