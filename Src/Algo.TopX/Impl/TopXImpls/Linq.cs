using Algo.TopX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopXImpls
{
    public class Linq : IAlgorithmTopX
    {
        public string UserID => "Linq";

        public IList<int> TopX(IEnumerable<int> datas, int x)
        {
            var temp = datas.OrderBy(i => i);
            return temp.Take(x).ToList();
        }
    }
}
