using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaA
{
    internal class Stack
    {
        private List<int> Items;

        public Stack()
        {
            Items = new List<int>();
        }

        public void Push(int item)
        {
            Items.Add(item);
        }

        public int Pop()
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            int lastIndex = Items.Count - 1;
            int lastItem = Items[lastIndex];
            Items.RemoveAt(lastIndex);
            return lastItem;
        }

        public int Peek()
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            int lastIndex = Items.Count - 1;
            return Items[lastIndex];
        }

        public bool LinearSearch(int searchValue, int start = 0, int end = int.MaxValue)
        {
            int currentPosition = 0;

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                if (currentPosition >= start && currentPosition <= end)
                {
                    if (Items[i] == searchValue)
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

        public bool ExponentialSearch(int searchValue, int start = 0, int end = int.MaxValue)
        {
            int position = 0;
            int bound = 1;

            while (bound < end - start + 1 && position < Items.Count && Items[position] < searchValue)
            {
                position += bound;
                bound *= 2;
            }

            int left = Math.Max(position - bound / 2, start);
            int right = Math.Min(position + bound / 2, Items.Count - 1);

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (Items[mid] == searchValue)
                {
                    return true;
                }
                else if (Items[mid] < searchValue)
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
                        if (Items[j] > Items[j + 1])
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

            QuickSortRecursive(start, end);
        }

        private void QuickSortRecursive(int start, int end)
        {
            if (start >= end)
            {
                return;
            }
        }
        private void Swap(int index1, int index2)
        {
            int temp = Items[index1];
            Items[index1] = Items[index2];
            Items[index2] = temp;
        }

    }
}
