using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBenchmark.Core
{
    /// <summary>
    /// 测试结果
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// 是否通过
        /// </summary>
        public bool Successed { get; set; } = false;

        /// <summary>
        /// 运行时间开销
        /// </summary>
        public double TimeCost { get; set; }

        /// <summary>
        /// 运行内存开销
        /// </summary>
        public double MemoryCost { get; set; }

        public static TestResult operator +(TestResult dst, TestResult src)
        {
            var r = new TestResult();
            r.Successed = dst.Successed && src.Successed;
            r.TimeCost = dst.TimeCost + src.TimeCost;
            r.MemoryCost = dst.MemoryCost + src.MemoryCost;

            return r;
        }
    }
}
