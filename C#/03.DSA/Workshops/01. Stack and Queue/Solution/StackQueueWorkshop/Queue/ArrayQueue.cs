using System;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int tail;

        public ArrayQueue()
        {
            this.items = new T[DefaultCapacity];
            this.tail = 0;
        }

        public int Size
        {
            get
            {
                return this.tail;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Size == 0;
            }
        }

        public void Enqueue(T element)
        {
            if (this.tail == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.tail] = element;
            this.tail++;
        }

        public T Dequeue()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }

            T element = this.items[0];
            
            for (int i = 1; i < this.tail; i++)
            {
                this.items[i - 1] = this.items[i];
            }
            
            this.tail--;
            
            return element;
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return this.items[0];
        }

        private void Resize()
        {
            T[] newItems = new T[this.items.Length * 2];
            Array.Copy(this.items, newItems, this.items.Length);
            this.items = newItems;
        }
    }
}
