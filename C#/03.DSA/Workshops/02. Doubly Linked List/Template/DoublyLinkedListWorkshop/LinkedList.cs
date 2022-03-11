using System;
using System.Collections;
using System.Drawing;

namespace DoublyLinkedListWorkshop
{
    public class LinkedList<T> : IList<T>
    {
        private Node head;
        private Node tail;

        public T Head
        {
            get
            {
                this.ThrowIfEmpty();
                return this.head.Value;
            }
        }

        public T Tail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public void AddFirst(T value)
        {
            var newNode = new Node(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.Next = this.head;
                this.head.Prev = newNode;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.Prev = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public void Add(int index, T value)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }



            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == this.Count)
            {
                AddLast(value);
            }
            else
            {
                var newNode = new Node(value);



                var temp = this.head;
                temp.Next = this.head.Next;

                for (int i = 0; i < index - 1; i++)
                {
                    temp = temp.Next;
                }

                newNode.Prev = temp;
                newNode.Next = temp.Next;
                temp.Next.Prev = newNode;
                temp.Next = newNode;
                Count++;
            }
        }

        public T Get(int index)
        {
            Node node = this.GetNode(index);
            return node.Value;

            //if (index < 0 || index >= this.Count)
            //{
            //    throw new ArgumentOutOfRangeException();
            //}

            //Node current = this.head;

            // for
            //for (int i = 0; i < index; i++)
            //{
            //    current = current.Next;
            //}

            //return current.Value;

            // foreach
            //int counter = 0;
            //foreach (var item in this)
            //{
            //    if(counter == index)
            //    {
            //        return item;
            //    }

            //    counter++;
            //}

            //return default(T);

            // while
            // Node current = this.head;
            // while (index > 0)
            // {
            //     current = current.Next;
            //     index--;
            // }
            // return current.Value;


        }

        private Node GetNode(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node current = this.head;
            while (index > 0)
            {
                current = current.Next;
                index--;
            }

            return current;
        }

        public int IndexOf(T value)
        {
            int index = 0;
            Node current = this.head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }


            // if not found
            return -1;
        }

        public T RemoveFirst()
        {
            this.ThrowIfEmpty();

            T result = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Prev = null;
            }

            this.Count--;
            return result;
        }

        public T RemoveLast()
        {
            this.ThrowIfEmpty();

            T result = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Prev;
                this.tail.Next = null;
            }

            this.Count--;
            return result;
        }

        private void ThrowIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new ListEnumerator(this.head);
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        // Use private nested class so that LinkedList users
        // don't know about the LinkedList internal structure
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value
            {
                get;
                private set;
            }

            public Node Next
            {
                get;
                set;
            }

            public Node Prev
            {
                get;
                set;
            }

            //public override string ToString()
            //{
            //    return $" {this.Value} ";
            //}
        }

        // List enumerator that enables traversing all nodes of a list in a foreach loop
        private class ListEnumerator : System.Collections.Generic.IEnumerator<T>
        {
            private Node start;
            private Node current;

            internal ListEnumerator(Node head)
            {
                this.start = head;
                this.current = null;
            }

            public T Current
            {
                get
                {
                    if (this.current == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return this.current.Value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = this.start;
                    return true;
                }

                if (current.Next == null)
                {
                    return false;
                }

                current = current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = null;
            }
        }
    }
}