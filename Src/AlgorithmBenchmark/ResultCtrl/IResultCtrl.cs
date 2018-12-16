using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlgorithmBenchmark.ResultCtrl
{
    /// <summary>
    /// 结果展示控件接口定义
    /// </summary>
    public interface IResultCtrl
    {
        /// <summary>
        /// 展示结果
        /// </summary>
        void ShowResult(IDictionary<string, TestResult> result);

        /// <summary>
        /// 展示控件
        /// </summary>
        UserControl Ctrl { get; }

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; }
    }
}
