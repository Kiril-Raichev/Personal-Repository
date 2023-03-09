using System;

namespace StackQueueWorkshop.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int top;

        public ArrayStack()
        {
            this.items = new T[DefaultCapacity];
            this.top = 0;
        }

        public int Size
        {
            get
            {
                return this.top;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Size == 0;
            }
        }

        public void Push(T element)
        {
            if (this.top == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.top] = element;
            this.top++;
        }

        public T Pop()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }
            
            this.top--;
            return this.items[this.top];
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }
            
            return this.items[this.top - 1];
        }

        private void Resize()
        {
            T[] newItems = new T[this.items.Length * 2];
            Array.Copy(this.items, newItems, this.items.Length);
            this.items = newItems;
        }
    }
}
