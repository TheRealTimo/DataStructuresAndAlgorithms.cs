using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaA
{
    public class myStack<T> where T : IComparable<T>
    {
        private List<T> Items;

        public myStack()
        {
            Items = new List<T>();
        }

        public int Count
        {
            get { return Items.Count; }
        }


        public IEnumerable<T> GetItems()
        {
            return Items.AsEnumerable();
        }


        public void Push(T item)
        {
            Items.Add(item);
        }

        public T Pop()
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            int lastIndex = Items.Count - 1;
            T lastItem = Items[lastIndex];
            Items.RemoveAt(lastIndex);
            return lastItem;
        }

        public T Peek()
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            int lastIndex = Items.Count - 1;
            return Items[lastIndex];
        }



        private void Swap(int index1, int index2)
        {
            T temp = Items[index1];
            Items[index1] = Items[index2];
            Items[index2] = temp;
        }

        public (bool, TimeSpan) LinearSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Items.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (Items[i].CompareTo(value) == 0)
                {
                    stopwatch.Stop();
                    return (true, stopwatch.Elapsed);
                }
            }
            stopwatch.Stop();
            return (false, stopwatch.Elapsed);
        }

        public (bool, TimeSpan) ExponentialSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Items.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (Items[startIndex].CompareTo(value) == 0)
            {
                stopwatch.Stop();
                return (true, stopwatch.Elapsed);
            }

            int bound = 1;
            while (bound <= endIndex - startIndex && Items[startIndex + bound].CompareTo(value) <= 0)
            {
                if (Items[startIndex + bound].CompareTo(value) == 0)
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
                int comparisonResult = Items[middleIndex].CompareTo(value);

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
        public TimeSpan BubbleSort(int startIndex, int endIndex)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = startIndex; i < endIndex; i++)
            {
                for (int j = startIndex; j < endIndex - i + startIndex; j++)
                {
                    if (Items[j].CompareTo(Items[j + 1]) > 0)
                    {
                        Swap(j, j + 1);
                    }
                }
            }
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public TimeSpan QuickSort(int startIndex, int endIndex)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
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
            T pivot = Items[endIndex];
            int i = startIndex - 1;

            for (int j = startIndex; j < endIndex; j++)
            {
                if (Items[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, endIndex);
            return i + 1;
        }

        private void Swap(int index1, int index2, List<T> list)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }


    }
}
