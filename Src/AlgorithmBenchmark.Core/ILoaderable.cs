using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBenchmark.Core
{
    public interface ILoaderable
    {
        /// <summary>
        /// 加载目录
        /// </summary>
        string Dir { get; }
    }
}
