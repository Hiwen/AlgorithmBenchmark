using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Algo.Sorts.Test
{
    public class AlgoTester4Sorts : AlgoTesterBase<IAlgorithmSorts>
    {
        IList<int> _datas;
        Random _random = new Random();
        static Params _params;

        public override UserControl ParamsCtrl
        {
            get
            {
                if (_params == null)
                {
                    _params = new Params();
                }

                return _params;
            }
        }

        public AlgoTester4Sorts()
        {
        }

        IList<int> _exampleRes;

        void InitData()
        {
            var td = new List<int>();

            var dn = 10000;

            _params?.InvokeIfNeeded(()=> dn = _params.DataNum);
            
            var dataNum = _random.Next() % dn + dn;

            for (int i = 0; i < dataNum; i++)
            {
                td.Add(_random.Next());
            }

            _datas = td;
        }

        protected override void ExecExampe(IAlgorithm example)
        {
            InitData();

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
