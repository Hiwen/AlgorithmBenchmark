using Algo.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select1
{
    public class List : IAlgorithmSelect
    {
        public string UserID => "List";

        public IList<Data> Select(IList<Data> oriDatas, IList<string> ids)
        {
            IList<Data> result = null;
            result = oriDatas.Where(d => ids.Contains(d.Id)).ToList();
            return result;
        }
    }
}
