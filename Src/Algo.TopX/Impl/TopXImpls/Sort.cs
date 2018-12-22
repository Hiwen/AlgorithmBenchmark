using Algo.TopX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopXImpls
{
    public class Sort : IAlgorithmTopX
    {
        public string UserID => "Sort";

        public IList<int> TopX(IEnumerable<int> datas, int x)
        {
            var temp = datas.ToList();
            temp.Sort();

            return temp.GetRange(0, 100);
        }
    }
}
