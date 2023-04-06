using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DaA
{
    public class MyBinaryTree<T> where T : IComparable<T>
    {
        private Node root;

        public int Count => CountHelper(root);

        public void Add(T value)
        {
            if (root == null)
                root = new Node(value);
            else
                AddHelper(root, value);
        }

        private void AddHelper(Node node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new Node(value);
                else
                    AddHelper(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node(value);
                else
                    AddHelper(node.Right, value);
            }
        }

        public bool Contains(T value)
        {
            return ContainsHelper(root, value);
        }

        private bool ContainsHelper(Node node, T value)
        {
            if (node == null)
                return false;
            if (value.CompareTo(node.Value) == 0)
                return true;
            if (value.CompareTo(node.Value) < 0)
                return ContainsHelper(node.Left, value);
            return ContainsHelper(node.Right, value);
        }

        public void Remove(T value)
        {
            root = RemoveHelper(root, value);
        }

        private Node RemoveHelper(Node node, T value)
        {
            if (node == null) return null;

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = RemoveHelper(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = RemoveHelper(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                    return node.Right;
                if (node.Right == null) return node.Left;

                var minNode = FindMinNode(node.Right);
                node.Value = minNode.Value;
                node.Right = RemoveHelper(node.Right, minNode.Value);
            }

            return node;
        }

        private Node FindMinNode(Node node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        public List<T> InOrderTraversal()
        {
            var result = new List<T>();
            InOrderTraversalHelper(root, result);
            return result;
        }

        private void InOrderTraversalHelper(Node node, List<T> result)
        {
            if (node == null) return;

            InOrderTraversalHelper(node.Left, result);
            result.Add(node.Value);
            InOrderTraversalHelper(node.Right, result);
        }

        private void UpdateTree(List<T> elements)
        {
            Clear();
            foreach (var value in elements) Add(value);
        }

        public void Clear()
        {
            root = null;
        }


        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            var elements = InOrderTraversal();
            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
                throw new ArgumentOutOfRangeException();

            var sw = Stopwatch.StartNew();

            for (var i = startIndex; i <= endIndex; i++)
                if (EqualityComparer<T>.Default.Equals(elements[i], value))
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }

            sw.Stop();
            return (false, sw.Elapsed);
        }

        public (bool, TimeSpan) BinarySearch(T value, int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var elements = InOrderTraversal();
            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
                throw new ArgumentOutOfRangeException();
            var sw = Stopwatch.StartNew();

            if (comparer == null) comparer = Comparer<T>.Default;

            while (startIndex <= endIndex)
            {
                var middleIndex = startIndex + (endIndex - startIndex) / 2;
                var middleValue = elements[middleIndex];
                var compareResult = comparer.Compare(middleValue, value);

                if (compareResult == 0)
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }

                if (compareResult < 0)
                    startIndex = middleIndex + 1;
                else
                    endIndex = middleIndex - 1;
            }

            sw.Stop();
            return (false, sw.Elapsed);
        }

        public TimeSpan BubbleSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var sw = Stopwatch.StartNew();

            var elements = InOrderTraversal();
            if (comparer == null) comparer = Comparer<T>.Default;

            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
                throw new ArgumentOutOfRangeException();

            for (var i = startIndex; i <= endIndex; i++)
            for (var j = startIndex; j < endIndex - i + startIndex; j++)
                if (comparer.Compare(elements[j], elements[j + 1]) > 0)
                {
                    var temp = elements[j];
                    elements[j] = elements[j + 1];
                    elements[j + 1] = temp;
                }

            UpdateTree(elements);
            sw.Stop();
            return sw.Elapsed;
        }

        public TimeSpan QuickSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var sw = Stopwatch.StartNew();
            var elements = InOrderTraversal();
            if (comparer == null) comparer = Comparer<T>.Default;

            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
                throw new ArgumentOutOfRangeException();

            QuickSortHelper(elements, startIndex, endIndex, comparer);
            UpdateTree(elements);
            sw.Stop();
            return sw.Elapsed;
        }

        private void QuickSortHelper(List<T> elements, int start, int end, IComparer<T> comparer)
        {
            if (start >= end) return;

            var pivotIndex = Partition(elements, start, end, comparer);

            QuickSortHelper(elements, start, pivotIndex - 1, comparer);
            QuickSortHelper(elements, pivotIndex + 1, end, comparer);
        }

        private int Partition(List<T> elements, int start, int end, IComparer<T> comparer)
        {
            var pivot = elements[end];
            var pivotIndex = start;

            for (var i = start; i < end; i++)
                if (comparer.Compare(elements[i], pivot) < 0)
                {
                    var temp = elements[i];
                    elements[i] = elements[pivotIndex];
                    elements[pivotIndex] = temp;
                    pivotIndex++;
                }

            var temp2 = elements[end];
            elements[end] = elements[pivotIndex];
            elements[pivotIndex] = temp2;

            return pivotIndex;
        }

        private int CountHelper(Node node)
        {
            if (node == null) return 0;
            return 1 + CountHelper(node.Left) + CountHelper(node.Right);
        }

        public override string ToString()
        {
            var elements = InOrderTraversal();
            return string.Join(", ", elements);
        }

        private class Node
        {
            public Node Left;
            public Node Right;
            public T Value;

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
    }
}