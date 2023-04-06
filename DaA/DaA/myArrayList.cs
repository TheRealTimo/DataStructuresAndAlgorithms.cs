using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DaA
{
    public class MyArrayList<T>
    {
        private int _capacity;
        private T[] _items;

        public MyArrayList()
        {
            Count = 0;
            _capacity = 4;
            _items = new T[_capacity];
        }

        public int Count { get; private set; }

        public T Get(int index)
        {
            ValidateIndex(index);
            return _items[index];
        }

        public void Add(T value)
        {
            EnsureCapacity();
            _items[Count++] = value;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));

            EnsureCapacity();
            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = value;
            Count++;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            Count--;
            _items[Count] = default;
        }

        public bool Remove(T value)
        {
            var index = IndexOf(value);
            if (index == -1) return false;

            RemoveAt(index);
            return true;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < Count; i++)
            {
                sb.Append(_items[i]);
                if (i < Count - 1) sb.Append(", ");
            }

            return sb.ToString();
        }


        private int IndexOf(T value)
        {
            for (var i = 0; i < Count; i++)
                if (EqualityComparer<T>.Default.Equals(_items[i], value))
                    return i;
            return -1;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, Count);
            Count = 0;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
        }

        private void EnsureCapacity()
        {
            if (Count == _capacity)
            {
                _capacity *= 2;
                var newItems = new T[_capacity];
                Array.Copy(_items, 0, newItems, 0, Count);
                _items = newItems;
            }
        }

        public TimeSpan BubbleSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            if (comparer == null) comparer = Comparer<T>.Default;

            for (var i = startIndex; i <= endIndex; i++)
            for (var j = startIndex; j < endIndex - i + startIndex; j++)
                if (comparer.Compare(_items[j], _items[j + 1]) > 0)
                {
                    var temp = _items[j];
                    _items[j] = _items[j + 1];
                    _items[j + 1] = temp;
                }

            sw.Stop();
            return sw.Elapsed;
        }

        public TimeSpan QuickSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            if (comparer == null) comparer = Comparer<T>.Default;

            QuickSortHelper(startIndex, endIndex, comparer);
            sw.Stop();
            return sw.Elapsed;
        }

        private void QuickSortHelper(int start, int end, IComparer<T> comparer)
        {
            if (start < end)
            {
                var pivotIndex = Partition(start, end, comparer);
                QuickSortHelper(start, pivotIndex - 1, comparer);
                QuickSortHelper(pivotIndex + 1, end, comparer);
            }
        }

        private int Partition(int start, int end, IComparer<T> comparer)
        {
            var pivot = _items[end];
            var i = start - 1;

            for (var j = start; j < end; j++)
                if (comparer.Compare(_items[j], pivot) < 0)
                {
                    i++;
                    var temp = _items[i];
                    _items[i] = _items[j];
                    _items[j] = temp;
                }

            var temp2 = _items[i + 1];
            _items[i + 1] = _items[end];
            _items[end] = temp2;

            return i + 1;
        }

        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            var sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            for (var i = startIndex; i <= endIndex; i++)
                if (EqualityComparer<T>.Default.Equals(_items[i], value))
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }

            sw.Stop();
            return (false, sw.Elapsed);
        }

        public (bool, TimeSpan) BinarySearch(T value, int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            var sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            if (comparer == null) comparer = Comparer<T>.Default;

            while (startIndex <= endIndex)
            {
                var middleIndex = startIndex + (endIndex - startIndex) / 2;
                var compareResult = comparer.Compare(_items[middleIndex], value);

                if (compareResult == 0)
                {
                    sw.Stop();
                    return (true, sw.Elapsed);
                }

                if (compareResult < 0)
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
    }
}