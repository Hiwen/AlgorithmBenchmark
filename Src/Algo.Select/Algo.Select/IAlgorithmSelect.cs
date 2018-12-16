using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Select
{
    public interface IAlgorithmSelect : IAlgorithm
    {
        /// <summary>
        /// 实现从oriDatas中筛选出Data.Id在ids中的所有数据
        /// </summary>
        /// <param name="oriDatas"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        IList<Data> Select(IList<Data> oriDatas, IList<string> ids);
    }
}
