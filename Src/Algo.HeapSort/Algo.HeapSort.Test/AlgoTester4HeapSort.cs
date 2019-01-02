using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.HeapSort.Test
{
    public class AlgoTester4HeapSort : AlgoTesterBase<IAlgorithmHeapSort>
    {

        IList<int> _datas;
        Random _random = new Random();

        public AlgoTester4HeapSort()
        {
            var td = new List<int>();

            var dataNum = _random.Next() % 10000 + 10000;

            for (int i = 0; i < dataNum; i++)
            {
                td.Add(_random.Next());
            }

            _datas = td;
        }

        IList<int> _exampleRes;


        protected override void ExecExampe(IAlgorithm example)
        {
            _exampleRes = ((IAlgorithmHeapSort)example).Sort(_datas);
        }

        protected override bool TestInner(IAlgorithmHeapSort algo)
        {
            var t = algo.Sort(_datas);
            if( t != null && t.Count == _exampleRes.Count)
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
