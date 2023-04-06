using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace DaA
{
    public class MyArrayList<T>
    {
        private T[] _items;
        private int _count;
        private int _capacity;

        public MyArrayList()
        {
            _count = 0;
            _capacity = 4;
            _items = new T[_capacity];
        }

        public int Count => _count;

        public T Get(int index)
        {
            ValidateIndex(index);
            return _items[index];
        }

        public void Add(T value)
        {
            EnsureCapacity();
            _items[_count++] = value;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            EnsureCapacity();
            Array.Copy(_items, index, _items, index + 1, _count - index);
            _items[index] = value;
            _count++;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            Array.Copy(_items, index + 1, _items, index, _count - index - 1);
            _count--;
            _items[_count] = default(T);
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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _count; i++)
            {
                sb.Append(_items[i]);
                if (i < _count - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }



        private int IndexOf(T value)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _count);
            _count = 0;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        private void EnsureCapacity()
        {
            if (_count == _capacity)
            {
                _capacity *= 2;
                T[] newItems = new T[_capacity];
                Array.Copy(_items, 0, newItems, 0, _count);
                _items = newItems;
            }
        }

        public TimeSpan BubbleSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                for (int j = startIndex; j < endIndex - i + startIndex; j++)
                {
                    if (comparer.Compare(_items[j], _items[j + 1]) > 0)
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
            sw.Stop();
            return sw.Elapsed;
        }

        public TimeSpan QuickSort(int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            QuickSortHelper(startIndex, endIndex, comparer);
            sw.Stop();
            return sw.Elapsed;
        }

        private void QuickSortHelper(int start, int end, IComparer<T> comparer)
        {
            if (start < end)
            {
                int pivotIndex = Partition(start, end, comparer);
                QuickSortHelper(start, pivotIndex - 1, comparer);
                QuickSortHelper(pivotIndex + 1, end, comparer);
            }
        }

        private int Partition(int start, int end, IComparer<T> comparer)
        {
            T pivot = _items[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (comparer.Compare(_items[j], pivot) < 0)
                {
                    i++;
                    T temp = _items[i];
                    _items[i] = _items[j];
                    _items[j] = temp;
                }
            }

            T temp2 = _items[i + 1];
            _items[i + 1] = _items[end];
            _items[end] = temp2;

            return i + 1;
        }

        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], value))
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
            Stopwatch sw = Stopwatch.StartNew();
            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            while (startIndex <= endIndex)
            {
                int middleIndex = startIndex + (endIndex - startIndex) / 2;
                int compareResult = comparer.Compare(_items[middleIndex], value);

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

    }
}
