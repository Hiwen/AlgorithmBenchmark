using Algo.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select1
{
    public class List1 : IAlgorithmSelect
    {
        public string UserID => "List!";

        public IList<Data> Select(IList<Data> oriDatas, IList<string> ids)
        {
            IList<Data> result = null;

            var excresult = oriDatas.Where(d => !ids.Contains(d.Id));
            result = oriDatas.Except(excresult).ToList();

            return result;
        }
    }
}
