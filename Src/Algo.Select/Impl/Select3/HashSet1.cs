using Algo.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select3
{

    public class HashSet1 : IAlgorithmSelect
    {
        public string UserID => "HashSet!";

        public IList<Data> Select(IList<Data> oriDatas, IList<string> ids)
        {

            var set = new HashSet<string>(ids);
            IList<Data> result = null;
            var excresult = oriDatas.Where(d => !set.Contains(d.Id));
            result = oriDatas.Except(excresult).ToList();

            return result;
        }
    }
}
