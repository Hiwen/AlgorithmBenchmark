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

        public string Desc => 
            "有一楼梯共m级，刚开始时你在第0级，" +
            "若每次只能走1级或者2级，要走上m级，共有多少走法？\n" +
            "不需要列举出来具体的走法,只需要计算出总方法数";

        public string Dir => "Stairs";
    }
}
