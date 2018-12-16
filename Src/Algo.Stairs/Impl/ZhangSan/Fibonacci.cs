using Algo.Stairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangSan
{
    public class Fibonacci : IAlgorithmStairs
    {
        public string UserID => "Fibonacci";

        public int CalcClimbWayCount(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (n > 2)
                return CalcClimbWayCount(n - 1) + CalcClimbWayCount(n - 2);
            return 0;
        }
    }
}
