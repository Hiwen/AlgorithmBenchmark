using Algo.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select1
{
    public class ListHalf : IAlgorithmSelect
    {
        public string UserID => "ListHalf";

        public IList<Data> Select(IList<Data> oriDatas, IList<string> ids)
        {
            IList<Data> result = null;
            if (ids.Count < oriDatas.Count / 2)
            {
                result = oriDatas.Where(d => ids.Contains(d.Id)).ToList();
            }
            else
            {
                var excresult = oriDatas.Where(d => !ids.Contains(d.Id));
                result = oriDatas.Except(excresult).ToList();
            }

            return result;
        }
    }
}
