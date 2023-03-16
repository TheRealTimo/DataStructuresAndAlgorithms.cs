using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaA
{
    internal class Stack<T>
    {
        private List<T> Items;

        public Stack()
        {
            Items = new List<T>();
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

        public bool LinearSearch(T searchValue, int start, int end)
        {
            int currentPosition = 0;

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                if (currentPosition >= start && currentPosition <= end)
                {
                    if (EqualityComparer<T>.Default.Equals(Items[i], searchValue))
                    {
                        return true;
                    }
                }

                currentPosition++;

                if (currentPosition > end)
                {
                    break;
                }
            }

            return false;
        }

        public bool ExponentialSearch(T searchValue, int start = 0, int end = int.MaxValue)
        {
            int position = 0;
            int bound = 1;

            while (bound < end - start + 1 && position < Items.Count && Comparer<T>.Default.Compare(Items[position], searchValue) < 0)
            {
                position += bound;
                bound *= 2;
            }

            int left = Math.Max(position - bound / 2, start);
            int right = Math.Min(position + bound / 2, Items.Count - 1);

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (EqualityComparer<T>.Default.Equals(Items[mid], searchValue))
                {
                    return true;
                }
                else if (Comparer<T>.Default.Compare(Items[mid], searchValue) < 0)
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
            if (Items.Count <= 1)
            {
                return;
            }

            int currentPosition = 0;

            for (int i = 0; i < Items.Count - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < Items.Count - i - 1; j++)
                {
                    if (currentPosition >= start && currentPosition <= end)
                    {
                        if (Comparer<T>.Default.Compare(Items[j], Items[j + 1]) > 0)
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
            if (Items.Count <= 1)
            {
                return;
            }

            end = Math.Min(end, Items.Count - 1);
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
            T pivot = Items[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (Comparer<T>.Default.Compare(Items[j], pivot) < 0)
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
            T temp = Items[index1];
            Items[index1] = Items[index2];
            Items[index2] = temp;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                sb.Append(Items[i]);

                if (i > 0)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }

    }
}
