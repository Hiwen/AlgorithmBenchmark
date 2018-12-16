using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Stairs
{
    public class ZhangSan : IAlgorithmStairs
    {
        public string UserID => "ZhangSan";

        IDictionary<int, int> _buffer = new Dictionary<int, int>();
        public ZhangSan()
        {
            _buffer.Add(1, 1);
            _buffer.Add(2, 2);
        }

        public int CalcClimbWayCount(int m)
        {
            if (_buffer.ContainsKey(m))
            {
                return _buffer[m];
            }

            int res = 0;

            if (m == 1)
                res = 1;
            if (m == 2)
                res = 2;
            if (m > 2)
                res = CalcClimbWayCount(m - 1) % PracticeStairsWrapper.ModeValue +
                    CalcClimbWayCount(m - 2) % PracticeStairsWrapper.ModeValue;

            _buffer.Add(m, res);

            return res;
        }
    }
}
