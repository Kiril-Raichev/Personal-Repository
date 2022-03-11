using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    class CircularQueue
    {
        private int[] items;
        private int head;
        private int tail;
        private int capacity;
        private int count;

        public CircularQueue(int capacity)
        {
            this.items = new int[capacity];
            this.head = 0;
            this.tail = -1;
            this.capacity = capacity;
            this.count = 0;
        }

        public void Enqueue(int item)
        {
            if (this.count == this.capacity)
            {
                throw new InvalidOperationException("Queue is full");
            }
            else
            {
                this.tail = (this.tail + 1) % this.capacity;
                this.items[this.tail] = item;
                this.count++;
            }
        }

        public void Dequeue()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            else
            {
                this.head = (this.head + 1) % this.capacity;
                this.count--;
            }
        }

        public override string ToString()
        {
            if (this.count == 0)
            {
                return "";
            }

            var result = new List<int>();
            int i = this.head;

            for (int j = 0; j < this.count; j++)
            {
                result.Add(this.items[i]);
                i = (i + 1) % this.capacity;
            }

            return string.Join(",", result);
        }
    }
}
