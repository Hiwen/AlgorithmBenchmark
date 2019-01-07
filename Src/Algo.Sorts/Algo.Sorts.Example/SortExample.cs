using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts.Example
{
    public class SortExample : IAlgorithmSorts
    {
        public string UserID => AlgoBenchmarkCore.InnerID;

        public IList<int> Sort(IList<int> datas)
        {
            var temp = datas as List<int>;
            temp.Sort();
            return temp;
        }
    }
}
