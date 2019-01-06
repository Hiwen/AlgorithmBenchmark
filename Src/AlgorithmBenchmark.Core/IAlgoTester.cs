using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlgorithmBenchmark.Core
{
    /// <summary>
    /// 算法测试接口定义
    /// </summary>
    public interface IAlgoTester
    {
        /// <summary>
        /// 测试指定的所有算法
        /// </summary>
        /// <param name="algos"></param>
        /// <returns></returns>
        IDictionary<string, TestResult> Test(IEnumerable<IAlgorithm> algos);

        /// <summary>
        /// 参数设置控件
        /// </summary>
        UserControl ParamsCtrl { get; }
    }
}
