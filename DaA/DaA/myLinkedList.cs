using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DaA
{
    public class MyDoublyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node _head;
        private Node _tail;

        public MyDoublyLinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddFirst(T value)
        {
            var newNode = new Node(value);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);
            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        public void InsertAt(T value, int index)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException("Index out of range");

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Count)
            {
                AddLast(value);
            }
            else
            {
                var newNode = new Node(value);
                var current = _head;
                for (var i = 0; i < index; i++) current = current.Next;

                newNode.Previous = current.Previous;
                newNode.Next = current;
                current.Previous.Next = newNode;
                current.Previous = newNode;

                Count++;
            }
        }

        public bool Remove(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        _head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        _tail = current.Previous;

                    Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("Index out of range");

            var current = _head;
            for (var i = 0; i < index; i++) current = current.Next;

            if (current.Previous != null)
                current.Previous.Next = current.Next;
            else
                _head = current.Next;

            if (current.Next != null)
                current.Next.Previous = current.Previous;
            else
                _tail = current.Previous;

            Count--;
        }

        public T GetFirst()
        {
            if (_head == null) throw new InvalidOperationException("List is empty");
            return _head.Value;
        }

        public T GetLast()
        {
            if (_tail == null) throw new InvalidOperationException("List is empty");

            return _tail.Value;
        }

        private Node GetNodeAt(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index", "Index must be non-negative.");

            var currentNode = _head;
            var currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index) return currentNode;

                currentNode = currentNode.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException("index", "Index is out of the range of the list.");
        }


        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public int IndexOf(T value)
        {
            var index = 0;
            var current = _head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value)) return index;

                index++;
                current = current.Next;
            }

            return -1;
        }

        private int GetIndexOfNode(Node targetNode)
        {
            var currentNode = _head;
            var index = 0;

            while (currentNode != null)
            {
                if (currentNode == targetNode) return index;

                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }


        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        private void Swap(Node node1, Node node2)
        {
            var temp = node1.Value;
            node1.Value = node2.Value;
            node2.Value = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var current = _head;

            while (current != null)
            {
                sb.Append(current.Value);
                if (current.Next != null) sb.Append(", ");
                current = current.Next;
            }

            return sb.ToString();
        }


        public TimeSpan BubbleSort(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
                throw new ArgumentOutOfRangeException("Invalid start or end index.");

            var sw = Stopwatch.StartNew();

            bool swapped;
            var startNode = GetNodeAt(startIndex);
            var endNode = GetNodeAt(endIndex);

            do
            {
                swapped = false;
                var current = startNode;

                while (current != endNode)
                {
                    if (Comparer<T>.Default.Compare(current.Value, current.Next.Value) > 0)
                    {
                        Swap(current, current.Next);
                        swapped = true;
                    }

                    current = current.Next;
                }

                endNode = endNode.Previous;
            } while (swapped);

            sw.Stop();
            return sw.Elapsed;
        }


        public TimeSpan QuickSort(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            var sw = Stopwatch.StartNew();

            QuickSortInternal(startIndex, endIndex);
            sw.Stop();
            return sw.Elapsed;
        }

        private void QuickSortInternal(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var pivotIndex = Partition(startIndex, endIndex);
                QuickSortInternal(startIndex, pivotIndex - 1);
                QuickSortInternal(pivotIndex + 1, endIndex);
            }
        }

        private int Partition(int startIndex, int endIndex)
        {
            var pivotValue = GetNodeAt(endIndex).Value;
            var i = startIndex - 1;
            var currentNode = GetNodeAt(startIndex);

            for (var j = startIndex; j <= endIndex - 1; j++)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, pivotValue) < 0)
                {
                    i++;
                    Swap(GetNodeAt(i), currentNode);
                }

                currentNode = currentNode.Next;
            }

            Swap(GetNodeAt(i + 1), GetNodeAt(endIndex));

            return i + 1;
        }

        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            var sw = Stopwatch.StartNew();

            var currentNode = GetNodeAt(startIndex);
            for (var i = startIndex; i <= endIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, value))
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }

                currentNode = currentNode.Next;
            }

            return (false, sw.Elapsed);
        }

        public (bool, TimeSpan) BinarySearch(T value, int startIndex, int endIndex)
        {
            var sw = Stopwatch.StartNew();
            while (startIndex <= endIndex)
            {
                var middleIndex = startIndex + (endIndex - startIndex) / 2;
                var middleNode = GetNodeAt(middleIndex);

                var comparisonResult = Comparer<T>.Default.Compare(middleNode.Value, value);
                if (comparisonResult == 0)
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }

                if (comparisonResult < 0)
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

        private class Node
        {
            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
    }
}