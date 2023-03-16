using System;
using System.Collections.Generic;
using System.Text;

namespace DaA
{
    internal class Queue<T> where T : IComparable<T>
    {
        private List<T> items;

        public Queue()
        {
            items = new List<T>();
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

        public bool LinearSearch(T searchValue, int start, int end)
        {
            if (start < 0 || end >= items.Count || start > end)
            {
                throw new ArgumentException("Invalid range for LinearSearch");
            }

            for (int i = start; i <= end; i++)
            {
                if (items[i].CompareTo(searchValue) == 0)
                {
                    return true;
                }
            }

            return false;
        }


        public bool ExponentialSearch(T searchValue, int start = 0, int end = int.MaxValue)
        {
            int position = 0;
            int bound = 1;

            while (bound < end - start + 1 && position < items.Count && items[position].CompareTo(searchValue) < 0)
            {
                position += bound;
                bound *= 2;
            }

            int left = Math.Max(position - bound / 2, start);
            int right = Math.Min(position + bound / 2, items.Count - 1);

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (items[mid].CompareTo(searchValue) == 0)
                {
                    return true;
                }
                else if (items[mid].CompareTo(searchValue) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }

        public void BubbleSort(int start = 0, int end = int.MaxValue)
        {
            if (items.Count <= 1)
            {
                return;
            }

            int currentPosition = 0;

            for (int i = 0; i < items.Count - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < items.Count - i - 1; j++)
                {
                    if (currentPosition >= start && currentPosition <= end)
                    {
                        if (items[j].CompareTo(items[j + 1]) > 0)
                        {
                            Swap(j, j + 1);
                            swapped = true;
                        }
                    }

                    currentPosition++;

                    if (currentPosition > end)
                    {
                        break;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        public void QuickSort(int start = 0, int end = int.MaxValue)
        {
            if (items.Count <= 1)
            {
                return;
            }

            end = Math.Min(end, items.Count - 1);
            QuickSortRecursive(start, end);
        }

        private void QuickSortRecursive(int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivotIndex = Partition(start, end);
            QuickSortRecursive(start, pivotIndex - 1);
            QuickSortRecursive(pivotIndex + 1, end);
        }

        private int Partition(int start, int end)
        {
            T pivot = items[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (items[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, end);
            return i + 1;
        }


        private void Swap(int index1, int index2)
        {
            if (index1 < 0 || index1 >= items.Count || index2 < 0 || index2 >= items.Count)
            {
                throw new IndexOutOfRangeException();
            }

            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < items.Count; i++)
            {
                sb.Append(items[i]);

                if (i < items.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }


    }
}
