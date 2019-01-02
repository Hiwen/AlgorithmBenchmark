using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.HeapSort.Example
{
    public class HeapSortExample : IAlgorithmHeapSort
    {
        public string UserID => AlgoBenchmarkCore.InnerID;

        public IList<int> Sort(IList<int> datas)
        {
            return null;
        }
    }
}
