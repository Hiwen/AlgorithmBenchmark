﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts.Example
{
    /// 归并排序是建立在归并操作上的一种有效的排序算法。
    /// 该算法是采用分治法（Divide and Conquer）的一个非常典型的应用。
    /// 将已有序的子序列合并，得到完全有序的序列；
    /// 即先使每个子序列有序，再使子序列段间有序。
    /// 若将两个有序表合并成一个有序表，称为2-路归并。 
    /// 
    /// 算法描述
    /// 把长度为n的输入序列分成两个长度为n/2的子序列；
    /// 对这两个子序列分别采用归并排序；
    /// 将两个排序好的子序列合并成一个最终的排序序列。
    public class SortMerge : IAlgorithmSorts
    {
        public string UserID => "MergeSort";

        public IList<int> Sort(IList<int> datas)
        {
            return MerageSort(datas, 0, datas.Count - 1);
        }


        IList<int> MerageSort(IList<int> datas, int b, int e)
        {
            if (b >= e)
            {
                return datas;
            }

            if (e - b == 1)
            {
                if (datas[b] > datas[e])
                {
                    datas.Swap(b, e);
                }
                return datas;
            }
            else
            {
                int m = (b + e) / 2;

                MerageSort(datas, b, m);
                MerageSort(datas, m + 1, e);

                int f = b, s = m + 1;
                
                var dataRes = new List<int>(e - b + 1);
                while (f <= m || s <= e)
                {
                    if (f <= m && s <= e)
                    {
                        if (datas[f] >= datas[s])
                        {
                            dataRes.Add(datas[s]);
                            s++;
                        }
                        else
                        {
                            dataRes.Add(datas[f]);
                            f++;
                        }
                    }
                    else if (f <= m)
                    {
                        dataRes.Add(datas[f]);
                        f++;
                    }
                    else if (s <= e)
                    {
                        dataRes.Add(datas[s]);
                        s++;
                    }
                }

                for (int i = 0; i < dataRes.Count; i++)
                {
                    datas[b + i] = dataRes[i];
                }
                
                return datas;
            }
        }
    }
}
