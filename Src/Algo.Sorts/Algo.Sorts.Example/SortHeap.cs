using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts.Example
{
    // HeapSort
    public class SortHeap : IAlgorithmSorts
    {

        public string UserID => "HeapSort";

        public IList<int> Sort(IList<int> datas)
        {
            int c = datas.Count;

            for (int i = c / 2; i >= 0; i--)
            {
                MaxHeap(datas, i, c - 1);
            }

            for (int i = c - 1; i >= 0; i--)
            {
                datas.Swap(0, i);
                MaxHeap(datas, 0, i - 1);
            }

            return datas;
        }


        void MaxHeap(IList<int> datas, int begin, int end)
        {
            int dad = begin;
            int son = dad * 2 + 1;

            while (son <= end)
            {
                if (son + 1 <= end && datas[son] < datas[son + 1])
                {
                    son++;
                }

                if (datas[dad] > datas[son])
                {
                    return;
                }
                else
                {
                    datas.Swap(dad, son);
                    dad = son;
                    son = dad * 2 + 1;
                }
            }
        }
    }
}
