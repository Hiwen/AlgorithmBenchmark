using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Stairs
{
    /// <summary>
    /// 有一楼梯共m级，刚开始时你在第一级，
    /// 若每次只能跨上一级或者二级，
    /// 要走上m级，共有多少走法？
    /// 
    /// 注：规定从一级到一级有0种走法。
    /// 给定一个正整数int m，请返回一个数，代表上楼的方式数。
    /// 保证m小于等于100。
    /// 为了防止溢出，请返回结果Mod 1000000007的值
    /// </summary>
    public interface IAlgorithmStairs : IAlgorithm
    {

        /// <summary>
        /// 计算上楼方法数
        /// </summary>
        /// <param name="m">楼梯阶数</param>
        /// <returns>上楼方法数,为了防止溢出，请返回结果Mod 1000000007的值</returns>
        int CalcClimbWayCount(int m);
        
    }

    public class PracticeStairsWrapper
    {
        /// <summary>
        /// 取模值定义
        /// </summary>
        public static int ModeValue => 1000000007;
    }

}
