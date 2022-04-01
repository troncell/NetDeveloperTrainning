using Algorithm.Sort;
using System.Collections.Generic;
using Xunit;

namespace Trainning.Tests
{
    public class SortHelperTest
    {
        //ð���������
        [Fact]
        public void BubbleTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.Bubble(input);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }

        //ϣ���������
        [Fact]
        public void ShellTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.Shell(input);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }

        //ѡ���������
        [Fact]
        public void SimpleSelectTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.SimpleSelect(input);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }

        //ѡ���������2
        [Fact]
        public void SelectionTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.Selection(input);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }

        //�����������
        [Fact]
        public void QuickSortTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.QuickSort(input, 0, 7);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }

        //�����������
        [Fact]
        public void InsertionTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.Insertion(input);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }
        //���������
        [Fact]
        public void HeapTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.Heap(input, 7);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }
        ////Ͱ�������
        [Fact]
        public void BucketTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.Bucket(input, 98, 13);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }

        ////�鲢�������(�ݹ�汾)
        //[Fact]
        //public void MergeArrTest()
        //{
        //    int[] input = { 90, 76, 45, 93, 68, 13, 98 };
        //    SortHelper.MergeArr(input, 7);

        //    int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
        //    for (int index = 0; index < input.Length; index++)
        //    {
        //        Assert.Equal(input[index], expected[index]);
        //    }
        //}

        ////�鲢�������(list�汾)
        //[Fact]
        //public void MergeListTest()
        //{
        //    List<int> input = new List<int>();
        //    int[] arr = { 90, 76, 45, 93, 68, 13, 98 };
        //    input.AddRange(arr);
        //    SortHelper.MergeList(input);
        //    List<int> expected = new List<int>();
        //    int[] arrRe = { 13, 45, 68, 76, 90, 93, 98 };
        //    expected.AddRange(arrRe);
        //    for (int index = 0; index < input.ToArray().Length; index++)
        //    {
        //        Assert.Equal(input[index], expected[index]);
        //    }
        //}




    }
}