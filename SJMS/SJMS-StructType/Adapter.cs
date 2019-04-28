using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_StructType
{
    //适配器模式
    //将一个类的接口转换成客户希望的另外一个接口。Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。

    class Adapter
    {
        
        public static void DoMain()
        {
            int[] arr = { 5, 1, 4, 2, 6, 3 };

            OperationAdapter ada = new OperationAdapter();

            ada.Sort(arr);

            foreach(int i in arr)
            {
                Console.WriteLine(i);
            }

            int ret = ada.Search(arr, 6);
            Console.WriteLine("ret = {0}", ret);
        }
    }


    //成绩操作接口（目标接口）
    interface ScoreOperation
    {
        int[] Sort(int[] array);
        int Search(int[] array, int key);
    }

    //快速排序（适配者）
    class QuickSort
    {
        public int[] QSort(int[] array)
        {
            Sort(array, 0, array.Length - 1);   //数组是引用类型，所以可以直接对数组操作
            return array;
        }

        public void Sort(int[] array,int p,int r)
        {
            int q = 0;
            if(p < r)
            {
                q = Partition(array, p, r);
                Sort(array, p, q - 1);
                Sort(array, q + 1, r);
            }
        }

        public int Partition(int[] array,int p,int r)
        {
            int x = array[r];
            int j = p - 1;
            for(int i = p; i < r; i++)
            {
                if(array[i] <= x)
                {
                    j++;
                    Swap(array, j, i);
                }
            }

            Swap(array, j + 1, r);

            return j + 1;
        }

        public void Swap(int[] array,int i,int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }

    class BinarySearch
    {
        public int BSearch(int[] array,int key)
        {
            int low = 0;
            int high = array.Length - 1;

            while(low <= high)
            {
                int mid = (low + high) / 2;
                if(array[mid] <key)
                {
                    low = mid + 1;
                }else if(array[mid] > key)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }

    class OperationAdapter : ScoreOperation
    {

        private QuickSort qs;
        private BinarySearch bs;

        public OperationAdapter()
        {
            this.qs = new QuickSort();
            this.bs = new BinarySearch();
        }

        public int Search(int[] array, int key)
        {
            return bs.BSearch(array, key);
        }

        public int[] Sort(int[] array)
        {
            return qs.QSort(array);
        }
    }
}
