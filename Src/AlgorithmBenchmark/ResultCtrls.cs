using AlgorithmBenchmark.ResultCtrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBenchmark
{
    /// <summary>
    /// 
    /// </summary>
    class ResultCtrls
    {
        /// <summary>
        /// 结果控件集合
        /// </summary>
        public static IList<IResultCtrl> ResultCtrl = new [] 
        {
            new ResultCtrl4Chart() as IResultCtrl,
            new ResultCtrl4Grid() as IResultCtrl,
            new ResultCtrl4Log() as IResultCtrl,
        };

    }
}
