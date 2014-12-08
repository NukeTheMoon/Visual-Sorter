using CombSort.App;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombSort
{
    public class TestResult
    {
        public int SampleSize;
        public List<TimeSpan> CombTimes;
        public TimeSpan InsertionTime;
        public TimeSpan BubbleTime;
        public TimeSpan QuickTime;

        public TestResult(int sampleSize)
        {
            SampleSize = sampleSize;
            CombTimes = new List<TimeSpan>();
            List<int> testList = ListGenerator.Random(sampleSize, -9999, +9999);
            Sorter.Draw = false;
            for (double shrink = 1.05; shrink < 2.05; shrink += 0.05)
            {
                List<int> testCloneComb = new List<int>(testList);
                Stopwatch stopWatchComb = Stopwatch.StartNew();
                Sorter.CombSort(testCloneComb, shrink);
                stopWatchComb.Stop();
                CombTimes.Add(stopWatchComb.Elapsed);
            }

            List<int> testCloneBubble = new List<int>(testList);
            Stopwatch stopWatchBubble = Stopwatch.StartNew();
            Sorter.BubbleSort(testCloneBubble);
            stopWatchBubble.Stop();
            BubbleTime = stopWatchBubble.Elapsed;

            List<int> testCloneInsert = new List<int>(testList);
            Stopwatch stopWatchInsert = Stopwatch.StartNew();
            Sorter.InsertionSort(testCloneInsert);
            stopWatchInsert.Stop();
            InsertionTime = stopWatchInsert.Elapsed;

            List<int> testCloneQuick = new List<int>(testList);
            Stopwatch stopWatchQuick = Stopwatch.StartNew();
            Sorter.InsertionSort(testCloneQuick);
            stopWatchQuick.Stop();
            QuickTime = stopWatchQuick.Elapsed;
        }
    }
}
