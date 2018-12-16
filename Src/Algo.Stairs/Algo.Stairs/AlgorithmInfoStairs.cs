using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Stairs
{
    /// <summary>
    /// 筛选出集合中在指定id集合中的数据
    /// </summary>
    public class AlgorithmInfoStairs : IAlgorithmInfo
    {
        public string Name => "0002.计算上楼梯的方法数";

        public string Desc => "有一楼梯共m级，刚开始时你在第一级，若每次只能跨上一级或者二级，要走上m级，共有多少走法？";

        public string Dir => "Stairs";
    }
}
