using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBenchmark.Core
{
    /// <summary>
    /// 算法加载接口定义
    /// </summary>
    public interface ILoader4Algo : ILoader
    {
        /// <summary>
        /// 算法列表
        /// </summary>
        IEnumerable<IAlgorithmInfo> GetAllAlgoInfos(Action<int> pr);

        /// <summary>
        /// 获取指定算法的测试器
        /// </summary>
        /// <param name="algo"></param>
        /// <returns></returns>
        IAlgoTester GetTester(IAlgorithmInfo algo);

        /// <summary>
        /// 获取指定话题的所有答卷
        /// </summary>
        /// <param name="algo"></param>
        /// <returns></returns>
        IEnumerable<IAlgorithm> GetAllAlgos(IAlgorithmInfo algo, Action<int> pr);

        /// <summary>
        /// 获取指定算法的题目接口类型
        /// </summary>
        /// <param name="algo"></param>
        /// <returns></returns>
        Type GetPracticeInterfaceType(IAlgorithmInfo algo);
    }
}
