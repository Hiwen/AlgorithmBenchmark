using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.TopX.Example
{
    public class TopXExample : IAlgorithmTopX
    {
        public string UserID => AlgoBenchmarkCore.InnerID;

        public IList<int> TopX(IEnumerable<int> datas, int x)
        {
            if (datas == null || datas.Count() < 1)
            {
                return null;
            }

            if (datas.Count() <= x)
            {
                return datas.ToList();
            }

            var temp = new Dictionary<int, int>();

            int addedMin = datas.First();
            int addedCount = 0;

            foreach (var item in datas)
            {
                if (addedCount < x)
                {
                    if (temp.ContainsKey(item))
                    {
                        temp[item]++;
                    }
                    else
                    {
                        temp.Add(item, 1);
                    }

                    addedMin = Math.Min(addedMin, item);
                    addedCount++;
                }
                else
                {
                    if (item > addedMin)
                    {
                        if (temp.ContainsKey(item))
                        {
                            temp[item]++;
                        }
                        else
                        {
                            if (temp[addedMin] > 1)
                            {
                                temp[addedMin]--;
                            }
                            else
                            {
                                temp.Remove(addedMin);
                                addedMin = temp.Min(p => p.Key);
                            }

                            temp.Add(item, 1);
                            addedMin = Math.Min(item, addedMin);
                        }
                    }
                }
            }

            var res = new List<int>(x);
            foreach (var item in temp)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    res.Add(item.Key);
                }
            }

            return res;
        }
    }
}
