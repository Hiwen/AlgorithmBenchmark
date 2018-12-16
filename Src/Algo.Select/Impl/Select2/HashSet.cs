using Algo.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select2
{

    public class HashSet : IAlgorithmSelect
    {
        public string UserID => "HashSet";

        public IList<Data> Select(IList<Data> oriDatas, IList<string> ids)
        {
            var set = new HashSet<string>(ids);
            IList<Data> result = null;
            result = oriDatas.Where(d => set.Contains(d.Id)).ToList();

            return result;
        }
    }
}
