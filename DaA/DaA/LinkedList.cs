using System;
using System.Collections.Generic;
using System.Text;

namespace DaA
{
    public class DoublyLinkedList<T> where T: IComparable<T>
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

        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public bool LinearSearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("startIndex and endIndex must be within the bounds of the list, and startIndex must not be greater than endIndex.");
            }

            Node currentNode = head;
            int currentIndex = 0;

            while (currentNode != null && currentIndex <= endIndex)
            {
                if (currentIndex >= startIndex && currentNode.Value.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            return false;
        }



        public int Count
        {
            get
            {
                int count = 0;
                Node currentNode = head;

                while (currentNode != null)
                {
                    count++;
                    currentNode = currentNode.Next;
                }

                return count;
            }
        }

        public bool ExponentialSearch(T searchValue, int start = 0, int end = int.MaxValue)
        {
            if (Count == 0)
            {
                return false;
            }

            int position = start;
            int bound = 1;
            Node currentNode = GetNodeAt(position);

            while (bound < end - start + 1 && position < Count && Comparer<T>.Default.Compare(currentNode.Value, searchValue) < 0)
            {
                position += bound;
                for (int i = 0; i < bound && currentNode != null; i++)
                {
                    currentNode = currentNode.Next;
                }
                bound *= 2;
            }

            int left = Math.Max(position - bound / 2, start);
            int right = Math.Min(position + bound / 2, Count - 1);

            currentNode = GetNodeAt(left);

            while (left <= right)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, searchValue))
                {
                    return true;
                }
                else if (Comparer<T>.Default.Compare(currentNode.Value, searchValue) < 0)
                {
                    left++;
                    currentNode = currentNode.Next;
                }
                else
                {
                    right--;
                    currentNode = currentNode.Previous;
                }
            }

            return false;
        }




        public void BubbleSort(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("startIndex and endIndex must be within the bounds of the list, and startIndex must not be greater than endIndex.");
            }

            if (startIndex == endIndex || head == null || head == tail)
            {
                return;
            }

            bool swapped;
            Node currentNode;

            do
            {
                swapped = false;
                currentNode = head;
                int currentIndex = 0;

                while (currentNode != null && currentIndex < endIndex)
                {
                    if (currentIndex >= startIndex && Comparer<T>.Default.Compare(currentNode.Value, currentNode.Next.Value) > 0)
                    {
                        T tempValue = currentNode.Value;
                        currentNode.Value = currentNode.Next.Value;
                        currentNode.Next.Value = tempValue;
                        swapped = true;
                    }

                    currentNode = currentNode.Next;
                    currentIndex++;
                }

                endIndex--;
            } while (swapped);
        }

        public void QuickSort(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentException("Invalid start and/or end index.");
            }

            Node startNode = GetNodeAt(startIndex);
            Node endNode = GetNodeAt(endIndex);

            Quicksort(startNode, endNode);
        }

        private void Quicksort(Node left, Node right)
        {
            if (left == null || right == null || left == right || left.Previous == right)
            {
                return;
            }

            Node pivot = Partition(left, right);

            if (pivot != null && pivot.Previous != null)
            {
                Quicksort(left, pivot.Previous);
            }

            if (pivot != null && pivot.Next != null)
            {
                Quicksort(pivot.Next, right);
            }
        }

        private Node Partition(Node left, Node right)
        {
            if (left == right)
            {
                return left;
            }

            Node pivot = right;
            Node current = left;
            Node prev = null;

            while (current != pivot)
            {
                int comparison = Comparer<T>.Default.Compare(current.Value, pivot.Value);

                if (comparison > 0)
                {
                    Node nextNode = current.Next;
                    Swap(current, pivot);
                    Swap(current, pivot.Previous);

                    pivot = pivot.Previous;
                    current = prev != null ? prev.Next : left;
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            }

            return pivot;
        }


        private void Swap(Node left, Node right)
        {
            T tempValue = left.Value;
            left.Value = right.Value;
            right.Value = tempValue;
        }

        private Node GetNodeAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index must be within the bounds of the list.");
            }

            Node currentNode = head;
            int currentIndex = 0;

            while (currentNode != null && currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node currentNode = head;

            while (currentNode != null)
            {
                sb.Append(currentNode.Value.ToString());
                if (currentNode.Next != null)
                {
                    sb.Append(", ");
                }
                currentNode = currentNode.Next;
            }

            return sb.ToString();
        }


    }




}