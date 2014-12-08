using CombSort.App;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombSort.Tests
{
    [TestFixture]
    public class SorterTests
    {
        private List<int> _initial;
        private List<int> _desired;

        [SetUp]
        public void SetUp()
        {
            _initial = new List<int> { 5, 6, 3, 8, 2, 1, 3, 7, 4 };
            _desired = new List<int> { 1, 2, 3, 3, 4, 5, 6, 7, 8 };
        }

        [Test]
        public void CombSort_ReturnsSorted()
        {
            Sorter.CombSort(_initial, 1.4);
            Assert.AreEqual(_initial, _desired);
        }

        [Test]
        public void QuickSort_ReturnsSorted()
        {
            Sorter.QuickSort(_initial, 0 , _initial.Count - 1);
            Assert.AreEqual(_initial, _desired);
        }

        [Test]
        public void InsertionSort_ReturnsSorted()
        {
            Sorter.InsertionSort(_initial);
            Assert.AreEqual(_initial, _desired);
        }

        [Test]
        public void BubbleSort_ReturnsSorted()
        {
            Sorter.BubbleSort(_initial);
            Assert.AreEqual(_initial, _desired);
        }
    }
}
