using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBenchmark.Core
{

    /// <summary>
    /// 算法定义
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// 提交者的id
        /// </summary>
        string UserID { get; }

    }
}
