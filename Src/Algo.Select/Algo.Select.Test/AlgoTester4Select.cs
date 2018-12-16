using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Select.Test
{
    public class AlgoTester4Select : AlgoTesterBase<IAlgorithmSelect>
    {
        IList<Data> _gdata;
        IList<Data> GeneraterData()
        {
            if (_gdata == null)
            {
                _gdata = new List<Data>();
                for (int i = 0; i < 10000; i++)
                {
                    _gdata.Add(new Data() { Id = i.ToString() });
                }
            }

            return _gdata;
        }

        IList<string> _gId;
        IList<string> GeneraterId()
        {
            if (_gId == null)
            {
                var data = GeneraterData();
                if (data != null)
                {
                    var r = new Random();
                    var key = r.Next() % 100 + 1;

                    _gId = data.
                        Where( (d, i) => i % key == 0).
                        Select(d => d.Id).
                        ToList();
                }
            }
            return _gId;
        }

        IList<Data> _edata;


        protected override bool TestInner(IAlgorithmSelect algo)
        {
            var t = algo.Select(GeneraterData(), GeneraterId());
            if (Example != null)
            {
                var te = _edata;
                if (t?.Count == te?.Count)
                {
                    return t.Except(te).Count() == 0 && te.Except(t).Count() == 0;
                }
            }

            return false;
        }
        
        protected override void ExecExampe(IAlgorithm example)
        {
            if (_edata == null && example != null && example is IAlgorithmSelect)
            {
                var exp = (IAlgorithmSelect)example;
                if (exp != null)
                {
                    _edata = exp.Select(GeneraterData(), GeneraterId());
                }
            }
        }
    }
}
