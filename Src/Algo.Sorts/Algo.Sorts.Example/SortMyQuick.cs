using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts.Example
{
    public class SortMyQuick : IAlgorithmSorts
    {
        public string UserID => "MyQuickSort";

        public IList<int> Sort(IList<int> datas)
        {
            QuickSort(datas, 0, datas.Count);
            return datas;
        }

        void QuickSort(IList<int> datas, int b, int e)
        {
            if (b < e)
            {
                int p = b;
                int idx = p + 1;
                int pv = datas[p];
                for (int i = idx; i < e; i++)
                {
                    if (datas[i] < pv)
                    {
                        datas.Swap(i, idx);
                        idx++;
                    }
                }
                idx--;
                datas.Swap(p, idx);

                QuickSort(datas, b, idx);
                QuickSort(datas, idx + 1, e);
            }
        }
    }
}
