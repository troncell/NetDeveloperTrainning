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
    /// ϣ������
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

    //ѡ������
    public static void SimpleSelect(int[] list)
    {
        for (int i = 0; i < list.Length - 1; i++)
        {
            //��¼��Сֵ����
            int minIndex = i;
            for (int j = i + 1; j < list.Length; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }
            //������Сֵ : ��ǰ����������Сֵʱ�Ͳ��ý���
            if (minIndex != i)
            {
                int temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
        }
    }

    /// <summary>
    /// ѡ������
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
    ///  ����������ʵ��Ӧ���л���Դ��������ظ�Ԫ�ص����顣���ԭ���Ŀ��ţ��о޴�ĸĽ�Ǳ��������O(nlgn)������O(n)��
    ///  E.W.Dijlstra���ԣ�����Dijkstra���·���㷨�ķ����ߣ�������㷨�ǣ� ����ÿ���з֣����������ߵ��ұ߱���һ�Σ�ά������ָ�룬
    ///  ����ltָ��ʹ��Ԫ�أ�arr[0]-arr[lt-1]����ֵ��С���з�Ԫ�أ�gtָ��ʹ��Ԫ�أ�arr[gt+1]-arr[N-1]����ֵ�������з�Ԫ�أ�
    ///  iָ��ʹ��Ԫ�أ�arr[lt]-arr[i-1]����ֵ�������з�Ԫ�أ���arr[i]-arr[gt]����Ԫ�ػ�û��ɨ�裬�з��㷨ִ�е�i>gtΪֹ��
    ///  ÿ���з�֮��λ��gtָ���ltָ��֮���Ԫ�ص�λ�ö��Ѿ����Ŷ�������Ҫ��ȥ�����ˡ�
    ///  ֮�󽫣�lo,lt-1��,��gt+1,hi���ֱ���Ϊ���������������������ĵݹ麯���Ĳ������룬�ݹ�����������㷨Ҳ�ͽ�����
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="hi">arr.Length - 1</param>
    public static void QuickSortOptimization(int[] arr, int low, int hi)
    {
        //ȥ������Ԫ�ػ���û��Ԫ�ص����
        if (low < hi)
        {
            int lt = low;
            int i = low + 1;//��һ��Ԫ�����з�Ԫ�أ�����i��low+1��ʼ
            int gt = hi;
            int pivot = arr[lt];
            while (i <= gt)
            {
                //С���з�Ԫ�ط���lt��ߣ�ָ��lt��i��������
                if (arr[i] < pivot)
                {
                    Swap(ref arr[i], ref arr[lt]);
                    i++;
                    lt++;
                }
                //�����з�Ԫ�ط���gt�ұߣ�ָ��gt����
                else if (arr[i] > pivot)
                {
                    Swap(ref arr[i], ref arr[gt]);
                    gt--;
                }
                //�����з�Ԫ�أ�ָ��i++
                else
                {
                    i++;
                }
            }
            //lt-gt֮���Ԫ���Ѿ��Ŷ���ֻ���lt��ߺ�gt�ұߵ�Ԫ�ؽ��еݹ�����
            //�Ա��µ���С�Ĳ��ֵݹ�����
            QuickSortOptimization(arr, low, lt - 1);
            //�Ա��µ����Ĳ��ֵݹ�����
            QuickSortOptimization(arr, gt + 1, hi);
        }
    }

    /// <summary>
    /// �鲢���� �ݹ�汾
    /// �����������������ϣ������ϲ���һ���µ������
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
        //ͨ���Ƚϣ��ѽ�С��һ���������뵽temp������
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
        //������ʣ��������뵽temp������
        while (i <= mid)
        {
            temp[k++] = arr[i++];
        }
        while (j <= last)
        {
            temp[k++] = arr[j++];
        }
        //�Ѻϲ�����������ֵ��ԭ����
        for (int m = 0; m < k; m++)
        {
            arr[m + first] = temp[m];
        }
    }


    /// <summary>
    /// �鲢���� List�汾
    /// �����������������ϣ������ϲ���һ���µ������
    /// </summary>
    public static List<int> MergeList(List<int> list)
    {
        int count = list.Count;
        if (count <= 1)
        {
            return list;
        }
        int mid = count / 2;
        List<int> left = new List<int>();//�������List
        List<int> right = new List<int>();//�����Ҳ�List

        //��������ѭ����list��Ϊ��������List
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
    /// �ϲ������Ѿ��ź����List
    /// </summary>
    /// <param name="left">���List</param>
    /// <param name="right">�Ҳ�List</param>
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
    /// ��������
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
    /// ������
    /// �Ѷ�Ӧһ����ȫ�������������з�Ҷ����ֵ��������(��С��)����Ů��ֵ������㣨�Ѷ�Ԫ�أ���ֵ����С(�����)��
    /// ÿ�ζ�ȡ�Ѷ���Ԫ�أ����������������棬Ȼ��ʣ���Ԫ�����µ���Ϊ��С�ѣ��������ƣ����յõ���������С�
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="length"></param>
    public static void Heap(int[] arr, int length)
    {
        CreateHeap(arr, length);
        //�����Ľڵ���е���
        for (int i = length - 1; i > 0; i--)
        {
            //�����Ѷ������һ���ڵ��Ԫ��
            Swap(ref arr[0], ref arr[i]);
            //ÿ�ν������е���
            AdjustHeap(arr, 0, i - 1);
        }
    }

    /// <summary>
    /// ���ѷ������Գ�ʼ���н��ѵĹ��̣�����һ����������ɸѡ�Ĺ��̡�
    /// 1��n ��������ȫ�������������һ������ǵ�n/2������������
    /// 2��ɸѡ�ӵ�n/2�����Ϊ����������ʼ����������Ϊ�ѡ�
    /// 3��֮����ǰ���ζԸ����Ϊ������������ɸѡ��ʹ֮��Ϊ�ѣ�ֱ������㡣
    /// ��ȫ�������������һ���⣬ÿһ���ϵĽ�������ﵽ���ֵ�������һ����ֻȱ���ұߵ����ɽ�㡣
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
            //���ӽڵ�ָ���ڷ�Χ�ڲ����Ƚ�
            if (child + 1 <= length && arr[child] < arr[child + 1])
            {
                //�ȱȽ������ӽڵ��С��ѡ������
                child++;
            }
            //������ڵ����ӽڵ���������ϣ�ֱ����������
            if (arr[root] > arr[child])
            {
                return;
            }
            else
            {
                //���򽻻����������ټ����ӽڵ����ڵ�Ƚ�
                Swap(ref arr[root], ref arr[child]);
                root = child;
                child = root * 2 + 1;
            }
        }
    }

    /// <summary>
    /// Ͱ����
    /// �����ڹ�ϣ���������������һ��ӳ�亯������ֵ�����Ӧ��Ͱ��
    /// �ʱ�������ȫ���ֵ�һ��Ͱ��O(N^2)��һ�����ΪO(NlogN)
    /// ���ʱ�������ÿ��Ͱ��ֻ��һ������ʱ����O(N)
    /// int bucketNum = arr.Length;
    /// ӳ�亯����int bucketIndex = arr[i] * bucketNum / (max + 1);
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="max">��������ֵ</param>
    /// <returns></returns>
    public static int[] Bucket(int[] arr, int max, int min)
    {
        int bucketNum = arr.Length;

        // ��ʼ��Ͱ  
        LinkedList<int>[] bucket = new LinkedList<int>[arr.Length];
        for (int i = 0; i < bucketNum; i++)
        {
            bucket[i] = new LinkedList<int>();
        }
        // Ԫ�ط�װ����Ͱ��  
        for (int i = 0; i < bucketNum; i++)
        {
            //ӳ�亯��
            int bucketIndex = arr[i] * bucketNum / (max + 1);
            InsertIntoLinkList(bucket[bucketIndex], arr[i]);
        }
        // �Ӹ���Ͱ�л�ȡ���������  
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
    /// ��������� linklist   
    /// </summary>  
    /// <param name="linkedList"> Ҫ��������� </param>  
    /// <param name="num"> Ҫ������������� </param>  
    private static void InsertIntoLinkList(LinkedList<int> linkedList, int num)
    {
        // ����Ϊ��ʱ�����뵽��һλ  
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

    //��������
    private static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }
}

