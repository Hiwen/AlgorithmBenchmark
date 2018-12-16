using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Select.Example
{
    public class SelectExample : IAlgorithmSelect
    {
        public string UserID => AlgoBenchmarkCore.InnerID;


        public IList<Data> Select(IList<Data> oriDatas, IList<string> ids)
        {
            var set = new HashSet<string>(ids);
            IList<Data> result = null;
            if (ids.Count < oriDatas.Count / 2)
            {
                result = oriDatas.Where(d => set.Contains(d.Id)).ToList();
            }
            else
            {
                var excresult = oriDatas.Where(d => !set.Contains(d.Id));
                result = oriDatas.Except(excresult).ToList();
            }

            return result;
        }
    }
}
