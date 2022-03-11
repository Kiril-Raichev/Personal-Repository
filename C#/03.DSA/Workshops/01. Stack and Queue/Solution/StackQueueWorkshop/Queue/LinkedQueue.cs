using System;

namespace StackQueueWorkshop.Queue
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> head, tail;
        private int size;

        public LinkedQueue()
        {
            this.head = this.tail = null;
            this.size = 0;
        }

        public int Size
        {
            get
            {
                return this.size;
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
            Node<T> newNode = new Node<T>();
            newNode.Data = element;

            if (this.IsEmpty)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.size++;
        }

        public T Dequeue()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }

            T element = this.head.Data;
            this.head = this.head.Next;
            this.size--;

            if (this.IsEmpty)
            {
                this.tail = null;
            }

            return element;
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return this.head.Data;
        }
    }
}
