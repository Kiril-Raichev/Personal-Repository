using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedListWorkshop
{
    public class LinkedList<T> : IList<T>
    {
        private Node head;
        private Node tail;

        public LinkedList()
        {
            this.head = this.tail = null;
            this.Count = 0;
        }

        /// <summary>
        /// The first element in the list or exception when list is empty
        /// </summary>
        public T Head
        {
            get
            {
                this.ThrowIfEmpty();
                return this.head.Value;
            }
        }

        /// <summary>
        /// The last element in the list or exception when list is empty
        /// </summary>
        public T Tail
        {
            get
            {
                this.ThrowIfEmpty();
                return this.tail.Value;
            }
        }

        /// <summary>
        /// The number of elements currently in the list
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds the value to the start of the list
        /// </summary>
        /// <param name="value">The value to add</param>
        public void AddFirst(T value)
        {
            if (this.Count == 0)
            {
                AddInEmptyList(value);
                return;
            }

            // We insert 3 (newHead) before 5
            // Before: Head -------> 5 <-> 7 <- Tail
            // After:  Head -> 3 <-> 5 <-> 7 <- Tail
            Node newHead = new Node(value);
            newHead.Next = this.head;
            this.head.Prev = newHead;
            this.head = newHead;
            this.Count++;
        }

        /// <summary>
        /// Adds the value to the end of the list
        /// </summary>
        /// <param name="value">The value to add</param>
        public void AddLast(T value)
        {
            if (this.Count == 0)
            {
                AddInEmptyList(value);
                return;
            }

            // We insert 7 (newTail) after 5
            // Before: Head -> 3 <-> 5 <------- Tail
            // After:  Head -> 3 <-> 5 <-> 7 <- Tail
            Node newTail = new Node(value);
            newTail.Prev = this.tail;
            this.tail.Next = newTail;
            this.tail = newTail;
            this.Count++;
        }

        /// <summary>
        /// Adds the value to the specified index or throws exception if index is invalid
        /// </summary>
        /// <param name="index">The index where to add</param>
        /// <param name="value">The value to add</param>
        public void Add(int index, T value)
        {
            // We can add at position within the existing items [0;Count]
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            // We handle separately adding first or last
            if (index == 0)
            {
                this.AddFirst(value);
                return;
            }

            if (index == this.Count)
            {
                this.AddLast(value);
                return;
            }

            // We insert 5 (newNode) before 7 (node at index)
            // Before: Head -> 3 <-------> 7 <- Tail
            // After:  Head -> 3 <-> 5 <-> 7 <- Tail

            // Find the node at the index - we will insert before it
            Node node = this.GetNode(index);
            // Store reference to the previous node
            Node prevNode = node.Prev;

            // Create and init the newNode
            Node newNode = new Node(value);
            // Point next of the previous node to the newNode
            prevNode.Next = newNode;
            // Point previous of the newNode to the previous of the node
            newNode.Prev = prevNode;
            // Point next of the newNode to the node
            newNode.Next = node;
            // Point previous of the node to the newNode
            node.Prev = newNode;
            this.Count++;
        }

        /// <summary>
        /// Gets the value from the specified index or throws exception if index is invalid
        /// </summary>
        /// <param name="index">The index where to add</param>
        public T Get(int index)
        {
            Node node = this.GetNode(index);
            return node.Value;
        }

        /// <summary>
        /// Returns the index of the value or -1 if value not present in the list
        /// </summary>
        /// <param name="value">The value to search</param>
        public int IndexOf(T value)
        {
            int result = 0;
            Node current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return result;
                }
                current = current.Next;
                result++;
            }

            return -1;
        }

        /// <summary>
        /// Removes the first node from the list or thorws exception if list is empty
        /// </summary>
        public T RemoveFirst()
        {
            this.ThrowIfEmpty();

            // We handle separately removing last element
            if (this.Count == 1)
            {
                return this.RemoveFromListWithOneElement();
            }

            // We remove the head (3)
            // Before: Head -> 3 <-> 5 <- Tail
            // After:  Head -------> 5 <- Tail

            // Store the value of the head
            T result = this.Head;
            // Point head to the next node
            this.head = this.head.Next;
            // Remove link with previous (old head)
            this.head.Prev = null;
            this.Count--;

            return result;
        }

        /// <summary>
        /// Removes the last node from the list or thorws exception if list is empty
        /// </summary>
        public T RemoveLast()
        {
            this.ThrowIfEmpty();

            // We handle separately removing last element
            if (this.Count == 1)
            {
                return this.RemoveFromListWithOneElement();
            }

            // We remove the tail (5)
            // Before: Head -> 3 <-> 5 <- Tail
            // After:  Head -> 3 <------- Tail

            // Store the value of the tail
            T result = this.tail.Value;
            // Point tails to the previous node
            this.tail = this.tail.Prev;
            // Remove link with next (old tail)
            this.tail.Next = null;
            this.Count--;

            return result;
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        private void ThrowIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void AddInEmptyList(T value)
        {
            Node newNode = new Node(value);
            this.head = newNode;
            this.tail = newNode;
            this.Count++;
        }

        private T RemoveFromListWithOneElement()
        {
            T result = this.Head;
            this.head = null;
            this.tail = null;
            this.Count = 0;
            return result;
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
        }
    }
}