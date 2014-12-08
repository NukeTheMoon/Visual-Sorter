using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombSort
{
    public static class ListGenerator
    {
        public static List<int> Random(int count, int minValue, int maxValue)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            for (var i=0; i<count; ++i)
            {
                list.Add(rnd.Next(minValue, maxValue));
            }
            return list;
        }

        public static List<int> RandomNoRepeat(int count, int minValue, int maxValue)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            for (var i = 0; i < count; ++i)
            {
                int randomValue = rnd.Next(minValue, maxValue);
                if (!list.Contains(randomValue))
                {
                    list.Add(randomValue);
                }
                else
                {
                    --i;
                }
            }
            return list;
        }
    }
}
