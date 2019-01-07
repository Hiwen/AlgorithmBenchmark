using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts.Example
{
    public class SortLinq : IAlgorithmSorts
    {
        public string UserID => "Linq.Sort";

        public IList<int> Sort(IList<int> datas)
        {
            return datas.OrderBy(i => i).ToArray();
        }
    }
}
