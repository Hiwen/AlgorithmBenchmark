using Algo.Stairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangSan
{
    public class FibonacciEx : IAlgorithmStairs
    {
        public string UserID => "FibonacciEx";

        public int CalcClimbWayCount(int m)
        {
            if (m > 0 && m < 3)
            {
                return m == 1 ? 1 : 2;
            }

            int res = 0;
            int fnm1 = 1;
            int fnm2 = 2;

            // (a + b % x) == (a % x + b % x);

            for (int i = 3; i <= m; i++)
            {
                res = fnm1 + fnm2;

                if (res > PracticeStairsWrapper.ModeValue)
                {
                    res %= PracticeStairsWrapper.ModeValue;
                }

                fnm2 = fnm1;
                fnm1 = res;
            }

            return res;
        }
    }
}
