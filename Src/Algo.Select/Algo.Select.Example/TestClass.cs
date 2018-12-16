using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Select.Example
{
    public class TestClass : IAlgorithmSelect
    {
        public string UserID => "YeYing";

        public IList<Data> Select(IList<Data> oriDatas, IList<string> ids)
        {
            //var sset = new SortedSet<string>(ids);
            var sset = new HashSet<string>(ids);
            var temp = oriDatas.Where(_ => sset.Contains(_.Id));
            return temp?.ToList();
        }
    }
}
