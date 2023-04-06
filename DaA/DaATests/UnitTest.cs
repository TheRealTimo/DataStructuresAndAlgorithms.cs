using System;
using System.Reflection;
using System.Xml.Linq;
using DaA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaATests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void TestAddFirst()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(1);

            Assert.AreEqual("1, 2", list.ToString());
        }

        [TestMethod]
        public void TestAddLast()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            Assert.AreEqual("1, 2", list.ToString());
        }

        [TestMethod]
        public void TestInsertAt()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.InsertAt(2, 1);

            Assert.AreEqual("1, 2, 3", list.ToString());
        }

        [TestMethod]
        public void TestRemove()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.Remove(2);

            Assert.AreEqual("1, 3", list.ToString());
        }

        [TestMethod]
        public void TestRemoveAt()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.RemoveAt(1);

            Assert.AreEqual("1, 3", list.ToString());
        }

        [TestMethod]
        public void TestQuickSort()
        {
            var list = new MyDoublyLinkedList<int>();
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
        public void TestQuickSortPartialRange()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(8);
            list.AddLast(3);

            list.QuickSort(1, 4);

            Assert.AreEqual("5, 1, 2, 8, 9, 3", list.ToString());
        }

        [TestMethod]
        public void TestBubbleSort()
        {
            var list = new MyDoublyLinkedList<int>();
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
        public void TestBubbleSortPartialRange()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(8);
            list.AddLast(3);

            list.BubbleSort(1, 4);

            Assert.AreEqual("5, 1, 2, 8, 9, 3", list.ToString());
        }

        [TestMethod]
        public void TestLinearSearch()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(8);
            list.AddLast(3);

            Assert.IsTrue(list.LinearSearch(9, 0, list.Count - 1));
            Assert.IsFalse(list.LinearSearch(10, 0, list.Count - 1));
            Assert.IsFalse(list.LinearSearch(8, 0, 3));
        }



        [TestMethod]
        public void TestBinarySearch()
        {
            var list = new MyDoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(2);
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(8);
            list.AddLast(3);

            Assert.IsTrue(list.BinarySearch(9, 0, list.Count - 1));
            Assert.IsFalse(list.BinarySearch(10, 0, list.Count - 1));
            Assert.IsFalse(list.BinarySearch(8, 0, 3));
        }
    }

    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void TestAdd()
        {
            var list = new MyArrayList<int>();
            list.Add(1);
            list.Add(2);

            Assert.AreEqual("1, 2", list.ToString());
        }

        [TestMethod]
        public void TestInsert()
        {
            var list = new MyArrayList<int>();
            list.Add(1);
            list.Add(3);
            list.Insert(1, 2);

            Assert.AreEqual("1, 2, 3", list.ToString());
        }

        [TestMethod]
        public void TestRemove()
        {
            var list = new MyArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(2);

            Assert.AreEqual("1, 3", list.ToString());
        }

        [TestMethod]
        public void TestRemoveAt()
        {
            var list = new MyArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveAt(1);

            Assert.AreEqual("1, 3", list.ToString());
        }

        [TestMethod]
        public void TestQuickSort()
        {
            var list = new MyArrayList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(9);
            list.Add(1);
            list.Add(8);
            list.Add(3);

            list.QuickSort(0, list.Count - 1);

            Assert.AreEqual("1, 2, 3, 5, 8, 9", list.ToString());
        }

        [TestMethod]
        public void TestQuickSortPartialRange()
        {
            var list = new MyArrayList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(9);
            list.Add(1);
            list.Add(8);
            list.Add(3);

            list.QuickSort(1, 4);

            Assert.AreEqual("5, 1, 2, 8, 9, 3", list.ToString());
        }

        [TestMethod]
        public void TestBubbleSort()
        {
            var list = new MyArrayList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(9);
            list.Add(1);
            list.Add(8);
            list.Add(3);

            list.BubbleSort(0, list.Count - 1);

            Assert.AreEqual("1, 2, 3, 5, 8, 9", list.ToString());
        }

        [TestMethod]
        public void TestBubbleSortPartialRange()
        {
            var list = new MyArrayList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(9);
            list.Add(1);
            list.Add(8);
            list.Add(3);

            list.BubbleSort(1, 4);

            Assert.AreEqual("5, 1, 2, 8, 9, 3", list.ToString());
        }

        [TestMethod]
        public void TestLinearSearch()
        {
            var list = new MyArrayList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(9);
            list.Add(1);
            list.Add(8);
            list.Add(3);

            Assert.IsTrue(list.LinearSearch(9, 0, list.Count - 1));
            Assert.IsFalse(list.LinearSearch(10, 0, list.Count - 1));
            Assert.IsFalse(list.LinearSearch(8, 0, 3));
        }

        [TestMethod]
        public void TestBinarySearch()
        {
            var list = new MyArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);
            list.Add(8);
            list.Add(9);

            Assert.IsTrue(list.BinarySearch(5, 0, list.Count - 1));
            Assert.IsFalse(list.BinarySearch(5, 0, 2));
        }
    }

    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TestAdd()
        {
            var tree = new MyBinaryTree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(9);
            tree.Add(1);
            tree.Add(8);
            tree.Add(3);

            Assert.IsTrue(tree.Contains(5));
            Assert.IsTrue(tree.Contains(2));
            Assert.IsTrue(tree.Contains(9));
            Assert.IsTrue(tree.Contains(1));
            Assert.IsTrue(tree.Contains(8));
            Assert.IsTrue(tree.Contains(3));
        }

        [TestMethod]
        public void TestRemove()
        {
            var tree = new MyBinaryTree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(9);
            tree.Add(1);
            tree.Add(8);
            tree.Add(3);

            tree.Remove(5);
            Assert.IsFalse(tree.Contains(5));
        }

        [TestMethod]
        public void TestQuickSort()
        {
            var tree = new MyBinaryTree<int>();
            tree.Add(9);
            tree.Add(2);
            tree.Add(5);
            tree.Add(1);
            tree.Add(8);
            tree.Add(3);

            tree.QuickSort(0, tree.Count - 1);

            Assert.AreEqual("1, 2, 3, 5, 8, 9", tree.ToString());
        }


        [TestMethod]
        public void TestBubbleSort()
        {
            var tree = new MyBinaryTree<int>();
            tree.Add(9);
            tree.Add(2);
            tree.Add(5);
            tree.Add(1);
            tree.Add(8);
            tree.Add(3);

            tree.BubbleSort(0, tree.Count - 1);

            Assert.AreEqual("1, 2, 3, 5, 8, 9", tree.ToString());
        }

        [TestMethod]
        public void TestLinearSearch()
        {
            var tree = new MyBinaryTree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(9);
            tree.Add(1);
            tree.Add(8);
            tree.Add(3);

            var list = tree.InOrderTraversal();

            Assert.IsTrue(tree.LinearSearch(9, 0, list.Count - 1));
            Assert.IsFalse(tree.LinearSearch(10, 0, list.Count - 1));
            Assert.IsFalse(tree.LinearSearch(8, 0, 3));
        }

        [TestMethod]
        public void TestBinarySearch()
        {
            var tree = new MyBinaryTree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(9);
            tree.Add(1);
            tree.Add(8);
            tree.Add(3);

            var list = tree.InOrderTraversal();

            Assert.IsTrue(tree.BinarySearch(5, 0, list.Count - 1));
            Assert.IsFalse(tree.BinarySearch(5, 0, 2));

        }



    }

}