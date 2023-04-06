using System.Collections.Generic;
using System;
using System.Text;
using System.Diagnostics;

namespace DaA
{
    public class MyArrayList<T>
    {
        private class Node
        {
            public T Value;
            public Node Next;

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node _head;
        private Node _tail;
        private int _count;

        public MyArrayList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count => _count;

        public T Get(int index)
        {
            ValidateIndex(index);
            Node current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public void Add(T value)
        {
            Node newNode = new Node(value);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node newNode = new Node(value);
            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
                if (_tail == null)
                {
                    _tail = newNode;
                }
            }
            else
            {
                Node previous = _head;
                for (int i = 1; i < index; i++)
                {
                    previous = previous.Next;
                }
                newNode.Next = previous.Next;
                previous.Next = newNode;
                if (newNode.Next == null)
                {
                    _tail = newNode;
                }
            }
            _count++;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            if (index == 0)
            {
                _head = _head.Next;
                if (_head == null)
                {
                    _tail = null;
                }
            }
            else
            {
                Node previous = _head;
                for (int i = 1; i < index; i++)
                {
                    previous = previous.Next;
                }
                previous.Next = previous.Next.Next;
                if (previous.Next == null)
                {
                    _tail = previous;
                }
            }
            _count--;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }


        public int IndexOf(T value)
        {
            Node current = _head;
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return i;
                }
                current = current.Next;
            }

            return -1;
        }
        public bool Remove(T value)
        {
            int index = IndexOf(value);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }


        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= _count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            Stopwatch sw = Stopwatch.StartNew();

            Node current = _head;
            for (int i = 0; i < startIndex; i++)
            {
                current = current.Next;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }
                current = current.Next;
            }

            sw.Stop();
            return (false, sw.Elapsed);
        }

        public (bool, TimeSpan) BinarySearch(T value, int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            if (startIndex < 0 || endIndex >= _count || startIndex > endIndex)
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
                T middleValue = Get(middleIndex);
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

            return (false, sw.Elapsed);
        }

        public TimeSpan BubbleSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            Stopwatch sw = Stopwatch.StartNew();

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            Node startNode = GetNodeAt(startIndex);
            Node endNode = GetNodeAt(endIndex);

            for (Node i = startNode; i != endNode; i = i.Next)
            {
                Node currentNode = startNode;
                Node nextNode = startNode.Next;
                for (Node j = startNode; j != endNode; j = j.Next)
                {
                    if (comparer.Compare(currentNode.Value, nextNode.Value) > 0)
                    {
                        T temp = currentNode.Value;
                        currentNode.Value = nextNode.Value;
                        nextNode.Value = temp;
                    }
                    currentNode = nextNode;
                    nextNode = nextNode.Next;
                }
            }
            sw.Stop();
            return sw.Elapsed;
        }

        private Node GetNodeAt(int index)
        {
            ValidateIndex(index);
            Node current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public TimeSpan QuickSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            Stopwatch sw = Stopwatch.StartNew();

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            QuickSortHelper(startIndex, endIndex, comparer);

            sw.Stop();
            return sw.Elapsed;
        }


        private void QuickSortHelper(int start, int end, IComparer<T> comparer = null)
        {
            if (start >= end) return;

            int pivotIndex = Partition(start, end, comparer);

            QuickSortHelper(start, pivotIndex - 1, comparer);
            QuickSortHelper(pivotIndex + 1, end, comparer);
        }

        private int Partition(int start, int end, IComparer<T> comparer)
        {
            Node pivot = GetNodeAt(end);
            int pivotIndex = start;
            Node pivotIndexNode = GetNodeAt(start);
            Node current = GetNodeAt(start);

            for (int i = start; i < end; i++)
            {
                if (comparer.Compare(current.Value, pivot.Value) < 0)
                {
                    if (i != pivotIndex)
                    {
                        T temp = current.Value;
                        current.Value = pivotIndexNode.Value;
                        pivotIndexNode.Value = temp;
                    }
                    pivotIndex++;
                    pivotIndexNode = pivotIndexNode.Next;
                }
                current = current.Next;
            }

            T temp2 = current.Value;
            current.Value = pivot.Value;
            pivot.Value = temp2;

            return pivotIndex;
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



    }
}