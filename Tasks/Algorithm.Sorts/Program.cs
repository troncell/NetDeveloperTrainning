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

        [Benchmark]
        public void RunBubbleSort()
        {
            int[] array = { 90, 76, 45, 93, 68, 13, 98 };
            //SortHelper.PrintArray(array);
            SortHelper.Bubble(array);
            //SortHelper.PrintArray(array);
        }
    }
}