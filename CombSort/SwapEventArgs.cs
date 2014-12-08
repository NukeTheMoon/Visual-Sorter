using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombSort
{
    public class SwapEventArgs
    {
        public List<int> List { get; set; }
        public int Index1 { get; set; }
        public int Index2 { get; set; }

        public SwapEventArgs(List<int> list, int index1, int index2)
        {
            List = list;
            Index1 = index1;
            Index2 = index2;
        }
    }
}
