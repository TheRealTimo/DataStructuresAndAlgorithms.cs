using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaA
{
    public class myStack<T> where T : IComparable<T>
    {
        private List<T> Items;

        public myStack()
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



        private void Swap(int index1, int index2)
        {
            T temp = Items[index1];
            Items[index1] = Items[index2];
            Items[index2] = temp;
        }

    }
}
