using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaA
{
    public class MyBinaryTree<T> where T : IComparable<T>
    {
        private Node root;

        private class Node
        {
            public T Value;
            public Node Left;
            public Node Right;

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                AddHelper(root, value);
            }
        }

        private void AddHelper(Node node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    AddHelper(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    AddHelper(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            return ContainsHelper(root, value);
        }

        private bool ContainsHelper(Node node, T value)
        {
            if (node == null)
            {
                return false;
            }
            else if (value.CompareTo(node.Value) == 0)
            {
                return true;
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                return ContainsHelper(node.Left, value);
            }
            else
            {
                return ContainsHelper(node.Right, value);
            }
        }

        public void Remove(T value)
        {
            root = RemoveHelper(root, value);
        }

        private Node RemoveHelper(Node node, T value)
        {
            if (node == null)
            {
                return null;
            }

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
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                Node minNode = FindMinNode(node.Right);
                node.Value = minNode.Value;
                node.Right = RemoveHelper(node.Right, minNode.Value);
            }

            return node;
        }

        private Node FindMinNode(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
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
            foreach (T value in elements)
            {
                Add(value);
            }
        }

        public void Clear()
        {
            root = null;
        }


        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            List<T> elements = InOrderTraversal();
            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(elements[i], value))
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }
            }
            sw.Stop();
            return (false, sw.Elapsed);
        }

        public (bool, TimeSpan) BinarySearch(T value, int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            List<T> elements = InOrderTraversal();
            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException();
            }
            Stopwatch sw = Stopwatch.StartNew();

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            while (startIndex <= endIndex)
            {
                int middleIndex = startIndex + (endIndex - startIndex) / 2;
                T middleValue = elements[middleIndex];
                int compareResult = comparer.Compare(middleValue, value);

                if (compareResult == 0)
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }
                else if (compareResult < 0)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex - 1;
                }
            }
            sw.Stop();
            return (false, sw.Elapsed);
        }

        public TimeSpan BubbleSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {

            Stopwatch sw = Stopwatch.StartNew();

            List<T> elements = InOrderTraversal();
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                for (int j = startIndex; j < endIndex - i + startIndex; j++)
                {
                    if (comparer.Compare(elements[j], elements[j + 1]) > 0)
                    {
                        T temp = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = temp;
                    }
                }
            }

            UpdateTree(elements);
            sw.Stop();
            return sw.Elapsed;
        }

        public TimeSpan QuickSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {

            Stopwatch sw = Stopwatch.StartNew();
            List<T> elements = InOrderTraversal();
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            if (startIndex < 0 || endIndex >= elements.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            QuickSortHelper(elements, startIndex, endIndex, comparer);
            UpdateTree(elements);
            sw.Stop();
            return sw.Elapsed;
        }

        private void QuickSortHelper(List<T> elements, int start, int end, IComparer<T> comparer)
        {
            if (start >= end) return;

            int pivotIndex = Partition(elements, start, end, comparer);

            QuickSortHelper(elements, start, pivotIndex - 1, comparer);
            QuickSortHelper(elements, pivotIndex + 1, end, comparer);
        }

        private int Partition(List<T> elements, int start, int end, IComparer<T> comparer)
        {
            T pivot = elements[end];
            int pivotIndex = start;

            for (int i = start; i < end; i++)
            {
                if (comparer.Compare(elements[i], pivot) < 0)
                {
                    T temp = elements[i];
                    elements[i] = elements[pivotIndex];
                    elements[pivotIndex] = temp;
                    pivotIndex++;
                }
            }

            T temp2 = elements[end];
            elements[end] = elements[pivotIndex];
            elements[pivotIndex] = temp2;

            return pivotIndex;
        }

        public int Count
        {
            get { return CountHelper(root); }
        }

        private int CountHelper(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + CountHelper(node.Left) + CountHelper(node.Right);
        }

        public override string ToString()
        {
            List<T> elements = InOrderTraversal();
            return string.Join(", ", elements);
        }



    }

}
