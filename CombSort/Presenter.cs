using CombSort.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CombSort.App
{
    public static class Presenter
    {
        static private int _consoleWidth = 55;
        static private int _consoleHeight = 55;
        public static void SetPresentationSize()
        {
            Console.SetWindowSize(_consoleWidth + 1, _consoleHeight + 1);
        }
        public static void PrintFrame(SwapEventArgs state)
        {
            StringBuilder longWhite = new StringBuilder();
            for (var rowNo = _consoleHeight - 1; rowNo >= 0; --rowNo)
            {
                for (var colNo = 0; colNo < _consoleWidth; ++colNo)
                {
                    Console.ResetColor();
                    if (state.List[colNo] >= rowNo)
                    {
                        if (colNo == state.Index1 || colNo == state.Index2)
                        {
                            longWhite.Append('\u2588');
                        }
                        else
                        {
                            longWhite.Append('I');
                        }
                    }
                    else
                    {
                        longWhite.Append(' ');
                    }
                }
                longWhite.Append('\n');
            }
            Console.Clear();
            Console.Write(longWhite);
        }

        public static void Animate(List<SwapEventArgs> frameList)
        {
            for (var i=0; i<frameList.Count; ++i)
            {
                PrintFrame(frameList[i]);
            }
            frameList.Clear();
        }

        public static bool CanListBePresented(List<int> list)
        {
            if (list.Count <= _consoleWidth && list.Max() <= _consoleHeight && list.Min() >= 0 )
            {
                return true;
            }
            return false;
        }
    }
}
