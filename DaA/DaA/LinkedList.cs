using System;
using System.Collections.Generic;

namespace DaA
{
    public class DoublyLinkedList<T>
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
            if (startIndex < 0 || endIndex >= Count)
            {
                throw new ArgumentOutOfRangeException("startIndex and endIndex must be within the bounds of the list.");
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
        public bool BinarySearch(T value, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("startIndex and endIndex must be within the bounds of the list, and startIndex must not be greater than endIndex.");
            }

            int leftIndex = startIndex;
            int rightIndex = endIndex;

            while (leftIndex <= rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;

                Node currentNode = head;
                for (int i = 0; i < middleIndex; i++)
                {
                    currentNode = currentNode.Next;
                }

                int comparison = Comparer<T>.Default.Compare(currentNode.Value, value);

                if (comparison == 0)
                {
                    return true;
                }
                else if (comparison < 0)
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    rightIndex = middleIndex - 1;
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

        public void Quicksort(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= Count || startIndex >= endIndex)
            {
                throw new ArgumentException("Invalid start and/or end index.");
            }

            Node startNode = GetNodeAt(startIndex);
            Node endNode = GetNodeAt(endIndex);

            Quicksort(startNode, endNode);
        }

        private void Quicksort(Node left, Node right)
        {
            if (left == right)
            {
                return;
            }

            Node pivot = Partition(left, right);

            if (pivot != null && pivot != left)
            {
                Quicksort(left, pivot.Previous);
            }

            if (pivot != null && pivot != right)
            {
                Quicksort(pivot.Next, right);
            }
        }

        private Node Partition(Node left, Node right)
        {
            Node pivot = right;
            Node current = left;

            while (current != null && current != pivot)
            {
                int comparison = Comparer<T>.Default.Compare(current.Value, pivot.Value);

                if (comparison > 0)
                {
                    Swap(current, pivot);
                    pivot = pivot.Previous;
                }
                else
                {
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

    }




}
