using System;

namespace StackQueueWorkshop.Stack
{
    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> top;
        private int size;

        public LinkedStack()
        {
            this.top = null;
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

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = element;
            newNode.Next = this.top;
            this.top = newNode;
            this.size++;
        }

        public T Pop()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }
            
            T element = this.top.Data;
            this.top = this.top.Next;
            this.size--;
            
            return element;
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }
            
            return this.top.Data;
        }
    }
}
