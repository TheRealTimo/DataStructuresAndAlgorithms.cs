using DaA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaATests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void TestBubbleSort()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(8);
            list.AddLast(3);

            list.BubbleSort(0, list.Count - 1);

            Assert.AreEqual("1, 2, 3, 5, 8, 9", list.ToString());
        }

        [TestMethod]
        public void TestQuickSort()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(8);
            list.AddLast(3);

            list.QuickSort(0, list.Count - 1);

            Assert.AreEqual("1, 2, 3, 5, 8, 9", list.ToString());
        }

        [TestMethod]
        public void TestLinearSearch()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(8);
            list.AddLast(3);

            Assert.IsTrue(list.LinearSearch(9, 0, list.Count - 1));
            Assert.IsFalse(list.LinearSearch(10, 0, list.Count - 1));
        }

        [TestMethod]
        public void TestExponentialSearch()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(9);

            Assert.IsTrue(list.ExponentialSearch(5, 0, list.Count - 1));
            Assert.IsFalse(list.ExponentialSearch(5, 0 , 2));
        }
    }
}