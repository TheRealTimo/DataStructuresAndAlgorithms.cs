using System.Collections.Generic;
using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace DaA
{
    public class MyDoublyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }

        private Node _head;
        private Node _tail;
        private int _count;

        public MyDoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);
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
            _count++;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);
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
            _count++;
        }

        public void InsertAt(T value, int index)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == _count)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                newNode.Previous = current.Previous;
                newNode.Next = current;
                current.Previous.Next = newNode;
                current.Previous = newNode;

                _count++;
            }
        }

        public bool Remove(T value)
        {
            Node current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        _head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        _tail = current.Previous;
                    }

                    _count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            Node current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                _head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                _tail = current.Previous;
            }

            _count--;
        }

        public T GetFirst()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return _head.Value;
        }

        public T GetLast()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            return _tail.Value;
        }

        private Node GetNodeAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Index must be non-negative.");
            }

            Node currentNode = _head;
            int currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException("index", "Index is out of the range of the list.");
        }


        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int IndexOf(T value)
        {
            int index = 0;
            Node current = _head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return index;
                }

                index++;
                current = current.Next;
            }

            return -1;
        }
        private int GetIndexOfNode(Node targetNode)
        {
            Node currentNode = _head;
            int index = 0;

            while (currentNode != null)
            {
                if (currentNode == targetNode)
                {
                    return index;
                }

                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }


        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = _head;
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
        private void Swap(Node node1, Node node2)
        {
            T temp = node1.Value;
            node1.Value = node2.Value;
            node2.Value = temp;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node current = _head;

            while (current != null)
            {
                sb.Append(current.Value);
                if (current.Next != null)
                {
                    sb.Append(", ");
                }
                current = current.Next;
            }

            return sb.ToString();
        }



        public TimeSpan BubbleSort(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            bool swapped;
            Node startNode = GetNodeAt(startIndex);
            Node endNode = GetNodeAt(endIndex);

            do
            {
                swapped = false;
                Node current = startNode;

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

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }


        public TimeSpan QuickSort(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSortInternal(startIndex, endIndex);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        private void QuickSortInternal(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = Partition(startIndex, endIndex);
                QuickSortInternal(startIndex, pivotIndex - 1);
                QuickSortInternal(pivotIndex + 1, endIndex);
            }
        }

        private int Partition(int startIndex, int endIndex)
        {
            T pivotValue = GetNodeAt(endIndex).Value;
            int i = startIndex - 1;
            Node currentNode = GetNodeAt(startIndex);

            for (int j = startIndex; j <= endIndex - 1; j++)
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

        public (bool,TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Node currentNode = GetNodeAt(startIndex);
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, value))
                {
                    stopwatch.Stop();
                    return (true, stopwatch.Elapsed);
                }
                currentNode = currentNode.Next;
            }
            stopwatch.Stop();
            return (false, stopwatch.Elapsed);
        }

        public (bool, TimeSpan) ExponentialSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (EqualityComparer<T>.Default.Equals(GetNodeAt(startIndex).Value, value))
            {
                stopwatch.Stop();
                return (true, stopwatch.Elapsed);
            }

            int bound = 1;
            while (bound < endIndex - startIndex + 1 && Comparer<T>.Default.Compare(GetNodeAt(startIndex + bound).Value, value) <= 0)
            {
                bound *= 2;
            }

            int newStartIndex = startIndex + bound / 2;
            int newEndIndex = Math.Min(startIndex + bound, endIndex);

            bool result = BinarySearch(value, newStartIndex, newEndIndex);
            stopwatch.Stop();
            return (result, stopwatch.Elapsed);
        }

        private bool BinarySearch(T value, int startIndex, int endIndex)
        {
            while (startIndex <= endIndex)
            {
                int middleIndex = startIndex + (endIndex - startIndex) / 2;
                Node middleNode = GetNodeAt(middleIndex);

                int comparisonResult = Comparer<T>.Default.Compare(middleNode.Value, value);
                if (comparisonResult == 0)
                {
                    return true;
                }
                else if (comparisonResult < 0)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex - 1;
                }
            }

            return false;
        }




    }
}

