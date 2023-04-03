using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaA
{
    public class myQueue<T> where T : IComparable<T>
    {
        private List<T> items;

        public myQueue()
        {
            items = new List<T>();
        }

        public int Count
        {
            get { return items.Count; }
        }

        public IEnumerable<T> GetItems()
        {
            return items.AsEnumerable();
        }


        public void Enqueue(T item)
        {
            items.Add(item);
        }


        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T firstItem = items[0];
            items.RemoveAt(0);
            return firstItem;
        }

        public T Peek()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return items[0];
        }

        public TimeSpan BubbleSort(int startIndex = 0, int endIndex = -1)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (endIndex == -1) endIndex = items.Count - 1;

            for (int i = startIndex; i < endIndex; i++)
            {
                for (int j = startIndex; j < endIndex - i + startIndex; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        Swap(j, j + 1);
                    }
                }
            }
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
        public TimeSpan QuickSort(int startIndex = 0, int endIndex = -1)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (endIndex == -1) endIndex = items.Count - 1;

            QuickSortHelper(startIndex, endIndex);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        private void QuickSortHelper(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivotIndex = Partition(startIndex, endIndex);
            QuickSortHelper(startIndex, pivotIndex - 1);
            QuickSortHelper(pivotIndex + 1, endIndex);
        }

        private int Partition(int startIndex, int endIndex)
        {
            T pivot = items[endIndex];
            int i = startIndex - 1;

            for (int j = startIndex; j < endIndex; j++)
            {
                if (items[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, endIndex);
            return i + 1;
        }

        private void Swap(int index1, int index2)
        {
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= items.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (items[i].CompareTo(value) == 0)
                {
                    stopwatch.Stop();
                    return (true, stopwatch.Elapsed);
                }
            }

            return (false, stopwatch.Elapsed);
        }

        public (bool, TimeSpan) ExponentialSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= items.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            if (items[startIndex].CompareTo(value) == 0)
            {
                stopwatch.Stop();
                return (true, stopwatch.Elapsed);
            }

            int bound = 1;
            while (bound <= endIndex - startIndex && items[startIndex + bound].CompareTo(value) <= 0)
            {
                if (items[startIndex + bound].CompareTo(value) == 0)
                {
                    return (true, stopwatch.Elapsed);
                }
                bound *= 2;
            }

            int left = Math.Max(bound / 2, startIndex);
            int right = Math.Min(bound, endIndex);
            bool result = BinarySearch(value, left, right);
            stopwatch.Stop();
            return (result, stopwatch.Elapsed);
        }

        private bool BinarySearch(T value, int startIndex, int endIndex)
        {
            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                int comparisonResult = items[middleIndex].CompareTo(value);

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
