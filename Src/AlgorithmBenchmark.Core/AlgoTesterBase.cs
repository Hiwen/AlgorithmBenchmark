using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlgorithmBenchmark.Core
{
    /// <summary>
    /// 测试器基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AlgoTesterBase<T> : IAlgoTester where T : IAlgorithm
    {
        /// <summary>
        /// 测试指定的算法并与ExecExampe中缓存的参考答案进行比较
        /// </summary>
        /// <param name="algo"></param>
        /// <returns>测试结果是否与参考答案一致</returns>
        protected abstract bool TestInner(T algo);

        /// <summary>
        /// 执行参考示例,并缓存参考答案供TestInner测试算法时进行比较
        /// </summary>
        /// <param name="example">算法的参考实现</param>
        protected abstract void ExecExampe(IAlgorithm example);

        /// <summary>
        /// 参数设置控件
        /// </summary>
        public virtual UserControl ParamsCtrl => null;

        /// <summary>
        /// 执行一个函数并计时
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        private TestResult TestFunc(Func<bool> func)
        {
            var result = new TestResult();

            var w = new Stopwatch();
            w.Start();
            if (func != null)
            {
                result.Successed = func.Invoke();
            }
            w.Stop();

            result.TimeCost = w.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// 测试一个算法并计时
        /// </summary>
        /// <param name="algo"></param>
        /// <returns></returns>
        public TestResult Test(IAlgorithm algo)
        {
            return TestFunc(() =>
            {
                if (algo != null && algo is T)
                {
                    return TestInner((T)algo);
                }
                return false;
            });
        }

        IAlgorithm _example;
        protected IAlgorithm Example => _example;

        /// <summary>
        /// 测试指定的算法
        /// </summary>
        /// <param name="algos"></param>
        /// <returns></returns>
        public IDictionary<string, TestResult> Test(IEnumerable<IAlgorithm> algos)
        {
            _example = algos.FirstOrDefault(p => p.UserID == AlgoBenchmarkCore.InnerID);

            var result = new Dictionary<string, TestResult>();
            if (_example != null)
            {
                var t = TestFunc(
                    () =>
                    {
                        ExecExampe(_example);
                        return true;
                    });
                result.Add(_example.UserID, t);

                foreach (var item in algos)
                {
                    if (!ReferenceEquals(_example, item))
                    {
                        t = Test(item);
                        result.Add(item.UserID, t);
                    }
                }
            }

            return result;
        }

    }
}
