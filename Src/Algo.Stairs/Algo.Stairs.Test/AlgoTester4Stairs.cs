using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Stairs.Test
{
    public class AlgoTester4Stairs : AlgoTesterBase<IAlgorithmStairs>
    {
        int _exampleRes = -1;

        Random _r = new Random();

        int _m = 10;

        public AlgoTester4Stairs()
        {
            _m = _r.Next() % 10 + 30;
        }
        


        protected override bool TestInner(IAlgorithmStairs algo)
        {
            var res = algo.CalcClimbWayCount(_m);
            return res == _exampleRes;
        }

        protected override void ExecExampe(IAlgorithm example)
        {
            if (_exampleRes == -1 && Example != null && Example is IAlgorithmStairs)
            {
                _exampleRes = ((IAlgorithmStairs)Example).CalcClimbWayCount(_m);
            }
        }
    }
}
