using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.TopX
{
    public interface IAlgorithmTopX : IAlgorithm
    {
        /// <summary>
        /// 找出datas中前x个最大数
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        IList<int> TopX(IEnumerable<int> datas, int x);
    }
}
