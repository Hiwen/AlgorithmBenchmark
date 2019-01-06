using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts
{
    public interface IAlgorithmSorts : IAlgorithm
    {
        /// <summary>
        /// 对指定的数据进行堆排序
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        IList<int> Sort(IList<int> datas);
    }
}
