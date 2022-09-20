using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib;

namespace lab1
{
    public class TestMethods
    {
        public int SlowPower(int x, int p)
        {
            int result = 1;
            for (int i = 0; i < p; i++)
                result *= x;
            return result;
        }

        public int FastPower(int x, int p)
        {
            int result = 1;
            while (p != 0)
            {
                if (p % 2 == 1)
                {
                    result *= x;
                }
                x *= x;
                p /= 2;
            }
            return result;
        }
    }
}