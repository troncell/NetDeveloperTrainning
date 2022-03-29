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

    /// <summary>
    /// 希尔排序
    /// </summary>
    public static void Shell(int[] list)
    {
        int inc;
        for (inc = 1; inc <= list.Length / 9; inc = 3 * inc + 1) ;
        for (; inc > 0; inc /= 3)
        {
            for (int i = inc + 1; i <= list.Length; i += inc)
            {
                int t = list[i - 1];
                int j = i;
                while ((j > inc) && (list[j - inc - 1] > t))
                {
                    list[j - 1] = list[j - inc - 1];
                    j -= inc;
                }
                list[j - 1] = t;
            }
        }
    }

    //选择排序
    public static void SimpleSelect(int[] list)
    {
        for (int i = 0; i < list.Length - 1; i++)
        {
            //记录最小值索引
            int minIndex = i;
            for (int j = i + 1; j < list.Length; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }
            //交互最小值 : 当前索引就是最小值时就不用交换
            if (minIndex != i)
            {
                int temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
        }
    }

    /// <summary>
    /// 选择排序
    /// </summary>
    public static void Selection(int[] list)
    {
        for (int i = 0; i < list.Length - 1; ++i)
        {
            int min = i;
            for (int j = i + 1; j < list.Length; ++j)
            {
                if (list[j] < list[min])
                    min = j;
            }
            int t = list[min];
            list[min] = list[i];
            list[i] = t;
            // Console.WriteLine("{0}",list[i]);
        }

    }

    /// <summary>
    ///  快速排序在实际应用中会面对大量具有重复元素的数组。相比原生的快排，有巨大的改进潜力。（从O(nlgn)提升到O(n)）
    ///  E.W.Dijlstra（对，就是Dijkstra最短路径算法的发明者）提出的算法是： 对于每次切分：从数组的左边到右边遍历一次，维护三个指针，
    ///  其中lt指针使得元素（arr[0]-arr[lt-1]）的值均小于切分元素；gt指针使得元素（arr[gt+1]-arr[N-1]）的值均大于切分元素；
    ///  i指针使得元素（arr[lt]-arr[i-1]）的值均等于切分元素，（arr[i]-arr[gt]）的元素还没被扫描，切分算法执行到i>gt为止。
    ///  每次切分之后，位于gt指针和lt指针之间的元素的位置都已经被排定，不需要再去处理了。
    ///  之后将（lo,lt-1）,（gt+1,hi）分别作为处理左子数组和右子数组的递归函数的参数传入，递归结束，整个算法也就结束。
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="hi">arr.Length - 1</param>
    public static void QuickSortOptimization(int[] arr, int low, int hi)
    {
        //去除单个元素或者没有元素的情况
        if (low < hi)
        {
            int lt = low;
            int i = low + 1;//第一个元素是切分元素，所以i从low+1开始
            int gt = hi;
            int pivot = arr[lt];
            while (i <= gt)
            {
                //小于切分元素放在lt左边，指针lt和i整体右移
                if (arr[i] < pivot)
                {
                    Swap(ref arr[i], ref arr[lt]);
                    i++;
                    lt++;
                }
                //大于切分元素放在gt右边，指针gt左移
                else if (arr[i] > pivot)
                {
                    Swap(ref arr[i], ref arr[gt]);
                    gt--;
                }
                //等于切分元素，指针i++
                else
                {
                    i++;
                }
            }
            //lt-gt之间的元素已经排定，只需对lt左边和gt右边的元素进行递归排序
            //对比新的轴小的部分递归排序
            QuickSortOptimization(arr, low, lt - 1);
            //对比新的轴大的部分递归排序
            QuickSortOptimization(arr, gt + 1, hi);
        }
    }

    /// <summary>
    /// 归并排序 递归版本
    /// 将两个（或两个以上）有序表合并成一个新的有序表
    /// </summary>
    public static void MergeArr(int[] arr, int length)
    {
        int[] temp = new int[length];
        MergeInternalSort(arr, 0, length, temp);
    }

    private static void MergeInternalSort(int[] arr, int first, int last, int[] temp)
    {
        if (first < last)
        {
            int mid = (first + last) / 2;
            MergeInternalSort(arr, first, mid, temp);
            MergeInternalSort(arr, mid + 1, last, temp);
            Merge(arr, first, mid, last, temp);
        }
    }

    private static void Merge(int[] arr, int first, int mid, int last, int[] temp)
    {
        int i = first;
        int j = mid + 1;
        int k = 0;
        //通过比较，把较小的一部分数放入到temp数组中
        while (i <= mid && j <= last)
        {
            if (arr[i] < arr[j])
            {
                temp[k++] = arr[i++];
            }
            else
            {
                temp[k++] = arr[j++];
            }
        }
        //将数组剩余的数放入到temp数组中
        while (i <= mid)
        {
            temp[k++] = arr[i++];
        }
        while (j <= last)
        {
            temp[k++] = arr[j++];
        }
        //把合并的数组结果赋值给原数组
        for (int m = 0; m < k; m++)
        {
            arr[m + first] = temp[m];
        }
    }


    /// <summary>
    /// 归并排序 List版本
    /// 将两个（或两个以上）有序表合并成一个新的有序表
    /// </summary>
    public static List<int> MergeList(List<int> list)
    {
        int count = list.Count;
        if (count <= 1)
        {
            return list;
        }
        int mid = count / 2;
        List<int> left = new List<int>();//定义左侧List
        List<int> right = new List<int>();//定义右侧List

        //以下两个循环把list分为左右两个List
        for (int i = 0; i < mid; i++)
        {
            left.Add(list[i]);
        }
        for (int j = mid; j < count; j++)
        {
            right.Add(list[j]);
        }
        left = MergeList(left);
        right = MergeList(right);
        return Merge(left, right);
    }
    /// <summary>
    /// 合并两个已经排好序的List
    /// </summary>
    /// <param name="left">左侧List</param>
    /// <param name="right">右侧List</param>
    /// <returns></returns>
    static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> temp = new List<int>();
        while (left.Count > 0 && right.Count > 0)
        {
            if (left[0] <= right[0])
            {
                temp.Add(left[0]);
                left.RemoveAt(0);
            }
            else
            {
                temp.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        if (left.Count > 0)
        {
            for (int i = 0; i < left.Count; i++)
            {
                temp.Add(left[i]);
            }
        }
        if (right.Count > 0)
        {
            for (int i = 0; i < right.Count; i++)
            {
                temp.Add(right[i]);
            }
        }
        return temp;
    }

    /// <summary>
    /// 插入排序
    /// </summary>
    public static void Insertion(int[] list)
    {
        for (int i = 1; i < list.Length; ++i)
        {
            int t = list[i];
            int j = i;
            while ((j > 0) && (list[j - 1] > t))
            {
                list[j] = list[j - 1];
                --j;
            }
            list[j] = t;
        }

    }

    /// <summary>
    /// 堆排序
    /// 堆对应一棵完全二叉树，且所有非叶结点的值均不大于(或不小于)其子女的值，根结点（堆顶元素）的值是最小(或最大)的
    /// 每次都取堆顶的元素，将其放在序列最后面，然后将剩余的元素重新调整为最小堆，依次类推，最终得到排序的序列。
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="length"></param>
    public static void Heap(int[] arr, int length)
    {
        CreateHeap(arr, length);
        //从最后的节点进行调整
        for (int i = length - 1; i > 0; i--)
        {
            //交换堆顶和最后一个节点的元素
            Swap(ref arr[0], ref arr[i]);
            //每次交换进行调整
            AdjustHeap(arr, 0, i - 1);
        }
    }

    /// <summary>
    /// 建堆方法：对初始序列建堆的过程，就是一个反复进行筛选的过程。
    /// 1）n 个结点的完全二叉树，则最后一个结点是第n/2个结点的子树。
    /// 2）筛选从第n/2个结点为根的子树开始，该子树成为堆。
    /// 3）之后向前依次对各结点为根的子树进行筛选，使之成为堆，直到根结点。
    /// 完全二叉树：除最后一层外，每一层上的结点数均达到最大值；在最后一层上只缺少右边的若干结点。
    /// </summary>
    private static void CreateHeap(int[] arr, int length)
    {
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            AdjustHeap(arr, i, length - 1);
        }
    }

    private static void AdjustHeap(int[] arr, int start, int length)
    {
        int root = start;
        int child = root * 2 + 1;
        while (child <= length)
        {
            //若子节点指标在范围内才做比较
            if (child + 1 <= length && arr[child] < arr[child + 1])
            {
                //先比较两个子节点大小，选择最大的
                child++;
            }
            //如果父节点大於子节点代表调整完毕，直接跳出函数
            if (arr[root] > arr[child])
            {
                return;
            }
            else
            {
                //否则交换父子内容再继续子节点和孙节点比较
                Swap(ref arr[root], ref arr[child]);
                root = child;
                child = root * 2 + 1;
            }
        }
    }

    /// <summary>
    /// 桶排序
    /// 类似于哈希表的拉链法，定义一个映射函数，将值放入对应的桶中
    /// 最坏时间情况：全部分到一个桶中O(N^2)，一般情况为O(NlogN)
    /// 最好时间情况：每个桶中只有一个数据时最优O(N)
    /// int bucketNum = arr.Length;
    /// 映射函数：int bucketIndex = arr[i] * bucketNum / (max + 1);
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="max">数组的最大值</param>
    /// <returns></returns>
    public static int[] Bucket(int[] arr, int max, int min)
    {
        int bucketNum = arr.Length;

        // 初始化桶  
        LinkedList<int>[] bucket = new LinkedList<int>[arr.Length];
        for (int i = 0; i < bucketNum; i++)
        {
            bucket[i] = new LinkedList<int>();
        }
        // 元素分装各个桶中  
        for (int i = 0; i < bucketNum; i++)
        {
            //映射函数
            int bucketIndex = arr[i] * bucketNum / (max + 1);
            InsertIntoLinkList(bucket[bucketIndex], arr[i]);
        }
        // 从各个桶中获取后排序插入  
        int index = 0;
        for (int i = 0; i < bucketNum; i++)
        {
            foreach (var item in bucket[i])
            {
                arr[index++] = item;
            }
        }
        return arr;
    }

    /// <summary>  
    /// 按升序插入 linklist   
    /// </summary>  
    /// <param name="linkedList"> 要排序的链表 </param>  
    /// <param name="num"> 要插入排序的数字 </param>  
    private static void InsertIntoLinkList(LinkedList<int> linkedList, int num)
    {
        // 链表为空时，插入到第一位  
        if (linkedList.Count == 0)
        {
            linkedList.AddFirst(num);
            return;
        }
        else
        {
            foreach (int i in linkedList)
            {
                if (i > num)
                {
                    System.Collections.Generic.LinkedListNode<int> node = linkedList.Find(i);
                    linkedList.AddBefore(node, num);
                    return;
                }
            }
            linkedList.AddLast(num);
        }
    }

    //交换函数
    private static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }
}

