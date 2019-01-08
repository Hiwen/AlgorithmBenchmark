using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Sorts.Example
{
    public static class IListExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="i"></param>
        /// <param name="d"></param>
        public static void Swap(this IList<int> ls, int i, ref int d)
        {
            int t = d;
            d = ls[i];
            ls[i] = d;
        }

        /// <summary>
        /// swap
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="ia"></param>
        /// <param name="ib"></param>
        public static void Swap(this IList<int> ls, int ia, int ib)
        {
            int t = ls[ia];
            ls[ia] = ls[ib];
            ls[ib] = t;
        }
    }
}
