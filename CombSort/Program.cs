using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CombSort.App
{
    class Program
    {
        private static List<SwapEventArgs> frameList = new List<SwapEventArgs>();
        static void Main(string[] args)
        {
            int action;
            string input;
            Console.WriteLine("Visual Sorter");
            Console.WriteLine("Bartosz Jedrasik");
            Console.WriteLine("v. 0.1\n");
            do
            {
                Console.WriteLine("1. Visualize sort");
                Console.WriteLine("2. Perform sort tests");
            }
            while (!int.TryParse((input = Console.ReadLine()), out action) || action < 1 || action > 2);

            if (action == 1)
            {
                List<int> list = ListGenerator.RandomNoRepeat(55, 0, 55);
                if (Presenter.CanListBePresented(list))
                {
                    int sortType;
                    Sorter.SwapOccured += Sorter_SwapOccured;
                    do
                    {
                        Console.WriteLine("1. Comb sort");
                        Console.WriteLine("2. Quick sort");
                        Console.WriteLine("3. Bubble sort");
                    }
                    while (!int.TryParse((input = Console.ReadLine()), out sortType) || sortType < 1 || sortType > 3);
                    {
                        if (sortType == 1)
                        {
                            Sorter.CombSort(list, 1.3);
                        }
                        else if (sortType == 2)
                        {
                            Sorter.QuickSort(list, 0, list.Count - 1);
                        }
                        else if (sortType == 3)
                        {
                            Sorter.BubbleSort(list);
                        }
                    }
                    Presenter.SetPresentationSize();
                    Presenter.Animate(frameList);
                }
                else
                {
                    Console.WriteLine("Error: list cannot be presented");
                }
            }
            else if (action == 2)
            {
                int i = 0;
                List<TestResult> testResults = new List<TestResult>();
                for (var n = 10000; n <= 100000; n += 10000)
                {
                    testResults.Add(new TestResult(n));
                    string combPath = "/sorts/comb.txt";
                    foreach (TimeSpan combTime in testResults[i].CombTimes)
                    {
                        using (StreamWriter sw = File.AppendText(combPath))
                        {
                            sw.WriteLine(combTime.Ticks + '\n');
                        }
                    }
                    using (StreamWriter sw = File.AppendText(combPath))
                    {
                        sw.WriteLine('\n');
                    }
                    string bubblePath = "/sorts/bubble.txt";
                    using (StreamWriter sw = File.AppendText(bubblePath))
                    {
                        sw.WriteLine(testResults[i].BubbleTime.Ticks + '\n');
                    }
                    string insertionPath = "/sorts/insertion.txt";
                    using (StreamWriter sw = File.AppendText(insertionPath))
                    {
                        sw.WriteLine(testResults[i].InsertionTime.Ticks + '\n');
                    }
                    string quickPath = "/sorts/quick.txt";
                    using (StreamWriter sw = File.AppendText(quickPath))
                    {
                        sw.WriteLine(testResults[i].QuickTime.Ticks + '\n');
                    }
                    Console.WriteLine("Wrote for " + n);
                    ++i;
                }
            }
            Console.ReadKey(true);
        }

        static void Sorter_SwapOccured(object sender, SwapEventArgs e)
        {
            frameList.Add(e);
        }
    }
}
