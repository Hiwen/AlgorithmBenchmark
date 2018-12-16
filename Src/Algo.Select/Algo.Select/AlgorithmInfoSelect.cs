using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Select
{
    /// <summary>
    /// 筛选出集合中在指定id集合中的数据
    /// </summary>
    public class AlgorithmInfoSelect : IAlgorithmInfo
    {
        public string Name => "数据快速筛选";

        public string Desc => "从指定的集合中快速筛选出某些数据";

        public string Dir => "Select";
        
    }
}
