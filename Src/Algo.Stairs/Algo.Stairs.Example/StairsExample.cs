using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algo.Stairs.Example
{
    public class StairsExample : IAlgorithmStairs
    {
        public string UserID => AlgoBenchmarkCore.InnerID;
        
        public int CalcClimbWayCount(int m)
        {
            int res = 0;

            if (m > 0 && m < 3)
            {
                res = m == 1 ? 1 : 2;
            }
            else
            {
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
            }

            return res;
        }
    }
}
