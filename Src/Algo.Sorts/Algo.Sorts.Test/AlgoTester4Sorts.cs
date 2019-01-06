using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts.Test
{
    public class AlgoTester4Sorts : AlgoTesterBase<IAlgorithmSorts>
    {
        IList<int> _datas;
        Random _random = new Random();

        public AlgoTester4Sorts()
        {
            var td = new List<int>();

            var dataNum = _random.Next() % 10000 + 100000;

            for (int i = 0; i < dataNum; i++)
            {
                td.Add(_random.Next());
            }

            _datas = td;
        }

        IList<int> _exampleRes;


        protected override void ExecExampe(IAlgorithm example)
        {
            var dt = new List<int>(_datas);

            _exampleRes = ((IAlgorithmSorts)example).Sort(dt);
        }

        protected override bool TestInner(IAlgorithmSorts algo)
        {
            var dt = new List<int>(_datas);
            var t = algo.Sort(dt);
            if (_exampleRes != null && t != null && t.Count == _exampleRes.Count)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    if (t[i] != _exampleRes[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
