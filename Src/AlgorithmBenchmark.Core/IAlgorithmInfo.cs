using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBenchmark.Core
{
    /// <summary>
    /// 算法描述
    /// </summary>
    public interface IAlgorithmInfo : ILoaderable
    {
        /// <summary>
        /// 算法的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 算法的介绍
        /// </summary>
        string Desc { get; }

    }
}
