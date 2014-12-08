using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombSort.App
{
    public static class Sorter
    {
        public static event EventHandler<SwapEventArgs> SwapOccured = delegate { };
        public static bool Draw = true;
        public static void CombSort(List<int> list, double shrink)
        {
            int gap = list.Count;
            bool swapped = false;
            while (gap > 1 || swapped == true)
            {
                gap = (int)(gap / shrink);
                if (gap < 1)
                {
                    gap = 1;
                }

                int i = 0;
                swapped = false;

                while (i + gap < list.Count)
                {
                    if (list[i] > list[i + gap])
                    {
                        swap(list, i, i + gap);
                        swapped = true;
                    }
                    ++i;
                }
            }
        }

        public static void QuickSort(List<int> list, int left, int right)
        {
            if (list.Count > 1)
            {
                int i = left;
                int j = right;
                int pivot = list[(left + right)/ 2];
                while (i <= j)
                {
                    while(list[i] < pivot)
                    {
                        ++i;
                    }
                    while(list[j] > pivot)
                    {
                        --j;
                    }
                    if (i <= j)
                    {
                        swap(list, i, j);
                        ++i;
                        --j;
                    }
                }
                if (left < j) QuickSort(list, left, j);
                if (i < right) QuickSort(list, i, right);
            }
        }

        public static void InsertionSort(List<int> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                int value = list[i];
                int j = i - 1;
                while (j >= 0 && list[j] > value)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = value;
            }
        }

        public static void BubbleSort(this List<int> list)
        {
            bool madeChanges;
            int itemCount = list.Count;
            do
            {
                madeChanges = false;
                itemCount--;
                for (int i = 0; i < itemCount; ++i)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)
                    {
                        swap(list, i, i + 1);
                        madeChanges = true;
                    }
                }
            } while (madeChanges);
        }

        static void swap(List<int> list, int index1, int index2)
        {
            int tmp = list[index1];
            list[index1] = list[index2];
            list[index2] = tmp;
            List<int> listCopy = new List<int>(list);
            if (Draw)
            {
                SwapOccured(null, new SwapEventArgs(listCopy, index1, index2));
            }
        }
    }
}
