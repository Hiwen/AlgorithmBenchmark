using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.TopX.Test
{
    public class AlgoTester4TopX : AlgoTesterBase<IAlgorithmTopX>
    {
        IEnumerable<int> _datas;
        Random _random = new Random();
        int _x = 100;

        public AlgoTester4TopX()
        {
            var td = new List<int>();

            var dataNum =  _random.Next() % 10000  + 10000;

            for (int i = 0; i < dataNum; i++)
            {
                td.Add(_random.Next());
            }

            _datas = td;

            _x = _random.Next() % 50 + 50;
        }

        IList<int> _exampleRes;


        protected override void ExecExampe(IAlgorithm example)
        {
            _exampleRes = ((IAlgorithmTopX)example).TopX(_datas, _x);
        }

        protected override bool TestInner(IAlgorithmTopX algo)
        {
            var t = algo.TopX(_datas, _x);
            return t != null && t.Count == _exampleRes.Count && 
                t.Except(_datas).Count() == 0;
        }
    }
}
