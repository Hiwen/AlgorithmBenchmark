using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.HeapSort
{
    public class AlgorithmInfoHeapSort : IAlgorithmInfo
    {
        public string Name => "0004.堆排序";

        public string Desc => 
            "堆是一棵顺序存储的完全二叉树。\n" +
            "其中每个结点的关键字都不大于其孩子结点的关键字，这样的堆称为大根堆。\n" +
            "举例来说，对于n个元素的序列{R0, R1, ... , Rn},\n" +
            "当且仅当满足下列关系时，称之为大根堆：\n" +
            "       Ri >= R2i+1 且 Ri >= R2i+2 (大根堆)  其中i = 1,2,…,n/2向下取整";

        public string Dir => "HeapSort";
    }
}
